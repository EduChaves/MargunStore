using MargunStore.Domain.Commands.v1.Product.Create;
using MargunStore.Domain.Commands.v1.Product.Delete;
using MargunStore.Domain.Commands.v1.Product.Update;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Product.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MargunStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    [AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<GetProductQueryResponse>> GetProducts(int? id)
        {

            var tt = await _mediator.Send(new GetProductQuery { Id = id });
            return tt;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand request)
        {
            await _mediator.Send(request);
            return Created(string.Empty, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return Ok();
        }
    }
}
