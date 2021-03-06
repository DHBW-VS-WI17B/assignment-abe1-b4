﻿using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.DataAccess.Contracts
{
    /// <summary>
    /// Event repository.
    /// </summary>
    public interface IEventRepository : IRepositoryBase<Event>
    {
    }
}
