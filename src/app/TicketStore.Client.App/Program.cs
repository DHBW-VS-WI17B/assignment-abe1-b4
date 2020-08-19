using Akka.Actor;
using Akka.Configuration;
using System;

namespace TicketStore.Client.App
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
		                port = 0
		                hostname = localhost
                    }
                }
            }
            ");

            using var system = ActorSystem.Create("Client", config);

            Console.ReadLine();
        }
    }
}
