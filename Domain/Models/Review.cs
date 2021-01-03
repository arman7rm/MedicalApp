using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public double Rating { get; set; }
        public string Content { get; set; }
    }
}
