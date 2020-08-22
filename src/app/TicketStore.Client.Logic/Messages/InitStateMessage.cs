using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Client.Logic.Messages
{
    /// <summary>
    /// Immutable init state message.
    /// </summary>
    public class InitStateMessage
    {
        /// <summary>
        /// User to be created.
        /// </summary>
        public UserDto UserDto{ get; }

        /// <summary>
        /// Yearly budget.
        /// </summary>
        public double Budget { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userDto">User to be created.</param>
        /// <param name="budget">Yearly budget.</param>
        public InitStateMessage(UserDto userDto, double budget)
        {
            UserDto = userDto;
            Budget = budget;
        }
    }
}
