using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.App
{
    public enum Command
    {
        Init,
        List,
        CreateEvent,
        GetSoldTicketCount,
        GetAllEvents,
        GetEventById,
        PurchaseTicket
    }
}
