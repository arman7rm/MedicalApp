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
    public class DoctorTypeRepository : IDoctorTypeRepo
    {
        private readonly NewDataBaseContext _context;
        public DoctorTypeRepository(NewDataBaseContext context)
        {
            _context = context;
        }
        public void Add(int Id, string type)
        {
            throw new NotImplementedException();
        }

        public void DeleteDoctor(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<d.Doctor> GetByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
