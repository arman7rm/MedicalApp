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
            var entity = new DoctorType
            {
                DoctorId = Id,
                DoctorType1 = type.ToLower()
            };
            _context.DoctorTypes.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<d.Doctor> GetByType(string type)
        {
            var doctorsIds = _context.DoctorTypes
                .Where(d => d.DoctorType1 == type.ToLower());
            List<d.Doctor> result = new List<d.Doctor>();
            foreach(var doc in doctorsIds)
            {
                var entity = _context.Doctors.Find(doc.DoctorId);
                d.Doctor temp = new d.Doctor
                {
                    DoctorId = entity.DoctorId,
                    UserName = entity.Username,
                    PassWord = entity.Pass,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    City = entity.City,
                    State = entity.State,
                    Phone = entity.Phone,
                    Bio = entity.Bio,
                    Exp = entity.ExpYears,
                    Fee = (double)entity.Fee,
                    Rating = (double)entity.Rating
                };
                result.Add(temp);
            }
            return result;
        }
    }
}
