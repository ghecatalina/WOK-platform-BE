using API.DTOs.DailyMenu;
using AutoMapper;
using Domain.Models;

namespace API.Profiles
{
    public class DailyMenuProfile : Profile
    {
        public DailyMenuProfile()
        {
            CreateMap<DailyMenu, DailyMenuGetModel>();
        }
    }
}
