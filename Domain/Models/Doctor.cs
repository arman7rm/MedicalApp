using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    class Doctor
    {
        public int DoctorId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Bio { get; set; }
        public int Exp { get; set; }
        public double Fee { get; set; }
        public double Rating { get; set; }
        public string Phone { get; set; }
        public List<Booking> Appointments = new List<Booking>();
    }
}
