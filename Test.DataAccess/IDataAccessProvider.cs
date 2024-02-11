namespace Test.DataAccess
{
    /// <summary>
    /// DA provider.
    /// </summary>
    public interface IDataAccessProvider
    {
        /// <summary>
        /// Applies query to database with specified arguments.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <param name="args">Arguments.</param>
        /// <returns></returns>
        Task ApplyQuery(string query, IDictionary<string, object> args);

        /// <summary>
        /// Inserts entity. 
        /// </summary>
        /// <typeparam name="T">Inserting entity.</typeparam>
        /// <returns></returns>
        Task InsertEntity<T>(T entity) where T : class;

        /// <summary>
        /// Updates entity.
        /// </summary>
        /// <typeparam name="T">Updating entity.</typeparam>
        /// <returns></returns>
        Task UpdateEntity<T>(T entity) where T : class;

        /// <summary>
        /// Applies select query with specified arguments.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <param name="args">Arguments.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetEntities<T>(string query, IDictionary<string, object> args) where T : class;
    }
}
