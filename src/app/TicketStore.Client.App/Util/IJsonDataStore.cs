using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.App.Util
{
    public interface IJsonDataStore
    {
        T Read<T>();

        void Write<T>(T entity);
    }
}
