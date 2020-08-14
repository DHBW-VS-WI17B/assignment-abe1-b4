using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace TicketStore.Server.App.Misc
{
    /// <summary>
    /// Slugify parameter transformer.
    /// </summary>
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        /// <summary>
        /// Transform outbound values.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>Sulgified value.</returns>
        public string TransformOutbound(object value)
        {
            return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
