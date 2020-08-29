using CommandLine;

namespace TicketStore.Server.App
{
    /// <summary>
    /// Command line options.
    /// </summary>
    public class CommandLineOptions
    {
        [Option('v', "verbose", Default = false, Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; }

        [Option('p', "port", Default = "8081", Required = false, HelpText = "The port this server instance exposes.")]
        public string Port { get; }

        [Option('a', "actor-instance-count", Default = 5, Required = false, HelpText = "The number of instances for each stateless actor.")]
        public int ActorInstanceCount { get; }

        [Option('r', "reset", Default = false, Required = false, HelpText = "Wipes the database.")]
        public bool Reset { get; }

        public CommandLineOptions(bool verbose, string port, int actorInstanceCount, bool reset)
        {
            Verbose = verbose;
            Port = port;
            ActorInstanceCount = actorInstanceCount;
            Reset = reset;
        }
    }
}
