using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDoctorRepo
    {
        int Add(Doctor newDoctor);
        Doctor Get(int id);
        IEnumerable<Doctor> Search(string tag);
        void Update(Doctor newDoctor);
        void Delete(int newDoctor);
        double GetRating(int DoctorId);

    }
}
