namespace Test.DataAccess
{
    /// <summary>
    /// DA provider factory.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataAccessProviderFactory<T> where T : IDataAccessProvider
    {
        /// <summary>
        /// Initialises and returns data access provider of type <see cref="IDataAccessProvider"/>
        /// </summary>
        /// <returns></returns>
        T CreateDataAccessProvider();
    }
}
