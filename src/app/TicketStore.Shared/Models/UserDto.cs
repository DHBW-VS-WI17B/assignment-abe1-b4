using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// User data tranfer object.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Address of the user.
        /// </summary>
        public AddressDto Address { get; }

        /// <summary>
        /// Yearly budget of money units for ticket purchases (for events in the same year).
        /// </summary>
        public double YearlyBudget { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="userName">User name.</param>
        /// <param name="address">Address of the user.</param>
        public UserDto(Guid id, string userName, AddressDto address, double yearlyBudget)
        {
            Id = id;
            UserName = userName;
            Address = address;
            YearlyBudget = yearlyBudget;
        }
    }
}
