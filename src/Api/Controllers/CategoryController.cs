using MargunStore.Domain.Commands.v1.Category.Create;
using MargunStore.Domain.Commands.v1.Category.Delete;
using MargunStore.Domain.Commands.v1.Category.Update;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Category.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MargunStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<GetCategoryQueryResponse>> GetCategories() => await _mediator.Send(new GetCategoryQuery());

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand request)
        {
            await _mediator.Send(request);
            return Created(string.Empty, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
