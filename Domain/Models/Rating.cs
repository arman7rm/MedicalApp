using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public double Score { get; set; }
    }
}
