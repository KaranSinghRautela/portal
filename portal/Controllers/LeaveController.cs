using Microsoft.AspNetCore.Mvc;
using portal.Models.Leave;
using portal.Services;
using System;
using System.Collections.Generic;

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

        // GET: api/Leave
        [HttpGet]
        public ActionResult<IEnumerable<Leave>> GetLeaves()
        {
            try
            {
                var leaves = _leaveService.GetLeaves();
                return Ok(leaves);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Leave/5
        [HttpGet("{id}", Name = "GetLeaveById")]
        public ActionResult<Leave> GetLeaveById(int id)
        {
            try
            {
                var leave = _leaveService.GetLeaveById(id);
                if (leave == null)
                    return NotFound($"Leave with ID {id} not found");

                return Ok(leave);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Leave
        [HttpPost]
        public ActionResult<Leave> CreateLeave([FromBody] Leave leave)
        {
            try
            {
                var createdLeave = _leaveService.CreateLeave(leave);
                return CreatedAtRoute("GetLeaveById", new { id = createdLeave.LeaveId }, createdLeave);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Leave/5
        [HttpPut("{id}")]
        public ActionResult<Leave> EditLeave(int id, [FromBody] Leave leave)
        {
            try
            {
                var result = _leaveService.EditLeave(id, leave);
                if (result == 0)
                    return NoContent(); // Successfully updated
                else
                    return NotFound($"Leave with ID {id} not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Leave/5
        [HttpDelete("{id}")]
        public ActionResult DeleteLeave(int id)
        {
            try
            {
                var result = _leaveService.DeleteLeave(id);
                if (result == 0)
                    return NoContent(); // Successfully deleted
                else
                    return NotFound($"Leave with ID {id} not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
