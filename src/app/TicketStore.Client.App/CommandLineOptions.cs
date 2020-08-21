using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.App
{
    public class CommandLineOptions
    {
        [Option('v', "verbose", Default = false, Required = false, HelpText = "Set log level to verbose.")]
        public bool Verbose { get; }

        [Option('h', "host", Default = "localhost:8081", Required = false, HelpText = "The host IP and port of the server.")]
        public string Host { get; }

        [Option('a', "admin", Default = false, Required = false, HelpText = "Starts the application in administrator mode.")]
        public bool Admin { get; }

        [Option('c', "command", Required = true, HelpText = "Command to be executed. Run command 'List' for a list of all available commands.")]
        public Command Command { get; }

        [Option('s',"silent", Default = false, Required = false, HelpText = "Hides all log messages except data objects from console.")]
        public bool Silent { get; }

        public CommandLineOptions(bool verbose, string host, bool admin, Command command, bool silent)
        {
            Verbose = verbose;
            Host = host;
            Admin = admin;
            Command = command;
            Silent = silent;
        }
    }
}
