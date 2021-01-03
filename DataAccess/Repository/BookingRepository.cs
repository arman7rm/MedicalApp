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
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<d.Booking> GetByDoctor(int DoctorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<d.Booking> GetByUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public void Update(d.Booking newBooking)
        {
            throw new NotImplementedException();
        }
    }
}
