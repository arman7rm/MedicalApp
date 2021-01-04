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
    public class BookingRepository : IBookingRepo
    {
        private readonly NewDataBaseContext _context;
        public BookingRepository(NewDataBaseContext context)
        {
            _context = context;
        }
        public int Add(d.Booking newBooking)
        {
            var entity = new Booking
            {
                Date = newBooking.Date,
                DoctorId = newBooking.DoctorId,
                PatientId = newBooking.UserId,
                Description = newBooking.Description
            };
            _context.Bookings.Add(entity);
            _context.SaveChanges();
            return entity.BookingId;
        }

        public void Delete(int Id)
        {
            var booking = _context.Bookings.Find(Id);
            if(booking == null)
            {
                throw new ArgumentNullException();
            }
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }

        public IEnumerable<d.Booking> GetByDoctor(int DoctorId)
        {
            var entities = _context.Bookings
                .Where(b => b.DoctorId == DoctorId);
            return entities.Select(e => new d.Booking
            {
                BookingId = e.BookingId,
                DoctorId = e.DoctorId,
                Description = e.Description,
                Date = e.Date,
                UserId = e.PatientId
            });
        }

        public IEnumerable<d.Booking> GetByUser(int UserId)
        {
            var entities = _context.Bookings
                .Where(b => b.PatientId == UserId);
            return entities.Select(e => new d.Booking
            {
                BookingId = e.BookingId,
                DoctorId = e.DoctorId,
                Description = e.Description,
                Date = e.Date,
                UserId = e.PatientId
            });
        }

        public void Update(d.Booking newBooking)
        {
            var entity = _context.Bookings.Find(newBooking.BookingId);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            entity.Description = newBooking.Description;
            entity.Date = DateTime.Now;
            entity.DoctorId = newBooking.DoctorId;
            entity.PatientId = newBooking.UserId;
            _context.Bookings.Update(entity);
            _context.SaveChanges();
        }
    }
}
