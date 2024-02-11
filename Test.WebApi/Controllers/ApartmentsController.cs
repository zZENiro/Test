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

        [HttpGet(nameof(GetApartmentWithCurrentPrice))]
        public async Task<IActionResult> GetApartmentWithCurrentPrice(long apartmentId)
        {
            return Ok(await _service.GetApartmentWithCurrentPrice(apartmentId));
        }

        [HttpGet(nameof(GetApartmentsByRoomsCount))]
        public async Task<IActionResult> GetApartmentsByRoomsCount(int roomsCount)
        {
            return Ok(await _service.GetApartmentsByRoomsCount(roomsCount));
        }

        [HttpGet(nameof(GetApartments))]
        public async Task<IActionResult> GetApartments()
        {
            return Ok(await _service.GetApartments());
        }

        [HttpGet(nameof(GetMonthsAverageApartmentPrice))]
        public async Task<IActionResult> GetMonthsAverageApartmentPrice(DateTime startDate, DateTime finishDate, long apartmentId)
        {
            return Ok(await _service.GetMonthsAverageApartmentPrice(startDate, finishDate, apartmentId));
        }
    }
}
