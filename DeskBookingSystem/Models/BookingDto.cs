﻿using DeskBookingSystem.Entities;

namespace DeskBookingSystem.Models
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public EmployeeDto Employee { get; set; }
        public DeskDto Desk { get; set; }
    }
}
