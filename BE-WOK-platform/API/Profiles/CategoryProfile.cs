using API.DTOs.Categories;
using Application.Categories.Commands.CreateCategoryCommand;
using Application.Categories.Commands.UpdateCategory;
using AutoMapper;
using Domain.Models;

namespace API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetModel>();
            CreateMap<CategoryPostPutModel, Category>();
            CreateMap<CategoryPostPutModel, CreateCategoryCommand>();
            CreateMap<CategoryPostPutModel, UpdateCategoryCommand>();
        }
    }
}
