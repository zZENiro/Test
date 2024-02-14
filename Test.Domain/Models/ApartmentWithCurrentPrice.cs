namespace Test.Domain.Models
{
    public class ApartmentWithCurrentPrice
    {
        public long Id { get; set; }

        public decimal CurrentPrice { get; set; }

        public DateTime Date { get; set; }
    }
}
