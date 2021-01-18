using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorController(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }
        

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _doctorRepo.Get(id);
            return Ok(result);
        }

        // GET api/<DoctorController>/5
        [HttpGet("search/{query}")]
        public IActionResult Search(string query)
        {
            var result = _doctorRepo.Search(query);
            return Ok(result);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public IActionResult Post([FromBody] Doctor doc)
        {
            var newDocID = _doctorRepo.Add(doc);
            var newDoc = _doctorRepo.Get(newDocID);
            return Created($"api/<DoctorContoller>/{newDocID}", newDoc);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Doctor Doc)
        {
            _doctorRepo.Update(Doc);
            return Ok();
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _doctorRepo.Delete(id);
            return Ok();
        }
    }
}
