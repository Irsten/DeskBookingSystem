using AutoMapper;
using DeskBookingSystem.Entities;
using DeskBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeskBookingSystem.Controllers
{
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        private readonly DeskBookingDbContext _dbContext;
        private readonly IMapper _mapper;
        public LocationController(DeskBookingDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateLocation([FromBody] CreateLocationDto dto)
        {
            var location = _mapper.Map<Location>(dto);
            _dbContext.Locations.Add(location);
            _dbContext.SaveChanges();

            return Created($"api/location/{location.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<LocationDto>> GetAll()
        {
            var locations = _dbContext
                .Locations
                .Include(l => l.Desks)
                .ToList();

            var locationsDtos = _mapper.Map<List<LocationDto>>(locations);

            return Ok(locationsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<LocationDto> Get([FromRoute] int id)
        {
            var location = _dbContext
                .Locations
                .Include(l => l.Desks)
                .FirstOrDefault(r => r.Id == id);

            if (location is null)
            {
                return NotFound();
            }

            var locationDto = _mapper.Map<LocationDto>(location);
            return Ok(locationDto);
        }
    }
}
