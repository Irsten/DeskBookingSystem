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
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, BookingEmployeeDto>();

            CreateMap<CreateLocationDto, Location>();
            CreateMap<CreateDeskDto, Desk>();
            CreateMap<CreateBookingDto, Booking>();

        }
    }
}
