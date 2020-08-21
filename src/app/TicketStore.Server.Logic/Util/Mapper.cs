using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;
using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.Util
{
    public static class Mapper
    {
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

        public static User UserDtoToUser(UserDto userDto)
        {
            if (userDto == null) return null;

            return new User
            {
                Address = AddressDtoToAddress(userDto.Address),
                UserName = userDto.UserName
            };
        }

        public static AddressDto AddressToAddressDto(Address address)
        {
            if (address == null) return null;

            return new AddressDto(address.ZipCode, address.City, address.Street, address.HouseNumber);
        }

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

        public static TicketDto TicketToTicketDto(Ticket ticket)
        {
            if (ticket == null) return null;

            return new TicketDto(ticket.Id, ticket.PurchaseDate, ticket.EventId, ticket.UserId);
        }

        public static UserDto UserToUserDto(User user)
        {
            if (user == null) return null;

            return new UserDto(user.Id, user.UserName, AddressToAddressDto(user.Address));
        }
    }
}
