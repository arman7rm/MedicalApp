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
    public class TagController : ControllerBase
    {
        private readonly ITagRepo _tagRepo;

        public TagController(ITagRepo TagRepo)
        {
            _tagRepo = TagRepo;
        }

        // POST api/<TagController>
        [HttpPost("{value}")]
        public IActionResult Post(string value)
        {
            _tagRepo.Add(value);
            return Ok();
        }

        // DELETE api/<TagController>/5
        [HttpDelete()]
        public IActionResult Delete(string term)
        {
            _tagRepo.Delete(term);
            return Ok();
        }
    }
}
