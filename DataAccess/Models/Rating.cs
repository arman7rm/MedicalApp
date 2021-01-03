using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public double Rating1 { get; set; }
    }
}
