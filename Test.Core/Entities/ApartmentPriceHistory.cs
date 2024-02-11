using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core.Entities
{
    /// <summary>
    /// Apartment price history.
    /// </summary>
    public class ApartmentPriceHistory : BaseEntity
    {
        /// <summary>
        /// Apartment ID.
        /// </summary>
        public long ApartmentId { get; set; }

        /// <summary>
        /// Price of apartment for specific date.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Date of price update.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
