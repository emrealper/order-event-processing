using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Queries.Order;
using Application.Services.Queries.Order.Dto;
using Application.Services.Queries.Order.ViewModels;
using Microsoft.AspNetCore.Http;

namespace OrderConsumerQueryingService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var result = await Mediator.Send(new GetAllOrdersQuery { });
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> GetById(long id)
        {
            var result = await Mediator.Send(new GetOrderByIdQuery() {Id = id});
            return Ok(result);
        }

        [HttpGet("customerSearch/{text=text}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderListVm>> FullTextSearch(string text)
        {
            var result = await Mediator.Send(new OrderCustomerFullTextSearchQuery() {SearchText = text});
            return Ok(result);
        }
    }
}
