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
    public class AlunosController : ControllerBase
    {
        public AlunosController()
        {
        }

        // GET api/alunos
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/alunos/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // POST api/alunos
        [HttpPost("")]
        public IActionResult Post(string value)
        {
            return Ok();
        }

        // PUT api/alunos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string value)
        {
            return Ok();

        }

        // DELETE api/alunos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok();

        }
    }
}