using Test.Core.Entities;
using Test.DataAccess.MSServer;
using Test.Domain.Queries.Apartments;

var provder = new MSServerDataAccessProvider(new MSServerDataAccessParams
{
    ConnectionString =
        "Data Source=ZEN\\SQLEXPRESS;User=ZEN\\soloi;TrustServerCertificate=true;Integrated Security=true;Database=TestTask"
});

var res = await provder.GetEntities<Apartment>("select * from Apartment where id = @id", new Dictionary<string, object>()
{
    {"id", 1}
});

var query = ApartmentsQueries.GetApartmentsByRoomsCountQuery(1);

Console.WriteLine();
