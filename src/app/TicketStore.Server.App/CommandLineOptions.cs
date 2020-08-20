using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.App
{
    public class CommandLineOptions
    {
        [Option('v', "verbose", Default = false, Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; }

        [Option('p', "port", Default = "8081", Required = false, HelpText = "The port this server instance exposes.")]
        public string Port { get; }

        [Option('i', "instances", Default = 5, Required = false, HelpText = "The number of instances of stateless actors.")]
        public int ActorInstanceCount { get; }

        [Option('r',"reset", Default = false, Required = false, HelpText = "Wipes the database.")]
        public bool Reset { get;  }

        public CommandLineOptions(bool verbose, string port, int actorInstanceCount, bool reset)
        {
            Verbose = verbose;
            Port = port;
            ActorInstanceCount = actorInstanceCount;
            Reset = reset;
        }
    }
}
