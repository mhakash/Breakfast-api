using AutoMapper;
using BuberBreakfast.Models;
using BuberBreakfast.Models.DTOs;

namespace BuberBreakfast.Profiles;

public class DriverProfile : Profile
{
    public DriverProfile()
    {
        CreateMap<DriverCreateRequestDto, Driver>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));
    }
}