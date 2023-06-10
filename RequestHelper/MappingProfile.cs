using AutoMapper;
using Api2.DTOs;
using Api2.Models;

namespace Api2.RequestHelper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.CantReservesLastMonth, opt => opt.Ignore())
                .ForMember(dest => dest.DateLastReserve, opt => opt.Ignore())
                .ForMember(dest => dest.Reserves, opt => opt.MapFrom(src => src.Reserves));

            CreateMap<Reserve, BookDto>();

            CreateMap<Book, BookDto>();
        }
    }
}