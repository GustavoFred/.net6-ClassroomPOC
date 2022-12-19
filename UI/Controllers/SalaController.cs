using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/sala")]
    public class SalaController : Controller
    {

        public IRepository<Sala> _repository;
        public SalaController()
        {
            _repository = new SalaRepository();
        }

        [HttpGet("GetAllSalas")]
        public async Task<IActionResult> GetAllSalas()
        {
            var salas = await _repository.GetAll();
            return Ok(salas);
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetSala(int id)
        {
            var sala = await _repository.GetById(id);
            return Ok(sala);
        }


        [HttpPost]
        public Sala AddSala([FromBody] Sala sala)
        {
            _repository.Add(sala);
            return sala;
        }


        [HttpPut]
        [Route("{id:int}")]
        public Task<Sala> UpdateAluno([FromRoute] int id, [FromBody] Sala sala)
        {
            var updatedSala = _repository.Update(id, sala);
            return updatedSala;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteMedicine([FromRoute] int id)
        {
            //
            await _repository.Delete(id);
            return Ok("Sala com o id: " + id + " deletada.");
        }

    }
}
