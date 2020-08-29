namespace TicketStore.Client.Logic.Util
{
    /// <summary>
    /// Read or write an object to a file.
    /// </summary>
    public interface IJsonDataStore
    {
        /// <summary>
        /// Read an object from a file.
        /// </summary>
        /// <typeparam name="T">Typo of the object.</typeparam>
        /// <returns>Object.</returns>
        T Read<T>();

        /// <summary>
        /// Write an object to a file.
        /// </summary>
        /// <typeparam name="T">Typo of the object.</typeparam>
        /// <param name="entity">The object.</param>
        void Write<T>(T entity);
    }
}
