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
            CreateMap<Desk, BookingDeskDto>();
            CreateMap<Booking, BookingDto>();
            CreateMap<Booking, DeskBookingDto>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<CreateLocationDto, Location>();
            CreateMap<CreateDeskDto, Desk>();
            CreateMap<CreateBookingDto, Booking>();

        }
    }
}
