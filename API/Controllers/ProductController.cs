using Application.Handlers;
using Core.Commands;
using Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        public readonly ISender _mediator;

        public ProductController(ISender mediator)
        {
            _mediator = mediator;


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
             await _mediator.Send(command);
            return Ok(command);
        }
    }
}
