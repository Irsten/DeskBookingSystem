using DeskBookingSystem.Models;

namespace DeskBookingSystem.Services
{
    public interface IDeskService
    {
        bool Create(int employeeId, CreateDeskDto dto);
        bool Delete(int employeeId, int deskId);
        bool Update(int employeeId, int deskId, UpdateDeskDto dto);
        DeskDto GetById(int id);
    }
}