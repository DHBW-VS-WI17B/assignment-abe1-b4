using Akka.Actor;
using Akka.Configuration;
using Akka.Configuration.Hocon;
using CommandLine;
using Serilog;
using System;
using System.Collections.Generic;
using TicketStore.Client.Logic.Actors;
using Parser = CommandLine.Parser;

namespace TicketStore.Client.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(RunWithOptions)
                .WithNotParsed(HandleParseErrors);
        }

        static void RunWithOptions(Options opts)
        {
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
                .WriteTo.Console();

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
