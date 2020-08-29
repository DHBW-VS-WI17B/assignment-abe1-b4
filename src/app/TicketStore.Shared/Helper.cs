using System;
using System.Threading;

namespace TicketStore.Shared
{
    /// <summary>
    /// Some helper methods.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Exit with success and wait in order to capture last log messages.
        /// </summary>
        public static void GracefulExitSuccess()
        {
            Thread.Sleep(200);
            Environment.Exit(0);
        }

        /// <summary>
        /// Exit with an error and wait in order to capture last log messages.
        /// </summary>
        public static void GracefulExitError()
        {
            Thread.Sleep(200);
            Environment.Exit(1);
        }
    }
}
