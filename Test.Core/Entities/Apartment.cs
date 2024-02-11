namespace Test.Core.Entities
{
    /// <summary>
    /// Apartment entity.
    /// </summary>
    public class Apartment : BaseEntity
    {
        /// <summary>
        /// Rooms count.
        /// </summary>
        public int RoomsCount { get; set; }

        /// <summary>
        /// Link to website.
        /// </summary>
        public string Url { get; set; }
    }
}
