using DeskBookingSystem.Models;

namespace DeskBookingSystem.Services
{
    public interface ILocationService
    {
        int Create(CreateLocationDto dto);
        IEnumerable<LocationDto> GetAll();
        LocationDto GetById(int id);
    }
}