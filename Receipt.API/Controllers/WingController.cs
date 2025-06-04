using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Receipt.Application.Commands;
using Receipt.Application.Queries;
using Receipt.Domain.Entity;

namespace Receipt.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WingController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Addwing([FromBody] WingMaster wingMaster)
        {
            var result = await sender.Send(new AddwingCommand(wingMaster));
            return Ok(result);
        }

        [HttpPost("Updatewing")]
        public async Task<IActionResult> Updatewing([FromBody] WingMaster wingMaster)
        {
            var result = await sender.Send(new UpdatewingCommand(wingMaster));
            return Ok(result);
        }

        [HttpPost("DeActivate/{wingMasterId}")]
        public async Task<IActionResult> DeActivate([FromRoute] int wingMasterId)
        {
            var result = await sender.Send(new DeActivewingCommand(wingMasterId));
            return Ok(result);
        }

        [HttpPost("Deletewing/{wingMasterId}")]
        public async Task<IActionResult> Deletewing([FromRoute] int wingMasterId)
        {
            var result = await sender.Send(new DeletewingCommand(wingMasterId));
            return Ok(result);
        }

        [HttpGet("GetAllwing")]
        public async Task<IActionResult> GetAllwing()
        {
            var result = await sender.Send(new GetAllwingQueries());
            return Ok(result);
        }

        [HttpGet("GetwingById/{wingId}")]
        public async Task<IActionResult> GetwingById([FromRoute] int wingId)
        {
            var result = await sender.Send(new GetwingByIdQueries(wingId));
            return Ok(result);
        }

        [HttpGet("GetWingDetails/{wingMasterId}")]
        public async Task<IActionResult> GetWingDetails([FromRoute] int wingMasterId)
        {
            var result = await sender.Send(new GetWingDetailsQueries(wingMasterId));
            return Ok(result);
        }

        [HttpGet("GetWingDetailsById/{wigDetailId}")]
        public async Task<IActionResult> GetWingDetailsById([FromRoute] int wigDetailId)
        {
            var result = await sender.Send(new GetWingDetailsByIdQueries(wigDetailId));
            return Ok(result);
        }
    }
}
