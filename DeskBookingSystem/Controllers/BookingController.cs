using DeskBookingSystem.Models;
using DeskBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskBookingSystem.Controllers
{
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingDto>> GetAll()
        {
            var bookings = _bookingService.GetAll();

            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public ActionResult<BookingDto> GetById([FromRoute] int id)
        {
            var booking = _bookingService.GetById(id);
            if (booking is null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateBookingDto dto)
        {
            var isCreated = _bookingService.Create(dto);
            if (!isCreated) return NotFound();

            return Ok();
        }
        [HttpPut("{employeeId}/{deskId}")]
        public ActionResult Change([FromRoute] int employeeId, [FromRoute] int deskId, [FromBody] CreateBookingDto dto)
        {
            var isChanged = _bookingService.Change(employeeId, deskId, dto);
            if (!isChanged) return NotFound();

            return Ok();
        }
    }
}
