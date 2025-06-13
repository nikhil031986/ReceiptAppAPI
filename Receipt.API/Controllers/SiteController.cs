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
    public class SiteController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddSite([FromBody] SiteMaster siteMaster)
        {
            var result = await sender.Send(new AddSiteMasterCommand(siteMaster));
            if (result == null)
            {
                return BadRequest("Site not added into system. Please try agen");
            }
            return Ok(result);
        }

        [HttpGet("GetSite")]
        public async Task<IActionResult> GetSite()
        {
            var result = await sender.Send(new GetAllSiteQueries());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetSiteById/{siteId}")]
        public async Task<IActionResult> GetSiteById([FromRoute] int siteId)
        {
            var result = await sender.Send(new GetSiteByIdQueries(siteId));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("UpdateSite/{siteId}")]
        public async Task<IActionResult> UpdateSite([FromRoute] int siteId, [FromBody] SiteMaster siteMaster)
        {
            var result = await sender.Send(new UpdateSiteCommand(siteId, siteMaster));
            if (result == null)
            {
                return BadRequest("Site not updated into system. Please try agen.");
            }
            return Ok(result);
        }

        [HttpPost("DeActivate/{siteId}")]
        public async Task<IActionResult> DeActivate([FromRoute] int siteId)
        {
            var result = await sender.Send(new DeActiveSiteCommand(siteId));
            if (result == false)
            {
                return BadRequest("Site not Deactivate into system. Please try agen.");
            }
            return Ok(result);
        }
    }
}
