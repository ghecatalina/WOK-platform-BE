using API.DTOs.Messages;
using Application.ClientMessages.Queries.GetMessages;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("client-messages")]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MessageController(
            IMediator mediator, 
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Worker")]
        public async Task<IEnumerable<MessageGetModel>> GetAll()
        {
            var query = new GetMessagesQuery();
            var result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<MessageGetModel>>(result);
        }
    }
}
