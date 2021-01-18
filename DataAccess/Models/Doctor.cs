using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Doctor
    {
        public int DoctorId { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Bio { get; set; }
        public int ExpYears { get; set; }
        public double? Fee { get; set; }
        public string Phone { get; set; }
        public double? Rating { get; set; }
        public int? Consultations { get; set; }
        public string DoctorType { get; set; }
        public ICollection<DoctorTag> doctorTags{ get; set; }
        public ICollection<Booking> appointments { get; set; }
    }
}
