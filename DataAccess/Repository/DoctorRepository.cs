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
            var entity = new Doctor
            {
                Username = newDoctor.UserName,
                Pass = newDoctor.PassWord,
                FirstName = newDoctor.FirstName,
                LastName = newDoctor.LastName,
                Email = newDoctor.Email,
                City = newDoctor.City.ToLower(),
                State = newDoctor.State,
                Bio = newDoctor.Bio,
                ExpYears = newDoctor.Exp,
                Fee = newDoctor.Fee,
                Phone = newDoctor.Phone,
                Rating = 0,
                Consultations = 0,
            };
            _context.Doctors.Add(entity);
            _context.SaveChanges();
            return entity.DoctorId;
        }

        public void Delete(d.Doctor newDoctor)
        {
            var entity = _context.Doctors.Find(newDoctor.DoctorId);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Doctors.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<d.Doctor> GetByCity(string City)
        {
            var doctors = _context.Doctors
                .Where(d => d.City == City.ToLower());
            return doctors.Select(e => new d.Doctor
            {
                DoctorId = e.DoctorId,
                UserName = e.Username,
                PassWord = e.Pass,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                City = e.City,
                State = e.State,
                Bio = e.Bio,
                Exp = e.ExpYears,
                Fee = (double)e.Fee,
                Rating = (double)e.Rating,
                Phone = e.Phone
            });
        }

        public IEnumerable<d.Doctor> GetByState(string State)
        {
            var doctors = _context.Doctors
                .Where(d => d.State == State.ToLower());
            return doctors.Select(e => new d.Doctor
            {
                DoctorId = e.DoctorId,
                UserName = e.Username,
                PassWord = e.Pass,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                City = e.City,
                State = e.State,
                Bio = e.Bio,
                Exp = e.ExpYears,
                Fee = (double)e.Fee,
                Rating = (double)e.Rating,
                Phone = e.Phone
            });
        }

        public double GetRating(int DoctorId)
        {
            var ratings = _context.Reviews
                .Where(r => r.DoctorId == DoctorId);
            double sum = 0;
            double count = 0;
            foreach(Review x in ratings)
            {
                sum += x.Rating;
                count++;
            }
            return sum / count;

        }

        public void Update(d.Doctor newDoctor)
        {
            var entity = _context.Doctors.Find(newDoctor.DoctorId);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            entity.Bio = newDoctor.Bio;
            entity.City = newDoctor.City;
            entity.Email = newDoctor.Email;
            entity.ExpYears = newDoctor.Exp;
            entity.FirstName = newDoctor.FirstName;
            entity.LastName = newDoctor.LastName;
            entity.Pass = newDoctor.PassWord;
            entity.Username = newDoctor.UserName;
            entity.State = newDoctor.State;
            entity.Phone = newDoctor.Phone;
            _context.Doctors.Update(entity);
            _context.SaveChanges();
        }
    }
}
