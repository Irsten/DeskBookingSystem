using DeskBookingSystem.Models;
using DeskBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;


namespace DeskBookingSystem.Controllers
{
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LocationDto>> GetAll()
        {
            var locationsDtos = _locationService.GetAll();

            return Ok(locationsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<LocationDto> GetById([FromRoute] int id)
        {
            var location = _locationService.GetById(id);
            if (location is null) return NotFound();

            return Ok(location);
        }
        [HttpPost("{employeeId}")]
        public ActionResult Create([FromRoute] int employeeId, [FromBody] CreateLocationDto dto)
        {
            var isCreated = _locationService.Create(employeeId, dto);
            if (!isCreated) return NotFound();

            return Ok();
        }

        [HttpDelete("{employeeId}/{locationId}")]
        public ActionResult Delete([FromRoute] int employeeId, [FromRoute] int locationId)
        {
            var isDeleted = _locationService.Delete(employeeId, locationId);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
