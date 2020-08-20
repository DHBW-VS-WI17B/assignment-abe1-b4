using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.App
{
    public class Options
    {
        [Option('v', "verbose", Default = false, Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; }

        [Option('p', "port", Default = "8081", Required = false, HelpText = "The port this server instance exposes.")]
        public string Port { get; }

        [Option('i', "instances", Default = 5, Required = false, HelpText = "The number of instances of stateless actors.")]
        public int ActorInstanceCount { get; }

        public Options(bool verbose, string port, int actorInstanceCount)
        {
            Verbose = verbose;
            Port = port;
            ActorInstanceCount = actorInstanceCount;
        }
    }
}
