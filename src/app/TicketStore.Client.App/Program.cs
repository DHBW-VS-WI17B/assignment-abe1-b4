using Akka.Actor;
using Akka.Configuration;
using CommandLine;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TicketStore.Client.App.UI;
using TicketStore.Client.Logic.Actors;

namespace TicketStore.Client.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(RunWithOptions)
                .WithNotParsed(HandleParseErrors);
        }

        static void RunWithOptions(CommandLineOptions opts)
        {
            var appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.DoNotVerify), "TicketStore", "Client");

            try
            {
                Directory.CreateDirectory(appDataDir);
            }
            catch (IOException)
            {
                Console.WriteLine($"FATAL Error: Can not create config directory: {appDataDir}");
                Environment.Exit(-1);
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

            var loggerBuilder = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(appDataDir, "log.txt"));

            if (opts.Verbose)
            {
                loggerBuilder = loggerBuilder
                    .MinimumLevel.Verbose();
                akkaConfig = akkaConfig.Replace("loglevel=INFO", "loglevel=VERBOSE", StringComparison.Ordinal);
            } else
            {
                loggerBuilder = loggerBuilder
                    .MinimumLevel.Information();
            }

            Serilog.Log.Logger = loggerBuilder.CreateLogger();

            using var system = ActorSystem.Create("client", ConfigurationFactory.ParseString(akkaConfig));

            var remoteEventActorRef = system.ActorSelection($"akka.tcp://server@{opts.Host}/user/EventActor");
            var remoteUserActorRef = system.ActorSelection($"akka.tcp://server@{opts.Host}/user/UserActor");

            // TODO: check if event and user actor are available.

            var ticketStoreClientActorProps = Props.Create<TicketStoreClientActor>(() => new TicketStoreClientActor(remoteEventActorRef, remoteUserActorRef));

            var ticketStoreClientActor = system.ActorOf(ticketStoreClientActorProps, nameof(TicketStoreClientActor));

            // test
            ticketStoreClientActor.Tell("test");

            var test1 = Ask.ForUserDto();
            var test2 = Ask.ForEventDto();

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
