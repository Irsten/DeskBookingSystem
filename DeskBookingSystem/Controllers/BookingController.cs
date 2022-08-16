using AutoMapper;
using DeskBookingSystem.Entities;
using DeskBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeskBookingSystem.Controllers
{
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly DeskBookingDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookingController(DeskBookingDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingDto>> GetAll()
        {
            var bookings = _dbContext
                .Bookings
                .Include(b => b.Desk)
                .Include(b => b.Employee)
                .ToList();

            var bookingsDto = _mapper.Map<List<BookingDto>>(bookings);

            return Ok(bookingsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<BookingDto> Get([FromRoute] int id)
        {
            var booking = _dbContext
                .Bookings
                .Include(b => b.Desk)
                .Include(b => b.Employee)
                .FirstOrDefault(r => r.Id == id); ;

            if (booking is null)
            {
                return NotFound();
            }

            var bookingDto = _mapper.Map<BookingDto>(booking);

            return Ok(bookingDto);
        }
    }
}
