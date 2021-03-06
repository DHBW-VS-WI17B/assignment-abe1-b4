﻿using Akka.Actor;
using Akka.Configuration;
using CommandLine;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TicketStore.Client.Logic;
using TicketStore.Client.Logic.Messages;
using TicketStore.Client.Logic.Util;
using TicketStore.Shared;

namespace TicketStore.Client.App
{
    /// <summary>
    /// The main program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Arguments from the command line.</param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(RunWithOptions)
                .WithNotParsed(HandleParseErrors);
        }

        static void RunWithOptions(CommandLineOptions opts)
        {
            if (opts.Command == Command.List)
            {
                Console.WriteLine("Available commands:");
                var commandTypes = Enum.GetValues(typeof(Command)).Cast<Command>();
                foreach (var command in commandTypes)
                {
                    Console.WriteLine(Enum.GetName(typeof(Command), command));
                }
                Helper.GracefulExitSuccess();
            }

            var appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.DoNotVerify), "TicketStore", "Client");

            try
            {
                Directory.CreateDirectory(appDataDir);
            }
            catch (IOException)
            {
                Console.WriteLine($"FATAL Error: Can not create config directory: {appDataDir}");
                Helper.GracefulExitError();
            }

            var akkaConfig = @"
                akka {  
                    actor {
                        provider = remote
                    }
                    remote {
                        dot-netty.tcp {
		                    port = 0
		                    hostname = localhost
                        }
                    }
                    loglevel=INFO,
                    loggers=[""Akka.Logger.Serilog.SerilogLogger, Akka.Logger.Serilog""]
                }
            ";

            var jsonDataStore = new JsonDataStore(Path.Combine(appDataDir, "config.json"));

            var loggerBuilder = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(appDataDir, "log.txt"));

            if (opts.ShowLogs)
            {
                loggerBuilder = loggerBuilder.WriteTo.Console();
            }

            if (opts.Verbose)
            {
                loggerBuilder = loggerBuilder.MinimumLevel.Verbose();
                akkaConfig = akkaConfig.Replace("loglevel=INFO", "loglevel=DEBUG", StringComparison.Ordinal);
            }
            else
            {
                loggerBuilder = loggerBuilder.MinimumLevel.Information();
            }

            Serilog.Log.Logger = loggerBuilder.CreateLogger();

            using var system = ActorSystem.Create("client", ConfigurationFactory.ParseString(akkaConfig));

            var remoteEventActorRef = system.ActorSelection($"akka.tcp://server@{opts.Host}/user/EventActor");
            var remoteUserActorRef = system.ActorSelection($"akka.tcp://server@{opts.Host}/user/UserActor");

            var clientActorProps = Props.Create<ClientActor>(() => new ClientActor(remoteEventActorRef, remoteUserActorRef, jsonDataStore));
            var clientActor = system.ActorOf(clientActorProps, nameof(ClientActor));

            clientActor.Tell(new TestConnectionMessage());

            Log.Logger.Information("Selected command: {command}", opts.Command);

            if (opts.Command != Command.Init)
            {
                clientActor.Tell(new RestoreStateMessage());
            }

            if (!opts.Admin && (opts.Command == Command.CreateEvent || opts.Command == Command.GetSoldTicketCount))
            {
                Log.Logger.Error("This command is only available in admin mode!");
                Console.WriteLine("This command is only available in admin mode!");
                Helper.GracefulExitError();
            }

            switch (opts.Command)
            {
                case Command.Init:
                    var userDto = Ask.ForUserDto();
                    clientActor.Tell(new InitStateMessage(userDto));
                    break;

                case Command.CreateEvent:
                    var eventDto = Ask.ForEventDto();
                    clientActor.Tell(new CreateEventMessage(eventDto));
                    break;

                case Command.GetSoldTicketCount:
                    var eventId = Ask.ForEventId();
                    clientActor.Tell(new GetSoldTicketsMessage(eventId));
                    break;

                case Command.GetAllEvents:
                    clientActor.Tell(new GetAllEventsMessage());
                    break;

                case Command.GetEventById:
                    var id = Ask.ForEventId();
                    clientActor.Tell(new GetEventByIdMessage(id));
                    break;

                case Command.PurchaseTickets:
                    var eId = Ask.ForEventId();
                    var ticketCount = Ask.ForTicketCount();
                    clientActor.Tell(new PurchaseTicketsMessage(eId, ticketCount));
                    break;

                case Command.GetRemainingBudgetForCurrentYear:
                    clientActor.Tell(new GetRemainingBudgetForCurrentYearMessage());
                    break;

                case Command.GetPurchasedTickets:
                    string filterBy = null;
                    DateTime? filterDate = null;
                    if (Ask.IfTicketsShouldBeFiltered())
                    {
                        filterBy = Ask.ForFilterBy();
                        filterDate = Ask.ForFilterDateTime();
                    }
                    string sortBy = null, orderBy = null;
                    if (Ask.IfTicketsShouldBeSorted())
                    {
                        sortBy = Ask.ForSortBy();
                        orderBy = Ask.ForOrder();
                    }
                    clientActor.Tell(new GetPurchasedTicketsMessage(sortBy, orderBy, filterBy, filterDate));
                    break;

                default:
                    Log.Logger.Error("Invalid command.");
                    Console.WriteLine("Invalid command.");
                    break;
            }

            Console.ReadLine();
        }

        static void HandleParseErrors(IEnumerable<Error> errors)
        {
            foreach (var error in errors)
            {
                if (error.StopsProcessing)
                {
                    Serilog.Log.Logger.Error("Parsing error occured: {tag}", error?.Tag);
                }
            }
        }
    }
}
