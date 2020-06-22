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
    public class AlunosController : ControllerBase
    {
        public IRepository _repository { get; }
        public AlunosController(IRepository repository)
        {
            _repository = repository;
        }

        // GET api/alunos
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllAlunosAsync(true);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/alunos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetAlunoAsyncById(id, true);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/alunos/professor/5
        [HttpGet("professor/{id}")]
        public async Task<IActionResult> GetByProfessorId(int id)
        {
            try
            {
                var result = await _repository.GetAlunosAsyncByProfessorId(id, true);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/alunos
        [HttpPost("")]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangesAsync())
                    return Created($"/api/alunos/{model.Id}", model);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        // PUT api/alunos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Aluno model)
        {
            try
            {
                var aluno = await _repository.GetAlunoAsyncById(id);
                if (aluno == null)
                    return NotFound();
                
                model.Id = id;
                _repository.Update(model);

                if (await _repository.SaveChangesAsync())
                {
                    aluno = await _repository.GetAlunoAsyncById(id);
                    return Created($"/api/alunos/{aluno.Id}", aluno);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        // DELETE api/alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var aluno = await _repository.GetAlunoAsyncById(id);
                if (aluno == null)
                    return NotFound();

                _repository.Delete(aluno);

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