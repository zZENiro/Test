namespace Test.Domain.Services
{
    public class GetApartmentsFilter
    {
        public int? RoomsCount { get; set; }

        public bool WithCurrentPrice { get; set; } = false;
    }
}
