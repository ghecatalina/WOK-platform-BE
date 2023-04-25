using API.DTOs.Contacts;
using Application.Contacts.Commands.CreateContact;
using Application.Contacts.Queries.GetContacts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactController(
            IMediator mediator, 
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<ContactGetModel>> Get(
            [FromQuery]DateTime? date)
        {
            var query = new GetContactsQuery
            {
                Date = date,
            };

            var result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<ContactGetModel>>(result);   
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            ContactPostModel request)
        {
            var command = _mapper.Map<CreateContactCommand>(request);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
