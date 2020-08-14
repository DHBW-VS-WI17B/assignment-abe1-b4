using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Server.App.Resources;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.App.Mapping
{
    /// <summary>
    /// Resource to model mapping profile.
    /// </summary>
    public class ResourceToModelProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
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
