using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDoctorTypeRepo
    {
        void Add(int Id, string type);
        IEnumerable<Doctor> GetByType(string type);

    }
}
