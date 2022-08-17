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

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<BookingDto>> GetAll()
        {
            var bookings = _bookingService.GetAll();

            return Ok(bookings);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<BookingDto> GetById([FromRoute] int id)
        {
            var booking = _bookingService.GetById(id);
            if (booking is null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] CreateBookingDto dto)
        {
            var isCreated = _bookingService.Create(dto);
            if (!isCreated) return NotFound();

            return Ok();
        }
        [HttpPut("Change/{employeeId}/{currentDeskId}")]
        public ActionResult Change([FromRoute] int employeeId, [FromRoute] int currentDeskId, [FromBody] CreateBookingDto dto)
        {
            var isChanged = _bookingService.Change(employeeId, currentDeskId, dto);
            if (!isChanged) return NotFound();

            return Ok();
        }
    }
}
