using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using d = Domain.Models;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class DoctorRepository : IDoctorRepo
    {
        private readonly NewDataBaseContext _context;
        public DoctorRepository(NewDataBaseContext context)
        {
            _context = context;
        }
        public int Add(d.Doctor newDoctor)
        {
            throw new NotImplementedException();
        }

        public void Delete(d.Doctor newDoctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<d.Doctor> GetByCity(string City)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<d.Doctor> GetByState(string State)
        {
            throw new NotImplementedException();
        }

        public double GetRating(int DoctorId)
        {
            throw new NotImplementedException();
        }

        public void Update(d.Doctor newDoctor)
        {
            throw new NotImplementedException();
        }
    }
}
