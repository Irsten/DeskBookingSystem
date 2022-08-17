using AutoMapper;
using DeskBookingSystem.Entities;
using DeskBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DeskBookingSystem.Services
{
    public class DeskService : IDeskService
    {
        private readonly DeskBookingDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeskService(DeskBookingDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DeskDto GetById(int id)
        {
            var desk = _dbContext
               .Desks
               .Include(d => d.Booking)
               .Include(d => d.Location)
               .FirstOrDefault(d => d.Id == id); ;

            if (desk == null) return null;

            var result = _mapper.Map<DeskDto>(desk);

            return result;
        }
        public bool Create(int employeeId, CreateDeskDto dto)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(e => e.Id == employeeId);

            var locationId = dto.LocationId;

            var location = _dbContext
                .Locations
                .FirstOrDefault(l => l.Id == locationId);

            if (employee == null) return false;
            if (location == null) return false;
            if (!dto.State.Equals(State.Available) && !dto.State.Equals(State.Unavailable)) return false;
            if (!employee.Role.Equals(Role.Administrator)) return false;

            var desk = _mapper.Map<Desk>(dto);
            _dbContext.Desks.Add(desk);
            _dbContext.SaveChanges();

            return true;
        }
        public bool Delete(int employeeId, int deskId)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(e => e.Id == employeeId);

            var desk = _dbContext
                .Desks
                .FirstOrDefault(d => d.Id == deskId);

            if (employee == null) return false;
            if (desk == null) return false;
            if (!employee.Role.Equals(Role.Administrator)) return false;
            if (desk.Booking != null) return false;

            _dbContext.Desks.Remove(desk);
            _dbContext.SaveChanges();

            return true;
        } 
        public bool Update(int employeeId, int deskId, UpdateDeskDto dto)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(e => e.Id == employeeId);

            var desk = _dbContext
               .Desks
               .FirstOrDefault(d => d.Id == deskId);
            
            if(employee == null) return false;
            if (desk == null) return false;
            if (!employee.Role.Equals(Role.Administrator)) return false;
            if (!dto.State.Equals(State.Available) && !dto.State.Equals(State.Unavailable)) return false;


            desk.State = dto.State;
            _dbContext.SaveChanges();

            return true;
        }

    }
}
