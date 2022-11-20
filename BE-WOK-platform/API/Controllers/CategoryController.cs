﻿using API.DTOs.Categories;
using Application.Categories.Commands.CreateCategoryCommand;
using Application.Categories.Commands.UpdateCategory;
using Application.Categories.Queries.GetCategories;
using Application.Categories.Queries.GetCategoryById;
using AutoMapper;
using MediatR;
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

        [HttpPost]
        public async Task<IActionResult> CreateCategory(
            [FromBody]CategoryPostPutModel category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateCategoryCommand>(category);

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<CategoryGetModel>(created);

            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = created.Id }, dto);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(
            Guid categoryId)
        {
            var query = new GetCategoryByIdQuery { Id = categoryId };
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<CategoryGetModel>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetCategoriesQuery();
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<IEnumerable<CategoryGetModel>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(
            Guid categoryId,
            [FromBody]CategoryPostPutModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<UpdateCategoryCommand>(request);
            command.Id = categoryId;
            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<CategoryGetModel>(result);
            return Ok(mappedResult);
        }
    }
}