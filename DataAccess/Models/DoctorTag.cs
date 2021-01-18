using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public partial class DoctorTag
    {
        public int doctorTagId { get; set; }
        public int doctorId { get; set; }
        public int tagId { get; set; }
    }
}
