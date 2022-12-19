using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/professor")]
    public class ProfessorController : Controller
    {
        
            public IRepository<Professor> _repository;
            public ProfessorController()
            {
                _repository = new ProfessorRepository();
            }

            [HttpGet("GetAllProfessors")]
            public async Task<IActionResult> GetAllProfessores()
            {
                var professores = await _repository.GetAll();
                return Ok(professores);
            }

            [HttpGet("GetOne")]
            public async Task<IActionResult> GetProfessor(int id)
            {
                var professor = await _repository.GetById(id);
                return Ok(professor);
            }


            [HttpPost]
            public Professor AddProfessor([FromBody] Professor professor)
            {
                _repository.Add(professor);
                return professor;
            }


            [HttpPut]
            [Route("{id:int}")]
            public Task<Professor> UpdateAluno([FromRoute] int id, [FromBody] Professor professor)
            {
                var updatedprofessor = _repository.Update(id, professor);
                return updatedprofessor;
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<IActionResult> DeleteMedicine([FromRoute] int id)
            {
                //
                await _repository.Delete(id);
                return Ok("Professor com o id: " + id + " deletada.");
            }
        
    }
}
