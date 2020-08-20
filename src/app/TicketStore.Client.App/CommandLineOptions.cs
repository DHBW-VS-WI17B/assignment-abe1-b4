using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.App
{
    public class CommandLineOptions
    {
        [Option('v', "verbose", Default = false, Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; }

        [Option('h', "host", Default = "localhost:8081", Required = false, HelpText = "The host IP and port of the server.")]
        public string Host { get; }

        public CommandLineOptions(bool verbose, string host)
        {
            Verbose = verbose;
            Host = host;
        }
    }
}
