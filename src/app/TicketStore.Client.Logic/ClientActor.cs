using Akka.Actor;
using Akka.Event;
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
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Client.Logic
{
    public class ClientActor : ReceiveActor, ILogReceive
    {
        private readonly ActorSelection _remoteEventActorRef;
        private readonly ActorSelection _remoteUserActorRef;
        private readonly IJsonDataStore _jsonDataStore;
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private Guid _userId;
        private double _yearlyBudget;

        public ClientActor(ActorSelection remoteEventActorRef, ActorSelection remoteUserActorRef, IJsonDataStore jsonDataStore)
        {
            _remoteEventActorRef = remoteEventActorRef;
            _remoteUserActorRef = remoteUserActorRef;
            _jsonDataStore = jsonDataStore;

            Receive<ErrorMessage>(msg =>
            {
                _logger.Error(msg.Error);
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
                    Helper.GracefulExitError();
                }
                else
                {
                    _userId = config.UserId;
                    _yearlyBudget = config.YearlyBudget;
                    _logger.Info("Client initialized successfully!");
                }
            });

            Receive<InitStateMessage>(msg =>
            {
                _yearlyBudget = msg.YearlyBudget;
                _remoteUserActorRef.Tell(new CreateUserRequest(Guid.NewGuid(), msg.UserDto));
            });

            Receive<CreateUserSuccess>(msg =>
            {
                _logger.Info("Created user with id {id}", msg.UserDto.Id);
                _userId = msg.UserDto.Id;
                Self.Tell(new PersistStateMessage());
            });

            Receive<PersistStateMessage>(msg =>
            {
                try
                {
                    _jsonDataStore.Write(new Config { UserId = _userId, YearlyBudget = _yearlyBudget });
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
                Helper.GracefulExitSuccess();
            });

            Receive<GetSoldTicketsMessage>(msg =>
            {
                _remoteEventActorRef.Tell(new GetSoldTicketsRequest(Guid.NewGuid(), msg.EventId));
            });

            Receive<GetSoldTicketsSuccess>(msg =>
            {
                _logger.Info("Event id {id} sold {count} ticket(s) so far.", msg.EventId, msg.SoldTicketCount);
            });

            Receive<GetAllEventsMessage>(msg =>
            {
                _remoteEventActorRef.Tell(new GetAllEventsRequest(Guid.NewGuid()));
            });

            Receive<GetAllEventsSuccess>(msg =>
            {
                _logger.Info("Received {count} events.", msg.EventDtos.Count);

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

                var eventStr = JsonSerializer.Serialize<EventDto>(msg.EventDto, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(eventStr);
                Helper.GracefulExitSuccess();
            });
        }
    }
}
