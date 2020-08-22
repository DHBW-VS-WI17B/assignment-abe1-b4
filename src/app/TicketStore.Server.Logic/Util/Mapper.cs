using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;
using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.Util
{
    /// <summary>
    /// Maps data transfer objects to domain entities and vice versa.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Maps an address data transfer object to an address entity.
        /// </summary>
        /// <param name="addressDto">Address data transfer object.</param>
        /// <returns>Address entity.</returns>
        public static Address AddressDtoToAddress(AddressDto addressDto)
        {
            if (addressDto == null) return null;

            return new Address
            {
                City = addressDto.City,
                HouseNumber = addressDto.HouseNumber,
                Street = addressDto.Street,
                ZipCode = addressDto.ZipCode
            };
        }

        /// <summary>
        /// Maps an event data transfer object to an event entity.
        /// </summary>
        /// <param name="eventDto">Event data transfer object.</param>
        /// <returns>Event entity.</returns>
        public static Event EventDtoToEvent(EventDto eventDto)
        {
            if (eventDto == null) return null;

            return new Event
            {
                Date = eventDto.Date,
                Location = eventDto.Location,
                MaxTicketCount = eventDto.MaxTicketCount,
                MaxTicketsPerUser = eventDto.MaxTicketsPerUser,
                Name = eventDto.Name,
                PricePerTicket = eventDto.PricePerTicket,
                SaleEndDate = eventDto.SaleEndDate,
                SaleStartDate = eventDto.SaleStartDate
            };
        }

        /// <summary>
        /// Maps an ticket data transfer object to a ticket entity.
        /// </summary>
        /// <param name="ticketDto">Ticket data transfer object.</param>
        /// <returns>Ticket entity.</returns>
        public static Ticket TicketDtoToTicket(TicketDto ticketDto)
        {
            if (ticketDto == null) return null;

            return new Ticket
            {
                EventId = ticketDto.EventId,
                PurchaseDate = ticketDto.PurchaseDate,
                UserId = ticketDto.UserId
            };
        }

        /// <summary>
        /// Maps an user data transfer object to an user entity.
        /// </summary>
        /// <param name="userDto">User data transfer object.</param>
        /// <returns>User entity.</returns>
        public static User UserDtoToUser(UserDto userDto)
        {
            if (userDto == null) return null;

            return new User
            {
                Address = AddressDtoToAddress(userDto.Address),
                UserName = userDto.UserName
            };
        }

        /// <summary>
        /// Maps an address entity to an address data transfer object.
        /// </summary>
        /// <param name="address">Address entity.</param>
        /// <returns>Address data transfer object.</returns>
        public static AddressDto AddressToAddressDto(Address address)
        {
            if (address == null) return null;

            return new AddressDto(address.ZipCode, address.City, address.Street, address.HouseNumber);
        }

        /// <summary>
        /// Maps an event entity to an event data transfer object.
        /// </summary>
        /// <param name="event">Event entity.</param>
        /// <returns>Event data transfer object.</returns>
        public static EventDto EventToEventDto(Event @event)
        {
            if (@event == null) return null;

            return new EventDto(
                @event.Id,
                @event.Name,
                @event.Date,
                @event.Location,
                @event.PricePerTicket,
                @event.MaxTicketCount,
                @event.MaxTicketsPerUser,
                @event.SaleStartDate,
                @event.SaleEndDate
            );
        }

        /// <summary>
        /// Maps a ticket entity to a ticket event data transfer object.
        /// </summary>
        /// <param name="ticket">Ticket entity.</param>
        /// <returns>Ticket data transfer object.</returns>
        public static TicketDto TicketToTicketDto(Ticket ticket)
        {
            if (ticket == null) return null;

            return new TicketDto(ticket.Id, ticket.PurchaseDate, ticket.EventId, ticket.UserId);
        }

        /// <summary>
        /// Maps an user entity to an user data transfer object.
        /// </summary>
        /// <param name="user">User entity.</param>
        /// <returns>User data transfer object.</returns>
        public static UserDto UserToUserDto(User user)
        {
            if (user == null) return null;

            return new UserDto(user.Id, user.UserName, AddressToAddressDto(user.Address));
        }
    }
}
