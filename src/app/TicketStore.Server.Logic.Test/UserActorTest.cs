using Akka.Actor;
using NUnit.Framework;

namespace TicketStore.Server.Logic.Test
{
    // https://petabridge.com/blog/how-to-unit-test-akkadotnet-actors-akka-testkit/
    [TestFixture]
    public class UserActorTest : Akka.TestKit.NUnit.TestKit
    {
        [Test]
        public void Test1()
        {
            var userActor = Sys.ActorOf(Props.Create(() => new UserActor()));
            userActor.Tell("msg");

            //var result = ExpectMsg<UserIdentityActor.OperationResult>().Successful;
            //Assert.True(result);
        }
    }
}