using System.Collections.Generic;
using System.Threading.Tasks;
using Desk_Booking_Application.Models;
using Desk_Booking_Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Desk_Booking_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskController : ControllerBase
    {
        private readonly IDeskService _deskService;

        public DeskController(IDeskService deskService)
        {
            _deskService = deskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desk>>> GetAllDesks()
        {
            var desks = await _deskService.GetAllDesksAsync();
            return Ok(desks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Desk>> GetDeskById(int id)
        {
            var desk = await _deskService.GetDeskByIdAsync(id);
            if (desk == null)
            {
                return NotFound();
            }
            return Ok(desk);
        }

        [HttpPost]
        public async Task<ActionResult<Desk>> AddDesk(Desk desk)
        {
            var addedDesk = await _deskService.AddDeskAsync(desk);
            return CreatedAtAction(nameof(GetDeskById), new { id = addedDesk.DeskId }, addedDesk);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDesk(int id, Desk desk)
        {
            if (id != desk.DeskId)
            {
                return BadRequest();
            }
            desk.Floor=null;
            await _deskService.UpdateDeskAsync(desk);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesk(int id)
        {
            await _deskService.DeleteDeskAsync(id);
            return NoContent();
        }

        [HttpGet("floor/{floorId}")]
        public async Task<ActionResult<IEnumerable<Desk>>> GetDesksByFloorId(int floorId)
        {
            var desks = await _deskService.GetDesksByFloorIdAsync(floorId);
            return Ok(desks);
        }
    }
}
