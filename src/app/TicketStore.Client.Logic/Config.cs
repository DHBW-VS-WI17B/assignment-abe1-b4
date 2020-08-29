using System;

namespace TicketStore.Client.Logic
{
    /// <summary>
    /// Config object to be stored on disk to persist the state of the client.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// User id of the client.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
