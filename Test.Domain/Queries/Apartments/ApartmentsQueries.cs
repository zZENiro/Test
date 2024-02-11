using Test.Core.Entities;

namespace Test.Domain.Queries.Apartments
{
    public static class ApartmentsQueries
    {
        /// <summary>
        /// Arguments: <c>roomsCount</c> of <see cref="int"/>
        /// </summary>
        public static string ApartmentsByRoomsCountQuery =>
            $"""
             SELECT * FROM {nameof(Apartment)} WHERE
                {nameof(Apartment.RoomsCount)} = @roomsCount;
             """;

        /// <summary>
        /// Arguments: <c>apartmentId</c> of <see cref="int"/>.
        /// </summary>
        public static string ApartmentWithCurrentPriceQuery =>
            $"""
             SELECT 
                h.{nameof(ApartmentPriceHistory.ApartmentId)} 
                ,h.{nameof(ApartmentPriceHistory.Date)}
                ,h.{nameof(ApartmentPriceHistory.Price)}
             FROM 
                (SELECT 
                    h1.{nameof(ApartmentPriceHistory.ApartmentId)} ap_id
                    ,MAX(h1.{nameof(ApartmentPriceHistory.Date)}) date 
                FROM {nameof(ApartmentPriceHistory)} h1 
                GROUP BY h1.{nameof(ApartmentPriceHistory.ApartmentId)}) t
             INNER JOIN {nameof(ApartmentPriceHistory)} h 
                ON t.ap_id = h.{nameof(ApartmentPriceHistory.ApartmentId)} AND 
                   t.date = h.{nameof(ApartmentPriceHistory.Date)}
             WHERE h.{nameof(ApartmentPriceHistory.ApartmentId)} = @apartmentId;
             """;

        public static string AllApartmentsQuery =>
            $"""
             SELECT * FROM {nameof(Apartment)}
             """;

        public static string AverageApartmentPriceForMonthQuery =>
            $"""
             SELECT
                aph.{nameof(ApartmentPriceHistory.ApartmentId)}
                ,DATEADD(MONTH, DATEDIFF(MONTH, 0, aph.{nameof(ApartmentPriceHistory.Date)}), 0) as Date
                ,AVG(aph.Price) Price
             FROM {nameof(ApartmentPriceHistory)} aph
             WHERE aph.{nameof(ApartmentPriceHistory.Date)} >= @startDate AND 
                    aph.{nameof(ApartmentPriceHistory.Date)} <= @finishDate AND
                    aph.{nameof(ApartmentPriceHistory.ApartmentId)} = @apartmentId
             GROUP BY aph.{nameof(ApartmentPriceHistory.ApartmentId)}, DATEADD(MONTH, DATEDIFF(MONTH, 0, aph.{nameof(ApartmentPriceHistory.Date)}), 0);
             """;
    }
}
