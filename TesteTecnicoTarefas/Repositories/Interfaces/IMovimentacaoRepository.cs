using TesteTecnicoTarefas.Models;

namespace TesteTecnicoTarefas.Repositories.Interfaces
{
    public interface IMovimentacaoRepository
    {
        Task<IEnumerable<MovimentacaoTarefaModel>> GetAll();
    }
}
