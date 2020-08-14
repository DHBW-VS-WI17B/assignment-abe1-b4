using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Server.App.Resources;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.App.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<EventResource, Event>();
            CreateMap<CreateEventResource, Event>();
            CreateMap<UpdateEventResource, Event>();
            CreateMap<TicketResource, Ticket>();
            CreateMap<UserResource, User>();
            CreateMap<CreateUserResource, User>();
            CreateMap<UpdateUserResource, User>();
            CreateMap<PostalAddressResource, PostalAddress>();
        }
    }
}
