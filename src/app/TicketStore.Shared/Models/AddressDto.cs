using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    public class AddressDto
    {
        /// <summary>
        /// ZIP code of the address.
        /// </summary>
        public string ZipCode { get; }

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

        public AddressDto(string zipCode, string city, string street, string houseNumber)
        {
            ZipCode = zipCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }
    }
}
