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
        
            int BookingId = _bookingRepo.Add(booking);
            var result = _bookingRepo.GetById(BookingId);

            return CreatedAtAction(nameof(getById), new { id = BookingId}, result);
        }

        [HttpGet("doctor/{id}")]
        public IActionResult GetByDoctor(int id)
        {
            return Ok(_bookingRepo.GetByDoctor(id));
        }

        [HttpGet("user/{id}")]
        public IActionResult GetByUser(int id)
        {
            return Ok(_bookingRepo.GetByUser(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookingRepo.Delete(id);
            return Ok();
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Booking booking)
        {
            _bookingRepo.Update(booking);
            return Ok();
        }

    }
}
