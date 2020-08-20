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
        public Guid? Id { get; }

        /// <summary>
        /// If the user is admin or not.
        /// </summary>
        public bool IsAdmin { get; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Address of the user.
        /// </summary>
        public AddressDto Address { get; }

        public UserDto(Guid id, bool isAdmin, string userName, AddressDto address)
        {
            Id = id;
            IsAdmin = isAdmin;
            UserName = userName;
            Address = address;
        }

        public UserDto(bool isAdmin, string userName, AddressDto address)
        {
            IsAdmin = isAdmin;
            UserName = userName;
            Address = address;
        }
    }
}
