using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoTarefas.Models;
using TesteTecnicoTarefas.Repositories;
using TesteTecnicoTarefas.Repositories.Interfaces;

namespace TesteTecnicoTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AdcionarTarefa(TarefaModel model)
        {
            await _tarefaRepository.AdcionarTarefa(model);
            return Ok(model);
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarTarefa(TarefaModel model, int id)
        {
            await _tarefaRepository.AtualizarTarefa(model, id);
            return Ok(model);
        }
        [HttpDelete]
        public async Task<ActionResult> ExcluirTarefa(int id)
        {
            await _tarefaRepository.ExcluirTarefa(id);
            return Ok();
        }
        [HttpPost("Finalizar tarefa")]
        public async Task<ActionResult> FinalizarTarefa(int id)
        {
            await _tarefaRepository.FinalizarTarefa(id);
            return Ok("A tarefa foi finalizada com sucesso.");
        }
        [HttpPost("Iniciar tarefa")]
        public async Task<ActionResult> IniciarTarefa(int id)
        {
            await _tarefaRepository.IniciarTarefa(id);
            return Ok("A tarefa foi iniciada com sucesso.");
        }
        [HttpPost("Pausar tarefa")]
        public async Task<ActionResult> PausarTarefa(int id)
        {
            await _tarefaRepository.PausarTarefa(id);
            return Ok("A tarefa foi pausada com sucesso.");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var user = await _tarefaRepository.GetById(id);
            return Ok(user);
        }
        [HttpGet("Buscar todas as tarefas")]
        public async Task<IEnumerable<TarefaModel>> GetAll()
        {
            return await _tarefaRepository.GetAll();
            
        }
    }
}
