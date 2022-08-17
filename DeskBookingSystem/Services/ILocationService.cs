using DeskBookingSystem.Models;

namespace DeskBookingSystem.Services
{
    public interface ILocationService
    {
        bool Create(int employeeId, CreateLocationDto dto);
        bool Delete(int employeeId, int locationId);
        IEnumerable<LocationDto> GetAll();
        LocationDto GetById(int locationId);
    }
}