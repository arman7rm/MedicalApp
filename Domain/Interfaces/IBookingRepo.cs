using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBookingRepo
    {
        int Add(Booking newBooking);
        Booking GetById(int id);
        IEnumerable<Booking> GetByDoctor(int DoctorId);
        IEnumerable<Booking> GetByUser(int UserId);
        void Delete(int Id);
        void Update(Booking newBooking);
    }
}
