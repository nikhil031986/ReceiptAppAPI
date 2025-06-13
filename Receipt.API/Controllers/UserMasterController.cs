using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Receipt.Application.Commands;
using Receipt.Application.Queries;
using Receipt.Domain.Common;
using Receipt.Domain.Entity;

namespace Receipt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController(ISender sender) : ControllerBase
    {
        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromBody] UserMaster userMaster)
        {
            var result = await sender.Send(new AddUserMasterCommand(userMaster));
            if (result == null)
            {
                return BadRequest("User not added into system. Please try agen.");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var result = await sender.Send(new GetAllUserQueries());
            if (result == null || !result.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(result);
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string emailId,string password)
        {
            var result = await sender.Send(new TokenGeneratorQuerie(emailId, password));
            if (result == null || result.Data == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUserByEmailAndPassword")]
        public async Task<IActionResult> GetUserByEmailAndPassword(string emailId, string password)
        {
            var result = await sender.Send(new GetLoginQueries(emailId, password));
            if (result == null)
            {
                return NotFound("User not found with the provided email and password.");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPost("UpdateUser/{userMasterId}")]
        public async Task<IActionResult> UpdateUser([FromRoute]int userMasterId,[FromBody] UserMaster userMaster)
        {
            var result = await sender.Send(new UpdateUserCommand(userMasterId, userMaster));
            if (result == null)
            {
                return BadRequest("User not updated into system. Please try agen.");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPost("DeActivate/{userMasterId}")]
        public async Task<IActionResult> DeActivate([FromRoute] int userMasterId)
        {
            var result = await sender.Send(new DeActiveUserCommand(userMasterId));
            if (result == false)
            {
                return BadRequest("User not Deactivated into system. Please try agen.");
            }
            return Ok(result);
        }
        [Authorize]
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is required");
            }

            var result = await sender.Send(new LogoutQuerie(token));
            if(result)
            {
                return Ok("Logged out successfully");
            }

            return StatusCode(500, "An error occurred while logging out");
        }
    }
}
