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

        public d.Doctor Get(int id)
        {
            var entity = _context.Doctors.Find(id);
            return new d.Doctor
            {
                UserName = entity.Username,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Bio = entity.Bio,
                City = entity.City,
                State = entity.State,
                DoctorId = entity.DoctorId,
                Email = entity.Email,
                Exp = entity.ExpYears,
                Fee = entity.Fee,
                Phone = entity.Phone,
                Rating = entity.Rating
            };
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
                DoctorType = newDoctor.DoctorType
            };
            _context.Doctors.Add(entity);
            _context.SaveChanges();
            var doc = _context.Doctors.First(d => d.Username==entity.Username);
            var cityTag = _context.Tags.First(t => t.term == doc.City.ToLower());
            var city = new DoctorTag { doctorId = doc.DoctorId, tagId = cityTag.tagId };
            var stateTag = _context.Tags.First(t => t.term == doc.State.ToLower());
            var state = new DoctorTag { doctorId = doc.DoctorId, tagId = stateTag.tagId };
            var typeTag = _context.Tags.First(t => t.term == doc.DoctorType.ToLower());
            var type = new DoctorTag { doctorId = doc.DoctorId, tagId = typeTag.tagId };

            _context.DoctorTags.Add(city);
            _context.SaveChanges();
            _context.DoctorTags.Add(type);
            _context.SaveChanges();
            _context.DoctorTags.Add(state);
            _context.SaveChanges();
            return entity.DoctorId;
        }

        public void Delete(int id)
        {
            var entity = _context.Doctors.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Doctors.Remove(entity);
            var types = _context.DoctorTags
                .Where(t => t.doctorId == id);
            foreach (var type in types)
            {
                _context.DoctorTags.Remove(type);
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }

        public IEnumerable<d.Doctor> Search(string tag)
        {
            var query = _context.Tags.First(t => t.term == tag.ToLower());
            var docTags = _context.DoctorTags
                .Where(d => d.tagId == query.tagId);
            var doctors = new List<d.Doctor>();
            foreach(DoctorTag x in docTags)
            {
                Doctor entity = _context.Doctors.Find(x.doctorId);
                d.Doctor doc = new d.Doctor
                {
                    UserName = entity.Username,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Bio = entity.Bio,
                    City = entity.City,
                    DoctorId = entity.DoctorId,
                    Email = entity.Email,
                    DoctorType = entity.DoctorType,
                    Exp = entity.ExpYears,
                    Fee = entity.Fee,
                    Phone = entity.Phone,
                    Rating = entity.Rating,
                    State = entity.State
                };
                doctors.Add(doc);
            }
            return doctors;
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
