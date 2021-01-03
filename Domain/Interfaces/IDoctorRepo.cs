using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDoctorRepo
    {
        int Add(Doctor newDoctor);
        IEnumerable<Doctor> GetByCity(string City);
        IEnumerable<Doctor> GetByState(string State);
        IEnumerable<Doctor> GetByType(string Type);
        void Update(Doctor newDoctor);
        void Delete(Doctor newDoctor);
        double GetRating(int DoctorId);

    }
}
