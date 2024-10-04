using TesteTecnicoTarefas.Models;

namespace TesteTecnicoTarefas.Repositories.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<IEnumerable<CategoriaModel>> GetAll();
        Task AdcionarCategoria(CategoriaModel model);
        Task DeleteCategoria(int id);
    }
}
