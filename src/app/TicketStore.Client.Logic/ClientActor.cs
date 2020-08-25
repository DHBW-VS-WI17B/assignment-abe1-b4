using Akka.Actor;
using Akka.Event;
using Akka.Util.Internal;
using BetterConsoleTables;
using Sharprompt;
using Sharprompt.Validations;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using TicketStore.Client.Logic.Messages;
using TicketStore.Client.Logic.Util;
using TicketStore.Shared;
using TicketStore.Shared.Enums;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Client.Logic
{
    /// <summary>
    /// Client actor. The bridge between the remote actor system and the host of this application.
    /// </summary>
    public class ClientActor : ReceiveActor, ILogReceive
    {
        private readonly ActorSelection _remoteEventActorRef;
        private readonly ActorSelection _remoteUserActorRef;
        private readonly IJsonDataStore _jsonDataStore;
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private Guid _userId;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="remoteEventActorRef">The ref to the remote event actor.</param>
        /// <param name="remoteUserActorRef">The ref to the remote user actor.</param>
        /// <param name="jsonDataStore">A json data store.</param>
        public ClientActor(ActorSelection remoteEventActorRef, ActorSelection remoteUserActorRef, IJsonDataStore jsonDataStore)
        {
            _remoteEventActorRef = remoteEventActorRef;
            _remoteUserActorRef = remoteUserActorRef;
            _jsonDataStore = jsonDataStore;

            Receive<ErrorMessage>(msg =>
            {
                _logger.Error(msg.Message);
                Console.WriteLine($"Error: {msg.Message}");
                Helper.GracefulExitError();
            });

            Receive<RestoreStateMessage>(msg =>
            {
                Config config = null;
                try
                {
                    config = _jsonDataStore.Read<Config>();
                }
                catch (Exception ex)
                {
                    _logger.Warning(ex, "No config found.");
                }

                if (config == null)
                {
                    _logger.Error("Please initialize the client before running other commands!");
                    Console.Write("Please initialize the client before running other commands!");
                    Helper.GracefulExitError();
                }
                else
                {
                    _userId = config.UserId;
                    _logger.Info("Client initialized successfully!");
                }
            });

            Receive<InitStateMessage>(msg =>
            {
                _remoteUserActorRef.Tell(new CreateUserRequest(Guid.NewGuid(), msg.UserDto));
            });

            Receive<CreateUserSuccess>(msg =>
            {
                _logger.Info("Created user with id {id}", msg.UserDto.Id);
                Console.WriteLine($"Created new user with id {msg.UserDto.Id}:");
                PrintPretty(msg.UserDto);
                _userId = msg.UserDto.Id;
                Self.Tell(new PersistStateMessage());
            });

            Receive<PersistStateMessage>(msg =>
            {
                try
                {
                    _jsonDataStore.Write(new Config { UserId = _userId });
                    _logger.Debug("Persisted config successfully.");
                    Helper.GracefulExitSuccess();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Saving the config failed.");
                    Helper.GracefulExitError();

                }
            });

            Receive<CreateEventMessage>(msg =>
            {
                _remoteEventActorRef.Tell(new CreateEventRequest(Guid.NewGuid(), msg.EventDto));
            });

            Receive<CreateEventSuccess>(msg =>
            {
                _logger.Info("Created event with id {id}", msg.EventDto.Id);
                Console.WriteLine("Created event with id {msg.EventDto.Id}:");
                PrintPretty(msg.EventDto);
                Helper.GracefulExitSuccess();
            });

            Receive<GetSoldTicketsMessage>(msg =>
            {
                _remoteEventActorRef.Tell(new GetSoldTicketsRequest(Guid.NewGuid(), msg.EventId));
            });

            Receive<GetSoldTicketsSuccess>(msg =>
            {
                _logger.Info("Event id {id} sold {count} ticket(s) so far.", msg.EventId, msg.SoldTicketCount);
                Console.WriteLine($"Tickets sold count for event with id {msg.EventId}: {msg.SoldTicketCount}");
                Helper.GracefulExitSuccess();
            });

            Receive<GetAllEventsMessage>(msg =>
            {
                _remoteEventActorRef.Tell(new GetAllEventsRequest(Guid.NewGuid()));
            });

            Receive<GetAllEventsSuccess>(msg =>
            {
                _logger.Info("Received {count} events.", msg.EventDtos.Count);
                Console.WriteLine($"Received {msg.EventDtos.Count} events:");
                var table = new Table("ID", "Event name");
                msg.EventDtos.ForEach(e =>
                {
                    table.AddRow(e.Id, e.Name);
                });
                table.Config = TableConfiguration.Markdown();
                Console.WriteLine(table.ToString());
                Helper.GracefulExitSuccess();
            });

            Receive<GetEventByIdMessage>(msg =>
            {
                _remoteEventActorRef.Tell(new GetEventByIdRequest(Guid.NewGuid(), msg.EventId));
            });

            Receive<GetEventByIdSuccess>(msg =>
            {
                _logger.Info("Received details for event with id {id}.", msg.EventDto.Id);
                Console.WriteLine($"Received details for event with id {msg.EventDto.Id}:");
                PrintPretty(msg.EventDto);
                Helper.GracefulExitSuccess();
            });

            Receive<PurchaseTicketsMessage>(msg => 
            {
                _remoteEventActorRef.Tell(new PurchaseTicketsRequest(Guid.NewGuid(), msg.EventId, _userId, msg.TicketCount));
            });

            Receive<PurchaseTicketsSuccess>(msg =>
            {
                _logger.Info("Successfully purchased {count} tickets for event with id {eventId}", msg.TicketDtos.Count, msg.TicketDtos[0].EventId);
                Console.WriteLine($"Successfully purchased {msg.TicketDtos.Count} tickets for event with id {msg.TicketDtos[0].EventId}:");
                PrintPretty(msg.TicketDtos);
                Helper.GracefulExitSuccess();
            });

            Receive<GetRemainingBudgetForCurrentYearMessage>(msg =>
            {
                _remoteUserActorRef.Tell(new GetRemainingBudgetForCurrentYearRequest(_userId));
            });

            Receive<GetRemainingBudgetForCurrentYearSuccess>(msg =>
            {
                _logger.Info("Remaining budget for events taking place in the current year: {remainingBudget} out of {budget} money units.", msg.RemainingBuget, msg.YearlyBudget);
                Console.WriteLine($"Remaining budget for events taking place in the current year: {msg.RemainingBuget} out of {msg.YearlyBudget} money units.");
                Helper.GracefulExitSuccess();
            });

            Receive<GetPurchasedTicketsMessage>(msg =>
            {
                _remoteUserActorRef.Tell(new GetPurchasedTicketsRequest(Guid.NewGuid(), _userId, Enum.Parse<Order>(msg.Order), Enum.Parse<Sort>(msg.SortBy)));
            });

            Receive<GetPurchasedTicketsSuccess>(msg =>
            {
                _logger.Info("Received {count} ticket(s).", msg.Tickets.Count);
                Console.WriteLine($"Received {msg.Tickets.Count} ticket(s):");

                var table = new Table("TicketId", "PurchaseDate", "Price", "EventName", "EventDate");
                msg.Tickets.ForEach(t =>
                {
                    table.AddRow(t.Id, t.PurchaseDate, t.EventDto.PricePerTicket, t.EventDto.Name, t.EventDto.Date);
                });
                table.Config = TableConfiguration.Markdown();
                Console.WriteLine(table.ToString());
                Helper.GracefulExitSuccess();
            });
        }

        private static void PrintPretty<T>(T entity)
        {
            var str = JsonSerializer.Serialize<T>(entity, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(str);
        }
    }
}
