using API.DTOs.Messages;
using Application.ClientMessages.Commands.CreateMessage;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
    public class MessageHub : Hub {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MessageHub(
            IMediator mediator, 
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task SendMessage(MessagePostModel message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);

            await _mediator
                .Send(
                    _mapper
                    .Map<CreateMessageCommand>(message)
                    );
        }
    }
}
