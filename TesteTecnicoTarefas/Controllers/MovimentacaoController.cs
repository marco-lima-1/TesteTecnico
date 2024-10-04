using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoTarefas.Models;
using TesteTecnicoTarefas.Repositories;
using TesteTecnicoTarefas.Repositories.Interfaces;

namespace TesteTecnicoTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoController(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MovimentacaoTarefaModel>> GetAll()
        {
            return await _movimentacaoRepository.GetAll();
           
        }
    }
}
