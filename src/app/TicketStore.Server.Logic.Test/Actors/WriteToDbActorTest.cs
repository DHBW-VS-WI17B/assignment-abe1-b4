using Akka.Actor;
using Akka.TestKit.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using TicketStore.Server.Logic.Actors;
using TicketStore.Server.Logic.Messages;
using TicketStore.Server.Logic.Messages.Requests;
using TicketStore.Server.Logic.Messages.Responses;

namespace TicketStore.Server.Logic.Test.Actors
{
    [TestFixture]
    public class WriteToDbActorTest : TestKit
    {
        [Test]
        public void Test1()
        {
            var writeToDbActor = Sys.ActorOf(Props.Create(() => new WriteToDbActor()));

            writeToDbActor.Tell(new AddEventToDbRequest() { });
            var result = ExpectMsg<AddEventToDbResponse>()?.Successful;

            result.Should().BeTrue();
        }
    }
}
