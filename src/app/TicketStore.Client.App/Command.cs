using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.App
{
    /// <summary>
    /// Available commands.
    /// </summary>
    public enum Command
    {
        /// <summary>
        /// Initialize the client.
        /// </summary>
        Init,
        /// <summary>
        /// List all available commands.
        /// </summary>
        List,
        /// <summary>
        /// Create a new event.
        /// Requires admin permission.
        /// </summary>
        CreateEvent,
        /// <summary>
        /// Get sold tickets for an event.
        /// Requires admin permission.
        /// </summary>
        GetSoldTicketCount,
        /// <summary>
        /// Retrieve all available events.
        /// </summary>
        GetAllEvents,
        /// <summary>
        /// Get an event by id.
        /// </summary>
        GetEventById,
        /// <summary>
        /// Purchase tickets.
        /// </summary>
        PurchaseTickets,
        /// <summary>
        /// Get the remaining money units for ticket purchases for events in the current year.
        /// </summary>
        GetRemainingBudgetForCurrentYear,
        /// <summary>
        /// Get purchased tickets.
        /// </summary>
        GetPurchasedTickets
    }
}
