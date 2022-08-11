using AutoMapper;
using DeskBookingSystem.Entities;
using DeskBookingSystem.Models;

namespace DeskBookingSystem
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<Desk, DeskDto>();
        }
    }
}
