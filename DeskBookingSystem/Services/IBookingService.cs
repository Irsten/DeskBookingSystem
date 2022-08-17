using DeskBookingSystem.Models;

namespace DeskBookingSystem.Services
{
    public interface IBookingService
    {
        bool Change(int employeeId, int currentDeskId, CreateBookingDto dto);
        bool Create(CreateBookingDto dto);
        IEnumerable<BookingDto> GetAll();
        BookingDto GetById(int bookingId);
    }
}