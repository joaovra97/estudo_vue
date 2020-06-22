using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        public ProfessoresController()
        {
        }

        // GET api/professores
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/professores/5
        [HttpGet("{id}")]
        public IActionResult GetstringById(int id)
        {
            return null;
        }

        // POST api/professores
        [HttpPost]
        public IActionResult Post(string value)
        {
            return Ok();
        }

        // PUT api/professores/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string value)
        {
            return Ok();
        }

        // DELETE api/professores/5
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok();
        }
    }
}