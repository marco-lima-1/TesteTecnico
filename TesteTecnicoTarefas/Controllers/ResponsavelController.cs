using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoTarefas.Models;
using TesteTecnicoTarefas.Repositories.Interfaces;

namespace TesteTecnicoTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsavelController : ControllerBase
    {
        private readonly IResponsavelRepository _responsavelRepository;

        public ResponsavelController(IResponsavelRepository responsavelRepository)
        {
            _responsavelRepository = responsavelRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AdcionarResponsavel(ResponsavelModel model)
        {
            await _responsavelRepository.AdcionarResponsavel(model);
            return Ok(model);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteResponsavel(int id)
        {
            await _responsavelRepository.DeleteResponsavel(id);
            return Ok("Responsavel deletado com sucesso");
        }

        [HttpGet]
        public async Task<IEnumerable<ResponsavelModel>> GetAll()
        {
            return await _responsavelRepository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ResponsavelModel> GetById(int id)
        {
            return await _responsavelRepository.GetById(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateResponsavel(ResponsavelModel model, int id)
        {
            await _responsavelRepository.UpdateResponsavel(model, id);
            return Ok(model);
        }
    }
}
