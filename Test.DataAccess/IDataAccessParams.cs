namespace Test.DataAccess
{
    /// <summary>
    /// Data access parameters.
    /// </summary>
    public interface IDataAccessParams
    {
        /// <summary>
        /// Connection string.
        /// </summary>
        string ConnectionString { get; }
    }
}
