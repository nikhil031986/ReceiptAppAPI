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
    public class CustomerController(ISender sender) : Controller
    {
        [HttpPost("")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerMaster customer)
        {
            var result = await sender.Send(new AddCustomerCommand(customer));
            return Ok(result);
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            var result = await sender.Send(new GetCustomersCommand());
            return Ok(result);
        }

        [HttpGet("GetCustomerById/{CustomerId}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int CustomerId)
        {
            var result = await sender.Send(new GetCustomerByIdCommand(CustomerId));
            return Ok(result);
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateSite([FromBody] CustomerMaster customer)
        {
            var result = await sender.Send(new UpdateCustomerCommand(customer));
            return Ok(result);
        }

        [HttpPost("DeActivate/{customerId}")]
        public async Task<IActionResult> DeActivate([FromRoute] int customerId)
        {
            var result = await sender.Send(new DeActiveCustomerCommand(customerId));
            return Ok(result);
        }

        [HttpPost("DeleteCustomer/{customerId}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int customerId)
        {
            var result= await sender.Send(new DeleteCustomerCommand(customerId));
            return Ok(result);
        }
    }
}
