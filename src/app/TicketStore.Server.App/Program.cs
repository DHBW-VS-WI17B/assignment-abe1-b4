﻿using Akka.Actor;
using Akka.Configuration;
using Serilog;
using System;
using TicketStore.Server.Logic;
using TicketStore.Server.Logic.Actors;

namespace TicketStore.Server.App
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
                        port = 8081
                        hostname = 0.0.0.0
                        public-hostname = localhost
                    }
                }
                loglevel=INFO,
                loggers=[""Akka.Logger.Serilog.SerilogLogger, Akka.Logger.Serilog""]
            }
            ");

            using var system = ActorSystem.Create("Server", config);

            var eventActorProps = Props.Create<EventActor>(() => new EventActor());
            var eventActor = system.ActorOf(eventActorProps, nameof(EventActor));

            var userActorProps = Props.Create<UserActor>(() => new UserActor());
            var userActor = system.ActorOf(eventActorProps, nameof(UserActor));

            Console.ReadLine();
        }
    }
}
