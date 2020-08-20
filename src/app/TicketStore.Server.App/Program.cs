using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
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
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(RunWithOptions)
                .WithNotParsed(HandleParseErrors);
        }
        
        static void RunWithOptions(CommandLineOptions opts)
        {
            var appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.DoNotVerify), "TicketStore", "Server");

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
                            port = 8081
                            hostname = 0.0.0.0
                            public-hostname = localhost
                        }
                    }
                    loglevel=INFO,
                    loggers=[""Akka.Logger.Serilog.SerilogLogger, Akka.Logger.Serilog""]
                }
            ";

            akkaConfig = akkaConfig.Replace("port = 8081", $"port = {opts.Port}", StringComparison.Ordinal);

            var loggerBuilder = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(appDataDir, "log.txt"));

            if (opts.Verbose)
            {
                loggerBuilder = loggerBuilder
                    .MinimumLevel.Verbose();
                akkaConfig = akkaConfig.Replace("loglevel=INFO", "loglevel=VERBOSE", StringComparison.Ordinal);
            }
            else
            {
                loggerBuilder = loggerBuilder
                    .MinimumLevel.Information();
            }

            Serilog.Log.Logger = loggerBuilder.CreateLogger();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder().UseSqlite($"Data Source={Path.Combine(appDataDir, "database.db")}");
            using var context = new RepositoryContext(dbContextOptionsBuilder.Options);
            if (opts.Reset)
            {
                Log.Logger.Information("Wiping database.");
                context.Database.EnsureDeleted();
                Log.Logger.Information("Database was wiped.");
            }
            context.Database.EnsureCreated();
            var repositoryWrapper = new RepositoryWrapper(context);

            using var system = ActorSystem.Create("server", ConfigurationFactory.ParseString(akkaConfig));

            var writeToDbActorProps = Props.Create<WriteToDbActor>(() => new WriteToDbActor(repositoryWrapper));
            var writeToDbActor = system.ActorOf(writeToDbActorProps, nameof(WriteToDbActor));
            var writeToDbActorRef = system.ActorSelection(writeToDbActor.Path);

            var eventActorProps = Props.Create<EventActor>(() => new EventActor(writeToDbActorRef))
                .WithRouter(new RoundRobinPool(opts.ActorInstanceCount));
            var eventActor = system.ActorOf(eventActorProps, nameof(EventActor));

            var userActorProps = Props.Create<UserActor>(() => new UserActor(writeToDbActorRef))
                .WithRouter(new RoundRobinPool(opts.ActorInstanceCount));
            var userActor = system.ActorOf(eventActorProps, nameof(UserActor));

            var ticketActorProps = Props.Create<TicketActor>(() => new TicketActor(writeToDbActorRef))
                .WithRouter(new RoundRobinPool(opts.ActorInstanceCount));
            var ticketActor = system.ActorOf(eventActorProps, nameof(TicketActor));

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
