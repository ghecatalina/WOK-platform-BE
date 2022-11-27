using API.DTOs.Items;
using Application.Items.Commands.CreateItem;
using Application.Items.Commands.UpdateItem;
using AutoMapper;
using Domain.Models;

namespace API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemPostPutModel, Item>();
            CreateMap<Item, ItemGetModel>();
            CreateMap<ItemPostPutModel, CreateItemCommand>();
            CreateMap<ItemPostPutModel, UpdateItemCommand>();
        }
    }
}
