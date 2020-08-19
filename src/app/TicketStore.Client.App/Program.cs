﻿using Akka.Actor;
using Akka.Configuration;
using Serilog;
using System;
using TicketStore.Client.Logic.Actors;

namespace TicketStore.Client.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Information()
                .CreateLogger();

            Serilog.Log.Logger = logger;

            var config = ConfigurationFactory.ParseString(@"
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
            ");

            using var system = ActorSystem.Create("Client", config);

            var remoteEventActorRef = system.ActorSelection("akka.tcp://Server@localhost:8081/user/EventActor");
            var remoteUserActorRef = system.ActorSelection("akka.tcp://Server@localhost:8081/user/UserActor");

            // TODO: check if event and user actor are available.

            var ticketStoreClientActorProps = Props.Create<TicketStoreClientActor>(() => new TicketStoreClientActor(remoteEventActorRef, remoteUserActorRef));

            var ticketStoreClientActor = system.ActorOf(ticketStoreClientActorProps, nameof(TicketStoreClientActor));

            Console.ReadLine();
        }
    }
}
