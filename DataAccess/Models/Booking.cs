using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
    }
}
