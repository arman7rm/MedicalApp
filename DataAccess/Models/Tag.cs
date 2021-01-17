using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Tag
    {
        public int tagId { get; set; }
        public string term { get; set; }
        public ICollection<DoctorType> DoctorTypes { get; set; }
    }
}
