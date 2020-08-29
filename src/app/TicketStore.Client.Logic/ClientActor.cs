using Akka.Actor;
using Akka.Event;
using Akka.Util.Internal;
using BetterConsoleTables;
using System;
using System.Text.Json;
using System.Threading.Tasks;
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

            // register message handlers
            Receive<ErrorMessage>(ProcessMessage);
            Receive<RestoreStateMessage>(ProcessMessage);
            Receive<InitStateMessage>(ProcessMessage);
            Receive<CreateUserSuccess>(ProcessMessage);
            Receive<PersistStateMessage>(ProcessMessage);
            Receive<CreateEventMessage>(ProcessMessage);
            Receive<CreateEventSuccess>(ProcessMessage);
            Receive<GetSoldTicketsMessage>(ProcessMessage);
            Receive<GetSoldTicketsSuccess>(ProcessMessage);
            Receive<GetAllEventsMessage>(ProcessMessage);
            Receive<GetAllEventsSuccess>(ProcessMessage);
            Receive<GetEventByIdMessage>(ProcessMessage);
            Receive<GetEventByIdSuccess>(ProcessMessage);
            Receive<PurchaseTicketsMessage>(ProcessMessage);
            Receive<PurchaseTicketsSuccess>(ProcessMessage);
            Receive<GetRemainingBudgetForCurrentYearMessage>(ProcessMessage);
            Receive<GetRemainingBudgetForCurrentYearSuccess>(ProcessMessage);
            Receive<GetPurchasedTicketsMessage>(ProcessMessage);
            Receive<GetPurchasedTicketsSuccess>(ProcessMessage);
            ReceiveAsync<TestConnectionMessage>(ProcessMessageAsync);
        }

        /// <summary>
        /// Processes an error message. Displays the error.
        /// </summary>
        /// <param name="msg">Immutable error message.</param>
        private void ProcessMessage(ErrorMessage msg)
        {
            _logger.Error(msg.Message);
            Console.WriteLine($"Error: {msg.Message}");
            Helper.GracefulExitError();
        }

        /// <summary>
        /// Processes a restore state message (try to initialize the client).
        /// </summary>
        /// <param name="msg">Immutable restore state message.</param>
        private void ProcessMessage(RestoreStateMessage msg)
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
        }

        /// <summary>
        /// Processes a init state message to initialize the client actor by telling the remote user actor to create a new user.
        /// </summary>
        /// <param name="msg">Immutable init state message.</param>
        private void ProcessMessage(InitStateMessage msg)
        {
            _remoteUserActorRef.Tell(new CreateUserRequest(Guid.NewGuid(), msg.UserDto));
        }

        /// <summary>
        /// Processes a create user success message. Displays the new user and stores the user id.
        /// </summary>
        /// <param name="msg">Immutable crate user success message.</param>
        private void ProcessMessage(CreateUserSuccess msg)
        {
            _logger.Info("Created user with id {id}", msg.UserDto.Id);
            Console.WriteLine($"Created new user with id {msg.UserDto.Id}:");
            PrintPretty(msg.UserDto);
            _userId = msg.UserDto.Id;
            Self.Tell(new PersistStateMessage());
        }

        /// <summary>
        /// Processes a persist state message. Persists the user id.
        /// </summary>
        /// <param name="msg">Immutable persist state message.</param>
        private void ProcessMessage(PersistStateMessage msg)
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
        }

        /// <summary>
        /// Processes a create event message. Tell the remote event actor to create a new event.
        /// </summary>
        /// <param name="msg">Immutable create event message.</param>
        private void ProcessMessage(CreateEventMessage msg)
        {
            _remoteEventActorRef.Tell(new CreateEventRequest(Guid.NewGuid(), msg.EventDto));
        }

        /// <summary>
        /// Processes a create event success message.
        /// </summary>
        /// <param name="msg">Immutable create event success message.</param>
        private void ProcessMessage(CreateEventSuccess msg)
        {
            _logger.Info("Created event with id {id}", msg.EventDto.Id);
            Console.WriteLine("Created event with id {msg.EventDto.Id}:");
            PrintPretty(msg.EventDto);
            Helper.GracefulExitSuccess();
        }

        /// <summary>
        /// Processes a get sold tickets message. Requests the sold tickets for an event from the remote event actor.
        /// </summary>
        /// <param name="msg">Immutable get sold tickets message.</param>
        private void ProcessMessage(GetSoldTicketsMessage msg)
        {
            _remoteEventActorRef.Tell(new GetSoldTicketsRequest(Guid.NewGuid(), msg.EventId));
        }

        /// <summary>
        /// Processes a get sold tickets success message. Displays the number of sold tickets.
        /// </summary>
        /// <param name="msg">Immutable get sold tickets success message.</param>
        private void ProcessMessage(GetSoldTicketsSuccess msg)
        {
            _logger.Info("Event id {id} sold {count} ticket(s) so far.", msg.EventId, msg.SoldTicketCount);
            Console.WriteLine($"Tickets sold count for event with id {msg.EventId}: {msg.SoldTicketCount}");
            Helper.GracefulExitSuccess();
        }

        /// <summary>
        /// Processes a get all events message. Requests all events from the remote event actor.
        /// </summary>
        /// <param name="msg">Immmutable get all events message.</param>
        private void ProcessMessage(GetAllEventsMessage msg)
        {
            _remoteEventActorRef.Tell(new GetAllEventsRequest(Guid.NewGuid()));
        }

        /// <summary>
        /// Processes a get all events success message. Displays all events in a table.
        /// </summary>
        /// <param name="msg">Immutable get all events success message.</param>
        private void ProcessMessage(GetAllEventsSuccess msg)
        {
            _logger.Info("Received {count} events.", msg.EventDtos.Count);
            Console.WriteLine($"Received {msg.EventDtos.Count} events");

            if (msg.EventDtos.Count > 0)
            {
                var table = new Table("ID", "Event name");
                msg.EventDtos.ForEach(e =>
                {
                    table.AddRow(e.Id, e.Name);
                });
                table.Config = TableConfiguration.Markdown();
                Console.WriteLine(table.ToString());
            }
            Helper.GracefulExitSuccess();
        }

        /// <summary>
        /// Processes a get event by id message. Requests a event for given id from the remote event actor.
        /// </summary>
        /// <param name="msg">Immutable get event by id message.</param>
        private void ProcessMessage(GetEventByIdMessage msg)
        {
            _remoteEventActorRef.Tell(new GetEventByIdRequest(Guid.NewGuid(), msg.EventId));
        }

        /// <summary>
        /// Processes a get event by id success message. Displays the event.
        /// </summary>
        /// <param name="msg">Immutable get event by id success message.</param>
        private void ProcessMessage(GetEventByIdSuccess msg)
        {
            _logger.Info("Received details for event with id {id}.", msg.EventDto.Id);
            Console.WriteLine($"Received details for event with id {msg.EventDto.Id}:");
            PrintPretty(msg.EventDto);
            Helper.GracefulExitSuccess();
        }

        /// <summary>
        /// Processes a purchase tickets message. Requests tickets for an event from the remote event actor.
        /// </summary>
        /// <param name="msg">Immutable purchase tickets message.</param>
        private void ProcessMessage(PurchaseTicketsMessage msg)
        {
            _remoteEventActorRef.Tell(new PurchaseTicketsRequest(Guid.NewGuid(), msg.EventId, _userId, msg.TicketCount));
        }

        /// <summary>
        /// Processes a purchase tickets success message. Displays purchased tickets.
        /// </summary>
        /// <param name="msg">Immutable purchase tickets success message.</param>
        private void ProcessMessage(PurchaseTicketsSuccess msg)
        {
            _logger.Info("Successfully purchased {count} tickets for event with id {eventId}", msg.TicketDtos.Count, msg.TicketDtos[0].EventId);
            Console.WriteLine($"Successfully purchased {msg.TicketDtos.Count} tickets for event with id {msg.TicketDtos[0].EventId}:");
            PrintPretty(msg.TicketDtos);
            Helper.GracefulExitSuccess();
        }

        /// <summary>
        /// Processes a get remaining budget for current year message. Requests the remaining budget for events in the current year from the remote user actor.
        /// </summary>
        /// <param name="msg">Immutable get remaining budget for current year message.</param>
        private void ProcessMessage(GetRemainingBudgetForCurrentYearMessage msg)
        {
            _remoteUserActorRef.Tell(new GetRemainingBudgetForCurrentYearRequest(_userId));
        }

        /// <summary>
        /// Processes a get remaining budget for current year success message. Displays the remaining budget.
        /// </summary>
        /// <param name="msg">Immutable get remaining budget for current year success message.</param>
        private void ProcessMessage(GetRemainingBudgetForCurrentYearSuccess msg)
        {
            _logger.Info("Remaining budget for events taking place in the current year: {remainingBudget} out of {budget} money units.", msg.RemainingBuget, msg.YearlyBudget);
            Console.WriteLine($"Remaining budget for events taking place in the current year: {msg.RemainingBuget} out of {msg.YearlyBudget} money units.");
            Helper.GracefulExitSuccess();
        }

        /// <summary>
        /// Processes a get purchased tickets message. Requests purchased tickets from remote user actor.
        /// </summary>
        /// <param name="msg">Immutable get purchased tickets message.</param>
        private void ProcessMessage(GetPurchasedTicketsMessage msg)
        {
            TicketFilter ticketFilter = null;
            if (msg.FilterBy != null && msg.FilterDateTime != null)
            {
                ticketFilter = new TicketFilter(Enum.Parse<QueryCriterion>(msg.FilterBy), (DateTime)msg.FilterDateTime);
            }

            TicketSorting ticketSorting = null;
            if (msg.SortBy != null && msg.OrderDirection != null)
            {
                ticketSorting = new TicketSorting(Enum.Parse<QueryCriterion>(msg.SortBy), Enum.Parse<OrderDirection>(msg.OrderDirection));
            }

            _remoteUserActorRef.Tell(new GetPurchasedTicketsRequest(Guid.NewGuid(), _userId, ticketSorting, ticketFilter));
        }

        /// <summary>
        /// Processes a get purchased tickets success message. Displays purchased tickets.
        /// </summary>
        /// <param name="msg">Immutable get purchased tickets success message.</param>
        private void ProcessMessage(GetPurchasedTicketsSuccess msg)
        {
            _logger.Info("Received {count} ticket(s).", msg.Tickets.Count);
            Console.WriteLine($"Received {msg.Tickets.Count} ticket(s)");

            if (msg.Tickets.Count > 0)
            {
                var table = new Table("TicketId", "PurchaseDate", "Price", "EventName", "EventDate");
                msg.Tickets.ForEach(t =>
                {
                    table.AddRow(t.Id, t.PurchaseDate, t.EventDto.PricePerTicket, t.EventDto.Name, t.EventDto.Date);
                });
                table.Config = TableConfiguration.Markdown();
                Console.WriteLine(table.ToString());
            }
            Helper.GracefulExitSuccess();
        }

        /// <summary>
        /// Processes a test connection message. Test the connection to each remote actor.
        /// </summary>
        /// <param name="msg">Immutable test connection message.</param>
        /// <returns>Task.</returns>
        private async Task ProcessMessageAsync(TestConnectionMessage msg)
        {
            var timeout = TimeSpan.FromSeconds(3);

            _logger.Info("Sending handshake message to remote event actor.");
            try
            {
                var response = await _remoteEventActorRef.Ask<HandshakeResponse>(new HandshakeRequest(Guid.NewGuid()), timeout).ConfigureAwait(false);
                var duration = DateTime.UtcNow - response.RequestDispatchDate;
                _logger.Info("Received handshake response for request with id {requestId}. The handshake took {miliseconds} ms.", response.RequestId, duration.TotalMilliseconds);
            }
            catch (AskTimeoutException ex)
            {
                _logger.Error(ex, "Wasn't able to connect to the remote event actor!");
                Console.WriteLine("Error: Wasn't able to connect to the remote event actor. Did you start the server and did you configure the correct connection details?");
            }
            _logger.Info("Sending handshake message to remote user actor.");
            try
            {
                var response = await _remoteUserActorRef.Ask<HandshakeResponse>(new HandshakeRequest(Guid.NewGuid()), timeout).ConfigureAwait(false);
                var duration = DateTime.UtcNow - response.RequestDispatchDate;
                _logger.Info("Received handshake response for request with id {requestId}. The handshake took {miliseconds} ms.", response.RequestId, duration.TotalMilliseconds);
            }
            catch (AskTimeoutException ex)
            {
                _logger.Error(ex, "Wasn't able to connect to the remote user actor!");
                Console.WriteLine("Error: Wasn't able to connect to the remote user actor. Did you start the server and did you configure the correct connection details?");
            }
        }

        /// <summary>
        /// Prints an object as pretty json.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="entity">Object to be printed.</param>
        private static void PrintPretty<T>(T entity)
        {
            var str = JsonSerializer.Serialize<T>(entity, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(str);
        }
    }
}
