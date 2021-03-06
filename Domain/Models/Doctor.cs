﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Bio { get; set; }
        public int Exp { get; set; }
        public string DoctorType { get; set; }
        public double? Fee { get; set; }
        public double? Rating { get; set; }
        public string Phone { get; set; }
        public List<Tag> Tags = new List<Tag>();
        public List<Booking> Appointments = new List<Booking>();

    }
}
