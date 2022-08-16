using AutoMapper;
using DeskBookingSystem.Entities;
using DeskBookingSystem.Models;
using DeskBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeskBookingSystem.Controllers
{
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        private readonly DeskBookingDbContext _dbContext;
        private readonly ILocationService _locationService;
        public LocationController(DeskBookingDbContext dbContext, ILocationService locationService)
        {
            _dbContext = dbContext;
            _locationService = locationService;
        }

        [HttpPost("{employeeId}")]
        public ActionResult CreateLocation([FromRoute] int employeeId, [FromBody] CreateLocationDto dto)
        {
            Employee employee = _dbContext.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee != null)
            {
                if (employee.Role == Entities.Role.Administrator)
                {
                    var id = _locationService.Create(dto);

                    return Created($"api/location/{id}", null);
                }
            }

            return Unauthorized();
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

            if (location is null)
            {
                return NotFound();
            }

            return Ok(location);
        }
    }
}
