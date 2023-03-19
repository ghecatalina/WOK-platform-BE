using API.DTOs.Items;
using Application.Exceptions;
using Application.Items.Commands.CreateItem;
using Application.Items.Commands.DeleteItem;
using Application.Items.Commands.UpdateItem;
using Application.Items.Queries.GetItemById;
using Application.Items.Queries.GetItemsByCategory;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("categories/{categoryId}/items")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ItemController(
            IMediator mediator, 
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Creates a new item
        /// </summary>
        /// <exception cref="InvalidModelStateException"></exception>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <response code="201">Item successfully created</response>
        /// <response code="404">Category with given id does not exist.</response>
        [HttpPost, Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ItemGetModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateItem(
            Guid categoryId,
            [FromBody]ItemPostPutModel request)
        {
            var command = _mapper.Map<CreateItemCommand>(request);
            command.CategoryId = categoryId;

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<ItemGetModel>(created);

            return CreatedAtAction(nameof(GetItemById), new { categoryId = created.CategoryId, itemId = created.Id }, dto);
        }

        /// <summary>
        /// Gets an item by Id
        /// </summary>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <response code="200">Item successfully retrieved</response>
        /// <response code="404">Category or Item with given id does not exist.</response>
        [HttpGet]
        [Route("{itemId}")]
        [ProducesResponseType(typeof(ItemGetModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ItemGetModel> GetItemById(
            Guid categoryId,
            Guid itemId)
        {
            var query = new GetItemByIdQuery { CategoryId = categoryId, Id = itemId };
            var result = await _mediator.Send(query);

            return _mapper.Map<ItemGetModel>(result);
        }

        /// <summary>
        /// Gets all items from a category
        /// </summary>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <response code="200">Item successfully retrieved</response>
        /// <response code="404">Category with given id does not exist.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ItemGetModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ItemGetModel>> GetItemsByCategory(
            Guid categoryId)
        {
            var query = new GetItemsByCategoryQuery { CategoryId = categoryId};
            var result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<ItemGetModel>>(result);
        }

        /// <summary>
        /// Updates an item from a category
        /// </summary>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <response code="204">Item successfully updated</response>
        /// <response code="404">Category or Item with given id does not exist.</response>
        [HttpPut, Authorize(Roles = "Admin")]
        [Route("{itemId}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateItem(
            Guid categoryId,
            Guid itemId,
            [FromBody]ItemPostPutModel request)
        {
            var command = _mapper.Map<UpdateItemCommand>(request);
            command.CategoryId = categoryId;
            command.Id = itemId;

            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes an item
        /// </summary>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <response code="204">Item successfully deleted</response>
        /// <response code="404">Category or Item with given id does not exist.</response>
        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("{itemId}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteItem(
            Guid categoryId,
            Guid itemId)
        {
            var command = new DeleteItemCommand { CategoryId = categoryId, Id = itemId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
