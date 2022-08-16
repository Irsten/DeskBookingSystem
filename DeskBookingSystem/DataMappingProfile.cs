using AutoMapper;
using DeskBookingSystem.Entities;
using DeskBookingSystem.Models;

namespace DeskBookingSystem
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<Desk, DeskDto>();
            CreateMap<Booking, BookingDto>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<CreateLocationDto, Location>();
        }
    }
}
