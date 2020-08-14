using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Resources
{
    public class PostalAddressResource
    {
        /// <summary>
        /// ZIP code of the address.
        /// </summary>
        [Required]
        public int ZipCode { get; set; }

        /// <summary>
        /// Name of the city.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string City { get; set; }

        /// <summary>
        /// Name of the street.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Street { get; set; }

        /// <summary>
        /// House number.
        /// </summary>
        [Required]
        public string HouseNumber { get; set; }
    }
}
