using AutoMapper;
using DeskBookingSystem.Entities;
using DeskBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DeskBookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly DeskBookingDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookingService(DeskBookingDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookingDto GetById(int bookingId)
        {
            var booking = _dbContext
                .Bookings
                .Include(l => l.Desk)
                .Include(l => l.Employee)
                .FirstOrDefault(b => b.Id == bookingId);

            if (booking == null) return null;

            var result = _mapper.Map<BookingDto>(booking);
            return result;
        }

        public IEnumerable<BookingDto> GetAll()
        {
            var bookings = _dbContext
                .Bookings
                .Include(l => l.Desk)
                .Include(l => l.Employee)
                .ToList();

            var bookingsDtos = _mapper.Map<List<BookingDto>>(bookings);

            return bookingsDtos;
        }

        public bool Create(CreateBookingDto dto)
        {
            int days;
            var desk = _dbContext
                .Desks
                .FirstOrDefault(d => d.Id == dto.DeskId);

            if (desk == null) return false;
            if (desk.State.Equals(State.Unavailable)) return false;
            if (dto.BookingEndDate < dto.BookingStartDate) return false;
            if (dto.BookingEndDate == dto.BookingStartDate)
            {
                days = 1;
            }
            else
            {
                days = (dto.BookingEndDate - dto.BookingStartDate).Days;
            }
            if (days > 7) return false;

            var booking = _mapper.Map<Booking>(dto);
            _dbContext.Bookings.Add(booking);
            booking.Desk.State = State.Unavailable;
            _dbContext.SaveChanges();

            return true;
        }
        public bool Change(int employeeId, int currentDeskId, CreateBookingDto dto)
        {
            var employee = _dbContext
                .Employees
                .Include(e => e.Booking)
                .FirstOrDefault(e => e.Id == employeeId);

            var currentBooking = _dbContext
                .Bookings
                .Include(d => d.Employee)
                .FirstOrDefault(b => b.DeskId == currentDeskId);

            var currentDesk = _dbContext
                .Desks
                .FirstOrDefault(d => d.Id == currentDeskId);

            var newDesk = _dbContext
                .Desks
                .FirstOrDefault(d => d.Id == dto.DeskId);

            int days;
            double hours = (dto.BookingStartDate - DateTime.Now).TotalHours;
            if (currentDesk == null) return false;
            if (currentBooking == null) return false;
            if (employee.Id == currentBooking.Employee.Id) return false;
            if (hours < 24) return false;
            if (newDesk.State.Equals(State.Unavailable)) return false;
            if (dto.BookingEndDate < dto.BookingStartDate) return false;
            if (dto.BookingEndDate == null)
            {
                days = 1;
            }
            else
            {
                days = (dto.BookingEndDate - dto.BookingStartDate).Days;
            }
            if (days > 7) return false;

            var booking = _mapper.Map<Booking>(dto);
            _dbContext.Bookings.Add(booking);
            _dbContext.Bookings.Remove(currentBooking);
            currentDesk.State = State.Available;
            newDesk.State = State.Unavailable;
            _dbContext.SaveChanges();

            return true;
        }
    }
}
