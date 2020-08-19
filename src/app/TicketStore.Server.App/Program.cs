using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;
using TicketStore.Server.Logic;
using TicketStore.Server.Logic.Actors;
using TicketStore.Server.Logic.DataAccess;
using TicketStore.Server.Logic.DataAccess.Contracts;

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

            var options = new DbContextOptionsBuilder().UseInMemoryDatabase("app").Options;
            using var context = new RepositoryContext(options);
            var repositoryWrapper = new RepositoryWrapper(context);

            // TODO: use https://github.com/akkadotnet/HOCON
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

            var writeToDbActorProps = Props.Create<WriteToDbActor>(() => new WriteToDbActor(repositoryWrapper));
            var writeToDbActor = system.ActorOf(writeToDbActorProps, nameof(WriteToDbActor));
            var writeToDbActorRef = system.ActorSelection(writeToDbActor.Path);

            var eventActorProps = Props.Create<EventActor>(() => new EventActor(writeToDbActorRef))
                .WithRouter(new RoundRobinPool(5));
            var eventActor = system.ActorOf(eventActorProps, nameof(EventActor));

            var userActorProps = Props.Create<UserActor>(() => new UserActor(writeToDbActorRef))
                .WithRouter(new RoundRobinPool(5));
            var userActor = system.ActorOf(eventActorProps, nameof(UserActor));

            Console.ReadLine();
        }
    }
}
