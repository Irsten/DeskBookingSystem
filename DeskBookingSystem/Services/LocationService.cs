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

        public LocationDto GetById(int locationId)
        {
            var location = _dbContext
                .Locations
                .Include(l => l.Desks)
                .FirstOrDefault(l => l.Id == locationId);

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

        public bool Create(int employeeId, CreateLocationDto dto)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(r => r.Id == employeeId);

            if (employee == null) return false;
            if (!employee.Role.Equals(Role.Administrator)) return false;
            if (dto == null) return false;

            var location = _mapper.Map<Location>(dto);
            _dbContext.Locations.Add(location);
            _dbContext.SaveChanges();

            return true;
        }
        public bool Delete(int employeeId, int locationId)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(r => r.Id == employeeId);

            var location = _dbContext
                .Locations
                .FirstOrDefault(r => r.Id == locationId);

            if (employee == null) return false;
            if (!employee.Role.Equals(Role.Administrator)) return false;
            if (location == null) return false;
            if (location.Desks != null) return false;

            _dbContext.Locations.Remove(location);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
