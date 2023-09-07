using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portal.Models.Leave;
using portal.Services;

namespace portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    

        {
            private readonly LeaveService _leaveService;

            public LeaveController(LeaveService leaveService)
            {
                _leaveService = leaveService;
            }

            [HttpGet]
            public IActionResult GetLeaves()
            {
                List<Leave> leaves = _leaveService.GetLeaves();
                return Ok(leaves);
            }

            [HttpGet("{id}")]
            public IActionResult GetLeaveById(int id)
            {
                Leave leave = _leaveService.GetLeaveById(id);
                if (leave == null)
                {
                    return NotFound();
                }
                return Ok(leave);
            }

            [HttpPost]
            public IActionResult CreateLeave([FromBody] Leave leave)
            {
                if (leave == null)
                {
                    return BadRequest();
                }

                leave.DateFrom = DateTime.Now; // Set the DateFrom to the current date

                _leaveService.CreateLeave(leave);
                return CreatedAtAction(nameof(GetLeaveById), new { id = leave.LeaveId }, leave);
            }

            [HttpPut("{id}")]
            public IActionResult EditLeave(int id, [FromBody] Leave leave)
            {
                if (leave == null)
                {
                    return BadRequest();
                }

                int result = _leaveService.EditLeave(id, leave);
                if (result == 0)
                {
                    return NoContent();
                }
                return NotFound();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteLeave(int id)
            {
                int result = _leaveService.DeleteLeave(id);
                if (result == 0)
                {
                    return NoContent();
                }
                return NotFound();
            }
        }
    }


