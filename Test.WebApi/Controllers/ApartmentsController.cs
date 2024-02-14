using Microsoft.AspNetCore.Mvc;
using Test.Domain.Services;

namespace Test.WebApi.Controllers
{
    public class ApartmentsController : BaseController
    {
        private readonly ApartmentModuleService _service;

        public ApartmentsController(ApartmentModuleService service)
        {
            _service = service;
        }

        [HttpGet(nameof(GetApartments))]
        public async Task<IActionResult> GetApartments(
            [FromQuery] int? roomsCount = null,
            [FromQuery] bool withCurrentPrice = false)
        {
            return Ok(await _service.GetApartments(new GetApartmentsFilter()
            {
                RoomsCount = roomsCount,
                WithCurrentPrice = withCurrentPrice
            }));
        }

        [HttpGet(nameof(GetMonthsAverageApartmentPrice))]
        public async Task<IActionResult> GetMonthsAverageApartmentPrice(
            [FromQuery] int? roomsCount = null)
        {
            return Ok(await _service.GetMonthAverageApartmentsPrice(new GetApartmentsFilter()
            {
                RoomsCount = roomsCount
            }));
        }
    }
}
