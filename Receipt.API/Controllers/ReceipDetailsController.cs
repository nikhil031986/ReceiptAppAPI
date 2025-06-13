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
    public class ReceipDetailsController(ISender sender) : Controller
    {
        [HttpPost("")]
        public async Task<IActionResult> AddReceiptDetails([FromBody] ReceiptDetail receiptDetail)
        {
            var result = await sender.Send(new AddReciptDetailsCommand(receiptDetail));
            if(result == null)
            {
                return BadRequest("Receipt not added into system. Please try agen.");
            }
            return Ok(result);
        }
        [HttpPost("UpdateReceiptDetails")]
        public async Task<IActionResult> UpdateReceiptDetails([FromBody] ReceiptDetail receiptDetail)
        {
            var result = await sender.Send(new UpdateReciptDetailsCommand(receiptDetail.ReceiptId, receiptDetail));
            if (result == null)
            {
                return BadRequest("Receipt not updated into system. Please try agen.");
            }
            return Ok(result);
        }
        [HttpPost("DeActivate/{receiptId}")]
        public async Task<IActionResult> DeActivate([FromRoute] int receiptId)
        {
            var result = await sender.Send(new DeActiveReciptDetailsCommand(receiptId));
            if (result == false)
            {
                return BadRequest("Receipt not Deactivated into system. Please try agen.");
            }
            return Ok(result);
        }
        [HttpGet("GetReceiptDetailsById/{receiptId}")]
        public async Task<IActionResult> GetReceiptDetailsById([FromRoute] int receiptId)
        {
            var result = await sender.Send(new GetReceiptDetailQueries(receiptId));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("GetAllReceiptDetails")]
        public async Task<IActionResult> GetAllReceiptDetails()
        {
            var result = await sender.Send(new GetAllReceiptDetailsQueries());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("GetReceiptDetailsByCustomerId/{customerId}")]
        public async Task<IActionResult> GetReceiptDetailsByCustomerId([FromRoute] int customerId)
        {
            var result = await sender.Send(new GetReceiptDetailsByCustomerIdQueries(customerId));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
