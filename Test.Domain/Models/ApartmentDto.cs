using Microsoft.Identity.Client;

namespace Test.Domain.Models
{
    public class ApartmentDto
    {
        public long Id { get; set; }

        public decimal? CurrentPrice { get; set; }

        public DateTime? PriceUpdated { get; set; }

        public int RoomsCount { get; set; }

        public string Url { get; set; }
    }
}
