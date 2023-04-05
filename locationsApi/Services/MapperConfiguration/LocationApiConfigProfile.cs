using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Services.MapperConfiguration
{
    public class LocationsApiConfigProfile : Profile
    {
        public LocationsApiConfigProfile()
        {
            CreateMap<Schedule, ScheduleDto>()
                .ForMember(x => x.Open, opt => opt.MapFrom(s => s.Open.ToString()))
                .ForMember(x => x.Close, opt => opt.MapFrom(s => s.Close.ToString()))
                .ReverseMap();

            CreateMap<Location, LocationDto>().ReverseMap();

            CreateMap<SaveLocationPayload, Location>()
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.Address, opt => opt.MapFrom(s => s.Address))
                .ForMember(x => x.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(x => x.WebSite, opt => opt.MapFrom(s => s.WebSite))
                .ForMember(x => x.Phone, opt => opt.MapFrom(s => s.Phone))
                .ForMember(x => x.City, opt => opt.MapFrom(s => s.City))
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<EditLocationPayload, Location>();

        }
        
    }
}
