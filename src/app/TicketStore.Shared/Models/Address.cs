using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// Postal address.
    /// </summary>
    public sealed class Address
    {
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
        /// Constructor.
        /// </summary>
        /// <param name="zipCode">ZIP code.</param>
        /// <param name="city">Name of the city.</param>
        /// <param name="street">Name of the street.</param>
        /// <param name="houseNumber">Housenumber.</param>
        public Address(int zipCode, string city, string street, string houseNumber)
        {
            ZipCode = zipCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }
    }
}