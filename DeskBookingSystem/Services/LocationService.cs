using AutoMapper;
using DeskBookingSystem.Entities;
using DeskBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeskBookingSystem.Services
{
    public class LocationService : ILocationService
    {
        private readonly DeskBookingDbContext _dbContext;
        private readonly IMapper _mapper;
        public LocationService(DeskBookingDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public LocationDto GetById(int id)
        {
            var location = _dbContext
                .Locations
                .Include(l => l.Desks)
                .FirstOrDefault(r => r.Id == id);

            if (location == null) return null;

            var result = _mapper.Map<LocationDto>(location);
            return result;
        }

        public IEnumerable<LocationDto> GetAll()
        {
            var locations = _dbContext
                .Locations
                .Include(l => l.Desks)
                .ToList();

            var locationsDtos = _mapper.Map<List<LocationDto>>(locations);

            return locationsDtos;
        }

        public int Create(CreateLocationDto dto)
        {
                    var location = _mapper.Map<Location>(dto);
                    _dbContext.Locations.Add(location);
                    _dbContext.SaveChanges();

                    return location.Id;
        }
        public bool Delete(int id)
        {
            var location = _dbContext
                .Locations
                .FirstOrDefault(r => r.Id == id);

            if (location == null) return false;

            _dbContext.Locations.Remove(location);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
