using Akka.Actor;
using Akka.Event;
using Sharprompt;
using Sharprompt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Client.Logic.Messages;
using TicketStore.Client.Logic.Util;
using TicketStore.Shared.Requests;
using TicketStore.Shared.Responses;

namespace TicketStore.Client.Logic
{
    public class TicketStoreClientActor : ReceiveActor
    {
        private readonly ActorSelection _remoteEventActorRef;
        private readonly ActorSelection _remoteUserActorRef;
        private readonly IJsonDataStore _jsonDataStore;
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private Guid _userId;
        private double _yearlyBudget;

        public TicketStoreClientActor(ActorSelection remoteEventActorRef, ActorSelection remoteUserActorRef, IJsonDataStore jsonDataStore)
        {
            _remoteEventActorRef = remoteEventActorRef;
            _remoteUserActorRef = remoteUserActorRef;
            _jsonDataStore = jsonDataStore;

            Receive<RestoreStateMessage>(msg =>
            {
                _logger.Info("Received message: {msg}", msg);

                Config config = null;
                try
                {
                    config = _jsonDataStore.Read<Config>();
                }
                catch (Exception ex)
                {
                    _logger.Info("No config found. Reason: {exMessage}", ex.Message);
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

            Receive<InitStateMessage>(async msg =>
            {
                _logger.Info("Received message: {msg}", msg);

                var createUserResponse = await _remoteUserActorRef.Ask<CreateUserResponse>(new CreateUserRequest(msg.UserDto)).ConfigureAwait(false);

                if (createUserResponse.Successful)
                {
                    _userId = createUserResponse.UserDto.Id;
                    _yearlyBudget = msg.YearlyBudget;

                    Self.Tell(new PersistStateMessage());

                    _logger.Info("User with id {userId} was created successfully!", createUserResponse.UserDto.Id);
                }
                else
                {
                    _logger.Error("User was not created, try again! Reason: {msg}", createUserResponse?.ErrorMessage);
                }
            });

            Receive<PersistStateMessage>(msg =>
            {
                _logger.Info("Received message: {msg}", msg);

                try
                {
                    _jsonDataStore.Write(new Config { UserId = _userId, YearlyBudget = _yearlyBudget });
                }
                catch (Exception ex)
                {
                    _logger.Warning("Saving the config failed. Reason: {exMessage}", ex.Message);
                }
            });
        }
    }
}
