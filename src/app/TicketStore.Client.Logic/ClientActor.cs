using Akka.Actor;
using Akka.Event;
using Sharprompt;
using Sharprompt.Validations;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using TicketStore.Client.Logic.Messages;
using TicketStore.Client.Logic.Util;
using TicketStore.Shared.Messages;

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
                    _logger.Info(ex, "No config found.");
                }

                if (config == null)
                {
                    _logger.Error("Please initialize the client before running other commands!");
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
                    _logger.Info("Persisted config successfully.");
                }
                catch (Exception ex)
                {
                    _logger.Warning(ex, "Saving the config failed.");
                }
            });

            Receive<CreateEventMessage>(msg =>
            {
                _remoteEventActorRef.Tell(new CreateEventRequest(Guid.NewGuid(), msg.EventDto));
            });

            Receive<CreateEventSuccess>(msg =>
            {
                _logger.Info("Created event with id {id}", msg.EventDto.Id);
            });
        }
    }
}
