using API.DTOs.Reservations;
using Application.ReadModels;
using Application.Reservations.Commands.CreateReservation;
using AutoMapper;
using Domain.Models;

namespace API.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationPostModel, CreateReservationCommand>();
            CreateMap<Reservation, ReservationGetModel>();
            CreateMap<ReservationByTable, ReservationByTableGetModel>();
        }
    }
}
