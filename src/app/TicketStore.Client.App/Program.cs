using System;
using System.Collections.Generic;
using System.Text.Json;
using CommandLine;

namespace TicketStore.Client.App
{
    class Program
    {
        public class Options
        {
            [Option('g', "get", Required = false, HelpText = "Get the specified action from the API.")]
            public string Get { get; set; }

            [Option('s', "set", Required = false, HelpText = "Set the specified action from the API.")]
            public string Set { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Get == "events")
                       {

                           // get from rest api instead of creating the events here
                           var events = new Dictionary<string, string>()
                           {
                               {"event1", "toll" },
                               {"event2", "auch toll" },
                           };

                           var jsonString = JsonSerializer.Serialize<Dictionary<string, string>>(events, new JsonSerializerOptions { WriteIndented = true });

                           Console.WriteLine(jsonString);

                       }

                       else if (o.Set == "")
                       {

                       }
                   });
        }

       //Method JSON TO CONSOLE
    }
}