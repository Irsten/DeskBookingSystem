using DeskBookingSystem.Entities;
using DeskBookingSystem.Models;
using DeskBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskBookingSystem.Controllers
{
    [Route("api/desk")]
    public class DeskController : ControllerBase
    {
        private readonly IDeskService _deskService;
        public DeskController(IDeskService deskService)
        {
            _deskService = deskService;
        }

        [HttpPost("{employeeId}")]
        public ActionResult Create([FromRoute] int employeeId, [FromBody] CreateDeskDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isCreated = _deskService.Create(employeeId, dto);
            if (!isCreated) return NotFound();

            return Ok();
        }

        [HttpDelete("{employeeId}/{deskId}")]
        public ActionResult Delete([FromRoute] int employeeId, [FromRoute] int deskId)
        {
            var isDeleted = _deskService.Delete(employeeId, deskId);
            if (!isDeleted) return NotFound();
            return NoContent();
        }

        [HttpPut("{employeeId}/{deskId}")]
        public ActionResult Update([FromRoute] int employeeId, [FromRoute] int deskId, [FromBody] UpdateDeskDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isUpdated = _deskService.Update(employeeId, deskId, dto);
            if (!isUpdated) return NotFound();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<DeskDto> GetById([FromRoute] int id)
        {
            var desk = _deskService.GetById(id);

            if (desk is null)
            {
                return NotFound();
            }

            return Ok(desk);
        }
    }
}
