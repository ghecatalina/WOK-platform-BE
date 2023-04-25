using API.DTOs.Contacts;
using Application.Contacts.Commands.CreateContact;
using AutoMapper;
using Domain.Models;

namespace API.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactPostModel, CreateContactCommand>();
            CreateMap<Contact, ContactGetModel>();
        }
    }
}
