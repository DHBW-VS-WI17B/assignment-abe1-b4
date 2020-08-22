using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
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

        public UserDto(Guid id, string userName, AddressDto address)
        {
            Id = id;
            UserName = userName;
            Address = address;
        }
    }
}
