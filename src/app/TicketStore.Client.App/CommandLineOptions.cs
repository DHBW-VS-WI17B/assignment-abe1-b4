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

        [Option('a', "admin", Default = false, Required = false, HelpText = "Starts the application in administrator mode.")]
        public bool Admin { get; }

        public CommandLineOptions(bool verbose, string host, bool admin)
        {
            Verbose = verbose;
            Host = host;
            Admin = admin;
        }
    }
}
