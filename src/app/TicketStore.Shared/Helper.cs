using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicketStore.Shared
{
    public static class Helper
    {
        public static void GracefulExitSuccess()
        {
            Thread.Sleep(200);
            Environment.Exit(0);
        }

        public static void GracefulExitError()
        {
            Thread.Sleep(200);
            Environment.Exit(1);
        }
    }
}
