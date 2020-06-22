using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        public IRepository _repository { get; }
        public ProfessoresController(IRepository repository)
        {
            _repository = repository;
        }

        // GET api/professores
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllProfessoresAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        // GET api/professores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetProfessorAsyncById(id, true);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/professores
        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangesAsync())
                    return Created($"/api/professores/{model.Id}", model);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        // PUT api/professores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Professor model)
        {
            try
            {
                var professor = await _repository.GetProfessorAsyncById(id);
                if (professor == null)
                    return NotFound();

                model.Id = id;
                _repository.Update(model);

                if (await _repository.SaveChangesAsync())
                {
                    professor = await _repository.GetProfessorAsyncById(id);
                    return Created($"/api/professores/{professor.Id}", professor);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        // DELETE api/professores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var professor = await _repository.GetProfessorAsyncById(id);
                if (professor == null)
                    return NotFound();

                _repository.Delete(professor);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }
    }
}