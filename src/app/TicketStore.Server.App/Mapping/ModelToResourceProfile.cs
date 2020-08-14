using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Server.App.Resources;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.App.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Event, EventResource>();
            CreateMap<Ticket, TicketResource>();
            CreateMap<User, UserResource>();
            CreateMap<PostalAddress, PostalAddressResource>();
        }
    }
}
