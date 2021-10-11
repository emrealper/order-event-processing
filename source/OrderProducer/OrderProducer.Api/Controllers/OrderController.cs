using System.Threading.Tasks;
using Application.Services.Commands.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderProducer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] NewOrderCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}