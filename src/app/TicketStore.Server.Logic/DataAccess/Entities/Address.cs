using System;
using System.ComponentModel.DataAnnotations;

namespace TicketStore.Server.Logic.DataAccess.Entities
{
    /// <summary>
    /// Postal address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Postal address id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// ZIP code of the address.
        /// </summary>
        [Required]
        public string ZipCode { get; set; }

        /// <summary>
        /// Name of the city.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Name of the street.
        /// </summary>
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// House number.
        /// </summary>
        [Required]
        public string HouseNumber { get; set; }


        /// <summary>
        /// User id foreign key.
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// User reference.
        /// </summary>
        [Required]
        public User User { get; set; }
    }
}
