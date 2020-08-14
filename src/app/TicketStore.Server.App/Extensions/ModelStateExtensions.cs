using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace TicketStore.Server.App.Extensions
{
    /// <summary>
    /// Model state extensions.
    /// </summary>
    public static class ModelStateExtensions
    {
        /// <summary>
        /// Gets model validation error messages.
        /// </summary>
        /// <param name="dictionary">Internal dictionary.</param>
        /// <returns>Error list.</returns>
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }
    }
}
