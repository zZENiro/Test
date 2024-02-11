using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Test.DataAccess.MSServer
{
    /// <inheritdoc />
    public class MSServerDataAccessProvider : IDataAccessProvider
    {
        private readonly MSServerDataAccessParams _parameters;

        public MSServerDataAccessProvider(MSServerDataAccessParams parameters)
        {
            _parameters = parameters;
        }

        /// <inheritdoc />
        public async Task ApplyQuery(string query, IDictionary<string, object> args)
        {
            await using var connection = new SqlConnection(_parameters.ConnectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = query;
            foreach (var arg in args)
            {
                command.Parameters.AddWithValue($"@{arg.Key}", arg.Value);
            }

            await command.ExecuteNonQueryAsync();
        }

        /// <inheritdoc />
        public async Task InsertEntity<T>(T entity) where T : class
        {
            await using var connection = new SqlConnection(_parameters.ConnectionString);
            await connection.OpenAsync();

            await connection.InsertAsync(entity);
        }

        /// <inheritdoc />
        public async Task UpdateEntity<T>(T entity) where T : class
        {
            await using var connection = new SqlConnection(_parameters.ConnectionString);
            await connection.OpenAsync();

            await connection.UpdateAsync(entity);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetEntities<T>(string query, IDictionary<string, object>? args = default) where T : class
        {
            await using var connection = new SqlConnection(_parameters.ConnectionString);
            await connection.OpenAsync();

            return await connection.QueryAsync<T>(new CommandDefinition(query, args));
        }
    }
}
