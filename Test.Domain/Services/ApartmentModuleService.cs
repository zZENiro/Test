using System.Text;
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
        /// Get apartments by filter.
        /// </summary>
        /// <param name="filter">Apartments filter.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ApartmentDto>> GetApartments(GetApartmentsFilter filter)
        {
            var dataAccess = _daFactory.CreateDataAccessProvider();

            var query = new StringBuilder(ApartmentsQueries.AllApartmentsQuery);
            var queryArguments = new Dictionary<string, object>();

            if (filter.RoomsCount != null)
            {
                query.Append(ApartmentsQueries.ColumnFilters.RoomsCountFilter);
                queryArguments.Add("roomsCount", filter.RoomsCount);
            }

            var apartments = 
                (await dataAccess.GetEntities<Apartment>(query.ToString(), queryArguments))
                .Select(x => new ApartmentDto()
                {
                    Id = x.Id,
                    RoomsCount = x.RoomsCount,
                    Url = x.Url
                }).ToList();

            if (filter.WithCurrentPrice)
            {
                var apartmentsWithCurrentPrice = await GetApartmentsWithCurrentPrice(apartments.Select(x => x.Id).ToArray());

                apartments = apartments.Join(apartmentsWithCurrentPrice, a => a.Id, awc => awc.Id,
                    (c, awc) => new ApartmentDto()
                    {
                        Id = c.Id,
                        RoomsCount = c.RoomsCount,
                        Url = c.Url,
                        CurrentPrice = awc.CurrentPrice,
                        PriceUpdated = awc.Date
                    }).ToList();
            }

            return apartments;
        }

        /// <summary>
        /// Get month average apartments price.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AverageApartmentsMonthPrice>> GetMonthAverageApartmentsPrice(GetApartmentsFilter filter)
        {
            var apartments = await GetApartments(filter);

            var dataAccess = _daFactory.CreateDataAccessProvider();

            return await dataAccess.GetEntities<AverageApartmentsMonthPrice>(ApartmentsQueries.AverageApartmentsPriceForMonthQuery, new Dictionary<string, object>()
            {
                {"apartmentsIds", apartments.Select(a => a.Id).ToArray()}
            });
        }

        /// <summary>
        /// Get specified apartment with current price.
        /// </summary>
        /// <param name="apartmentsIds">Apartments IDs.</param>
        /// <returns></returns>
        private async Task<IEnumerable<ApartmentWithCurrentPrice>> GetApartmentsWithCurrentPrice(long[] apartmentsIds)
        {
            var dataAccess = _daFactory.CreateDataAccessProvider();

            return (await dataAccess.GetEntities<ApartmentPriceHistory>(ApartmentsQueries.ApartmentsWithCurrentPriceQuery,
                    new Dictionary<string, object>()
                    {
                        { "apartmentsIds", apartmentsIds }
                    }))
                .Select(x => new ApartmentWithCurrentPrice()
                {
                    Id = x.ApartmentId,
                    CurrentPrice = x.Price,
                    Date = x.Date
                }).ToList();
        }
    }
}
