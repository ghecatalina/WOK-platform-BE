using API.DTOs.Messages;
using Application.ClientMessages.Commands.CreateMessage;
using AutoMapper;
using Domain.Models;

namespace API.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessagePostModel, CreateMessageCommand>();
            CreateMap<Message, MessageGetModel>();
        }
    }
}
