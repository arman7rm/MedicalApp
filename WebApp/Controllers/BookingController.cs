using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepo _bookingRepo;
        
        public BookingController(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_bookingRepo.GetById(id));
        }

        [HttpPost("create")]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            Booking newBooking = new Booking
            {
                DoctorId = booking.DoctorId,
                Date = booking.Date,
                UserId = booking.UserId,
                Description = booking.Description
            };
            int BookingId = _bookingRepo.Add(newBooking);
            var result = _bookingRepo.GetById(BookingId);

            return CreatedAtAction(nameof(getById), new { id = BookingId}, result);
        }

        [HttpGet("Get_By_Doctor/{id}")]
        public IActionResult GetByDoctor(int id)
        {
            return Ok(_bookingRepo.GetByDoctor(id));
        }


    }
}
