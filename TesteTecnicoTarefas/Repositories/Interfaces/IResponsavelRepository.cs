using TesteTecnicoTarefas.Models;

namespace TesteTecnicoTarefas.Repositories.Interfaces
{
    public interface IResponsavelRepository
    {
        Task<IEnumerable<ResponsavelModel>> GetAll();
        Task<ResponsavelModel> GetById(int id);
        Task AdcionarResponsavel(ResponsavelModel model);
        Task UpdateResponsavel(ResponsavelModel model, int id);
        Task DeleteResponsavel(int id);
    }
}
