using TesteTecnicoTarefas.Models;

namespace TesteTecnicoTarefas.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<TarefaModel>> GetAll();
        Task<TarefaModel> GetById(int id);
        Task AdcionarTarefa(TarefaModel model);
        Task AtualizarTarefa(TarefaModel model, int id);
        Task ExcluirTarefa(int id);
        Task IniciarTarefa(int id);
        Task PausarTarefa(int id);
        Task FinalizarTarefa(int id);

    }
}
