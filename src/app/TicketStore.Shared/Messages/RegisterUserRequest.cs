using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public sealed class RegisterUserRequest
    {
        /// <summary>
        /// Name of the user.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Is admin.
        /// </summary>
        public bool IsAdmin { get; }

        /// <summary>
        /// ZIP code of the address.
        /// </summary>
        public int ZipCode { get; }

        /// <summary>
        /// Name of the city.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Name of the street.
        /// </summary>

        public string Street { get; }

        /// <summary>
        /// House number.
        /// </summary>
        public string HouseNumber { get; }

        /// <summary>
        /// Register user request.
        /// </summary>
        /// <param name="userName">Name of ther user.</param>
        /// <param name="isAdmin">Is admin.</param>
        /// <param name="zipCode">ZIP code.</param>
        /// <param name="city">Name of the city.</param>
        /// <param name="street">Name of the street.</param>
        /// <param name="houseNumber">House number.</param>
        public RegisterUserRequest(string userName, bool isAdmin, int zipCode, string city, string street, string houseNumber)
        {
            UserName = userName;
            IsAdmin = isAdmin;
            ZipCode = zipCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;      
        }
    }
}
