using Domain.Entities;
using Infrastructure.Persistance.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : Controller
    {
        
        public IRepository<Aluno> _repository;
        public AlunoController()
        {
            _repository = new AlunoRepository();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAlunos()
        {
            var alunos = await _repository.GetAll();
            return Ok(alunos);
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetAluno(int id)
        {
            var aluno = await _repository.GetById(id);
            return Ok(aluno);
        }


        [HttpPost]
        public Aluno AddAluno([FromBody] Aluno aluno)
        {
            _repository.Add(aluno);
            return aluno;
        }


        [HttpPut]
        [Route("{id:int}")]
        public Task<Aluno> UpdateAluno([FromRoute] int id, [FromBody] Aluno aluno)
        {
            var updatedaluno = _repository.Update(id, aluno);
            return updatedaluno;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteMedicine([FromRoute] int id)
        {
            //
            await _repository.Delete(id);
            return Ok("Aluno com o id: " + id + " deletada.");
        }

    }
}
