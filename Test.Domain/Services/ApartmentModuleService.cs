using Test.Core.Entities;
using Test.DataAccess;
using Test.DataAccess.MSServer;
using Test.Domain.Models;
using Test.Domain.Queries.Apartments;

namespace Test.Domain.Services
{
    public class ApartmentModuleService : IModuleService
    {
        private readonly IDataAccessProviderFactory<MSServerDataAccessProvider> _daFactory;

        public ApartmentModuleService(IDataAccessProviderFactory<MSServerDataAccessProvider> daFactory)
        {
            _daFactory = daFactory;
        }

        /// <summary>
        /// Get apartments filtered by rooms count.
        /// </summary>
        /// <param name="roomsCount">Rooms count.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Apartment>> GetApartmentsByRoomsCount(int roomsCount)
        {
            var dataAccess = _daFactory.CreateDataAccessProvider();

            return await dataAccess.GetEntities<Apartment>(ApartmentsQueries.ApartmentsByRoomsCountQuery,
                new Dictionary<string, object>()
                {
                    { "roomsCount", roomsCount }
                });
        }

        /// <summary>
        /// Get specified apartment with current price.
        /// </summary>
        /// <param name="apartmentId">Apartment ID.</param>
        /// <returns></returns>
        public async Task<ApartmentPriceHistory> GetApartmentWithCurrentPrice(long apartmentId)
        {
            var dataAccess = _daFactory.CreateDataAccessProvider();

            return (await dataAccess.GetEntities<ApartmentPriceHistory>(ApartmentsQueries.ApartmentWithCurrentPriceQuery,
                new Dictionary<string, object>()
                {
                    { "apartmentId", apartmentId }
                })).SingleOrDefault();
        }

        /// <summary>
        /// Get all apartments.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Apartment>> GetApartments()
        {
            var dataAccess = _daFactory.CreateDataAccessProvider();

            return await dataAccess.GetEntities<Apartment>(ApartmentsQueries.AllApartmentsQuery);
        }

        public async Task<IEnumerable<AverageApartmentPrice>> GetMonthsAverageApartmentPrice(DateTime startDate, DateTime finishDate, long apartmentId)
        {
            var dataAccess = _daFactory.CreateDataAccessProvider();

            return await dataAccess.GetEntities<AverageApartmentPrice>(ApartmentsQueries.AverageApartmentPriceForMonthQuery, new Dictionary<string, object>()
            {
                {"startDate", startDate},
                {"finishDate", finishDate},
                {"apartmentId", apartmentId}
            });
        }
    }
}
