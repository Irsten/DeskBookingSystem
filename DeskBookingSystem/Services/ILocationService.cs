using DeskBookingSystem.Models;

namespace DeskBookingSystem.Services
{
    public interface ILocationService
    {
        int Create(CreateLocationDto dto);
        bool Delete(int id);
        IEnumerable<LocationDto> GetAll();
        LocationDto GetById(int id);
    }
}