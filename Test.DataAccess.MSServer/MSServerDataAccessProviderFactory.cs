using Microsoft.Extensions.Configuration;

namespace Test.DataAccess.MSServer
{
    /// <inheritdoc />
    public class MSServerDataAccessProviderFactory : IDataAccessProviderFactory<MSServerDataAccessProvider>
    {
        private readonly IConfiguration _configuration;

        public MSServerDataAccessProviderFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public MSServerDataAccessProvider CreateDataAccessProvider() =>
            new MSServerDataAccessProvider(new MSServerDataAccessParams
            {
                ConnectionString = _configuration.GetConnectionString("DbConnection") ?? string.Empty
            });
    }
}
