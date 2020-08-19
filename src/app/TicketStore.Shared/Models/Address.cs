using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// Postal address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// ZIP code of the address.
        /// </summary>
        public int ZipCode { get; set; }

        /// <summary>
        /// Name of the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Name of the street.
        /// </summary>
   
        public string Street { get; set; }

        /// <summary>
        /// House number.
        /// </summary>
        public string HouseNumber { get; set; }
    }
}