using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string Review1 { get; set; }
    }
}
