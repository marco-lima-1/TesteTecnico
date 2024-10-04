using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoTarefas.Models;
using TesteTecnicoTarefas.Repositories;
using TesteTecnicoTarefas.Repositories.Interfaces;

namespace TesteTecnicoTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriasRepository _categoriasRepository;

        public CategoriaController(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaModel>> GetAll()
        {
            return await _categoriasRepository.GetAll();
        }
        [HttpPost]
        public async Task<ActionResult> AdcionarCategoria(CategoriaModel model)
        {
            await _categoriasRepository.AdcionarCategoria(model);
            return Ok(model);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCategoria(int id)
        {
            await _categoriasRepository.DeleteCategoria(id);
            return Ok();
        }
    }
}
