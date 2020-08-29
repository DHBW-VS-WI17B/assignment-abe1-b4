using System.IO;
using System.Text.Json;

namespace TicketStore.Client.Logic.Util
{
    /// <summary>
    /// Json data store implementation.
    /// </summary>
    public class JsonDataStore : IJsonDataStore
    {
        private readonly string _pathToJson;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pathToJson">Path to a writable file.</param>
        public JsonDataStore(string pathToJson)
        {
            _pathToJson = pathToJson;
        }


        /// <inheritdoc/>
        public T Read<T>()
        {
            var jsonString = File.ReadAllText(_pathToJson);

            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <inheritdoc/>
        public void Write<T>(T entity)
        {
            var jsonString = JsonSerializer.Serialize<T>(entity, new JsonSerializerOptions() { WriteIndented = true });

            File.WriteAllText(_pathToJson, jsonString);
        }
    }
}
