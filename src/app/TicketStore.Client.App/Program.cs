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

            [Option('p', "post", Required = false, HelpText = "Post the specified action from the API.")]
            public string Post { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       #region GetFunctions

                       //Details of an event.
                       if (o.Get == "event_details")
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

                       //Number of sold tickets for an event.
                       else if (o.Get == "ticket_sales")
                       {


                       }

                       //Ticket of a specific user
                       else if (o.Get == "user_tickets")
                       {

                       }

                       //Budget of a specific user
                       else if (o.Get == "user_budget")
                       {

                       }

                       #endregion


                       #region Set Functions

                       //Create event
                       if (o.Post == "create_event")
                       {

                       }

                       //Purchase Ticket
                       else if (o.Post == "purchase_ticket")
                       {

                       }

                       #endregion
                   });

        }

        //Auslagern -> Method JSON TO CONSOLE
        public string GetJasonString()
        {

            return string.Empty;
        }

    }
}