using API.DTOs.Categories;
using Application.Categories.Commands.CreateCategoryCommand;
using Application.Categories.Commands.DeleteCategory;
using Application.Categories.Commands.UpdateCategory;
using Application.Categories.Queries.GetCategories;
using Application.Categories.Queries.GetCategoryById;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new catagory
        /// </summary>
        /// <exception cref="InvalidModelStateException"></exception>
        /// <response code="201">Category successfully created</response>
        [HttpPost, Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(CategoryGetModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCategory(
            [FromBody]CategoryPostPutModel category)
        {
            var command = _mapper.Map<CreateCategoryCommand>(category);

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<CategoryGetModel>(created);

            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = created.Id }, dto);
        }

        /// <summary>
        /// Gets a category by Id
        /// </summary>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <response code="200">Category successfully retrived</response>
        /// <response code="404">Category with given id does not exist</response>
        [HttpGet]
        [Route("{categoryId}")]
        [ProducesResponseType(typeof(CategoryGetModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<CategoryGetModel> GetCategoryById(
            Guid categoryId)
        {
            var query = new GetCategoryByIdQuery { Id = categoryId };
            var result = await _mediator.Send(query);

            return _mapper.Map<CategoryGetModel>(result);
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <response code="200">Categories successfully retrieved</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryGetModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<CategoryGetModel>> GetAllCategories()
        {
            var query = new GetCategoriesQuery();
            var result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<CategoryGetModel>>(result);
        }

        /// <summary>
        /// Updates a category
        /// </summary>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <exception cref="InvalidModelStateException"></exception>
        /// <response code="200">Category successfully updated</response>
        /// <response code="404">Category with given id not found</response>
        [HttpPut, Authorize(Roles = "Admin")]
        [Route("{categoryId}")]
        [ProducesResponseType(typeof(CategoryGetModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategory(
            Guid categoryId,
            [FromBody]CategoryPostPutModel request)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(request);
            command.Id = categoryId;
            var result = await _mediator.Send(command);

            return Ok(_mapper.Map<CategoryGetModel>(result));
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("{categoryId}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            Guid categoryId)
        {
            var command = new DeleteCategoryCommand { Id = categoryId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
