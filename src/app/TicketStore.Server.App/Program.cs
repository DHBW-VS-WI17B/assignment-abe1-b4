using Akka.Actor;
using Akka.Configuration;
using System;
using TicketStore.Server.Logic;

namespace TicketStore.Server.App
{
    class Program
    {
        static void Main(string[] args)
        {
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
            }
            ");

            using (var system = ActorSystem.Create("Server", config))
            {
                var userActor = system.ActorOf(Props.Create<UserActor>(), "user");
                var registerUserActor = system.ActorOf(Props.Create<RegisterUserActor>(() => new RegisterUserActor(userActor)));
            }

            Console.ReadLine();
        }
    }
}
