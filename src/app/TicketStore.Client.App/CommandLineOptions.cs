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

        [Option('s',"show-logs", Default = false, Required = false, HelpText = "Shows log messages directly in the console.")]
        public bool ShowLogs { get; }

        public CommandLineOptions(bool verbose, string host, bool admin, Command command, bool showLogs)
        {
            Verbose = verbose;
            Host = host;
            Admin = admin;
            Command = command;
            ShowLogs = showLogs;
        }
    }
}
