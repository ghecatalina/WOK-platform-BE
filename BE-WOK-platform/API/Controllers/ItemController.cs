using API.DTOs.Items;
using Application.Exceptions;
using Application.Items.Commands.CreateItem;
using Application.Items.Commands.DeleteItem;
using Application.Items.Commands.UpdateItem;
using Application.Items.Queries.GetItemById;
using Application.Items.Queries.GetItemsByCategory;
using AutoMapper;
using MediatR;
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
        /// <param name="categoryId"></param>
        /// <param name="request"></param>
        /// <exception cref="InvalidModelStateException"></exception>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <returns></returns>
        [HttpPost]
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
        /// <param name="categoryId"></param>
        /// <param name="itemId"></param>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <returns></returns>
        [HttpGet]
        [Route("{itemId}")]
        public async Task<IActionResult> GetItemById(
            Guid categoryId,
            Guid itemId)
        {
            var query = new GetItemByIdQuery { CategoryId = categoryId, Id = itemId };
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<ItemGetModel>(result);
            return Ok(mappedResult);
        }

        /// <summary>
        /// Gets all items from a category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetItemsByCategory(
            Guid categoryId)
        {
            var query = new GetItemsByCategoryQuery { CategoryId = categoryId};
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<IEnumerable<ItemGetModel>>(result);
            return Ok(mappedResult);
        }

        /// <summary>
        /// Updates an item from a category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="itemId"></param>
        /// <param name="request"></param>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <returns></returns>
        [HttpPut]
        [Route("{itemId}")]
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
        /// <param name="categoryId"></param>
        /// <param name="itemId"></param>
        /// <exception cref="ObjectNotFoundException"></exception>
        /// <returns></returns>
        [HttpDelete]
        [Route("{itemId}")]
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
