using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TicketStore.Client.Logic.Util
{
    public class JsonDataStore : IJsonDataStore
    {
        private readonly string _pathToJson;

        public JsonDataStore(string pathToJson)
        {
            _pathToJson = pathToJson;
        }

        public T Read<T>()
        {
            var jsonString = File.ReadAllText(_pathToJson);

            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public void Write<T>(T entity)
        {
            var jsonString = JsonSerializer.Serialize<T>(entity, new JsonSerializerOptions() { WriteIndented = true });

            File.WriteAllText(_pathToJson, jsonString);
        }
    }
}
