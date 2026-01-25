using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Receipt.API.Helpers;
using Receipt.Application.Commands;
using Receipt.Application.Queries;
using Receipt.Domain.Entity;

namespace Receipt.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ISender sender) : Controller
    {
        [HttpPost("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerMaster customer)
        {
            var result = await sender.Send(new AddCustomerCommand(customer));
            if(result == null)
            {
                return BadRequest("Customer Not Added Please try agen.");
            }
            return Ok(result);
        }

        [HttpGet("GetCustomer")]
        [Authorize(Roles = "Client,Admin")]
        public async Task<IActionResult> GetCustomer()
        {
            var result = await sender.Send(new GetCustomersCommand());
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetCustomerById/{CustomerId}")]
        [Authorize(Roles = "Client,Admin")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int CustomerId)
        {
            var result = await sender.Send(new GetCustomerByIdCommand(CustomerId));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetCustomerBySitId/{siteId}")]
        [Authorize(Roles = "Client,Admin")]
        public async Task<IActionResult> GetCustomerBySitId([FromRoute] int siteId)
        {
            var result = await sender.Send(new GetCustomerBySiteIdCommand(siteId));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("UpdateCustomer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerMaster customer)
        {
            var result = await sender.Send(new UpdateCustomerCommand(customer));
            if (result == null)
            {
                return BadRequest("Site not updated please try agen.");
            }
            return Ok(result);
        }

        [HttpPost("DeActivate/{customerId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeActivate([FromRoute] int customerId)
        {
            var result = await sender.Send(new DeActiveCustomerCommand(customerId));
            if (result == false)
            {
                return BadRequest("Customer not Deactivate please try agen.");
            }
            return Ok(result);
        }

        [HttpPost("DeleteCustomer/{customerId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int customerId)
        {
            var result= await sender.Send(new DeleteCustomerCommand(customerId));
            if (result == false)
            {
                return BadRequest("Customer not remove from the system. please try agen.");
            }
            return Ok(result);
        }

        [HttpGet("GetCustomerDetail/{customerDetailId}")]
        [Authorize(Roles = "Client,Admin")]
        public async Task<IActionResult> GetCustomerDetail([FromRoute] int customerDetailId)
        {
            var result = await sender.Send(new GetCustomerDetailCommand(customerDetailId));
            if (result == null)
            {
                return BadRequest("Customer detail not found in the system. please try agen.");
            }
            return Ok(result);
        }

        [HttpPost("AddUpdateCustomerDetail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUpdateCustomerDetail([FromBody] CustomerDetail customerDetail)
        {
            var result = await sender.Send(new AddUpdateCustomerDetailsCommand(customerDetail));
            if (result == null)
            {
                return BadRequest("Customer detail not save or update in the system. please try agen.");
            }
            return Ok(result);
        }

        [HttpDelete("DeleteCustomerDetail/{customerDetailId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCustomerDetail([FromBody] int customerDetailId)
        {
            var result = await sender.Send(new DeleteCustomerDetailCommand(customerDetailId));
            if (result == false)
            {
                return BadRequest("Customer detail not found in the system. please try agen.");
            }
            return Ok(result);
        }

    }
}
