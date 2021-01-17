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
        IEnumerable<Doctor> GetByCity(string City);
        IEnumerable<Doctor> GetByState(string State);
        void Update(Doctor newDoctor);
        void Delete(Doctor newDoctor);
        double GetRating(int DoctorId);

    }
}
