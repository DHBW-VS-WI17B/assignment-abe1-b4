using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// User model.
    /// </summary>
    public sealed class User
    {
        /// <summary>
        /// User id.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Name of the user.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Password of the user.
        /// We are aware that unhashed passwords are bad practice.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Is admin.
        /// </summary>
        public bool IsAdmin { get; }

        /// <summary>
        /// Postal address of the user.
        /// </summary>
        public Address Address { get; }

        /// <summary>
        /// Constrcutor.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="isAdmin">Is admin.</param>
        /// <param name="address">Address.</param>
        public User(string userName, string password, bool isAdmin, Address address)
        {
            UserName = userName;
            Password = password;
            IsAdmin = isAdmin;
            Address = address;
        }
    }
}
