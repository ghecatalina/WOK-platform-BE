using API.DTOs.DailyMenu;
using Application.DailyMenus.Commands.AddOrUpdateDailyMenu;
using Application.DailyMenus.Queries.GetDailyMenu;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("dailymenu")]
    public class DailyMenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DailyMenuController(
            IMediator mediator, 
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates or Updates the Daily Menu
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> AddOrUpdateDailyMenu(
            [FromBody]DailyMenuPutModel request)
        {
            var command = new AddOrUpdateDailyMenuCommand 
            { 
                FirstDish = request.FirstDish,
                SecondDish = request.SecondDish,
            };

            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Gets the Daily Menu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDailyMenu()
        {
            var query = new GetDailyMenuQuery();
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<DailyMenuGetModel>(result);
            return Ok(mappedResult);
        }
    }
}
