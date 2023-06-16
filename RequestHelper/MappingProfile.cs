using AutoMapper;
using Api2.DTOs;
using Api2.Models;

namespace Api2.RequestHelper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.TotalSumLastMonth, opt => opt.Ignore())
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));

            CreateMap<Order, DishDto>();

            CreateMap<Dish, DishDto>();
        }
    }
}