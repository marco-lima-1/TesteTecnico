using Microsoft.EntityFrameworkCore;
using TesteTecnicoTarefas.Data;
using TesteTecnicoTarefas.Models;
using TesteTecnicoTarefas.Repositories.Interfaces;

namespace TesteTecnicoTarefas.Repositories
{
    public class ResponsavelRepository : IResponsavelRepository
    {
        private readonly AppDbContext _appDbContext;

        public ResponsavelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AdcionarResponsavel(ResponsavelModel model)
        {
             _appDbContext.Responsaveis.Add(model);
             await _appDbContext.SaveChangesAsync();
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "O responsavel não pode ser nula.");
            }
        }

        public async Task DeleteResponsavel(int id)
        {
            var responsavel = await _appDbContext.Responsaveis.FirstOrDefaultAsync(x => x.Id == id);

            if (responsavel == null)
            {
                throw new ArgumentNullException(nameof(responsavel), "O responsavel não pode ser nula.");
            }

            _appDbContext.Responsaveis.Remove(responsavel);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ResponsavelModel>> GetAll()
        {
            List<ResponsavelModel> lista = await _appDbContext.Responsaveis.ToListAsync();
            return lista;
        }

        public async Task<ResponsavelModel> GetById(int id)
        {
            ResponsavelModel responsavel = await _appDbContext.Responsaveis.FirstOrDefaultAsync(x => x.Id == id);
            if (responsavel == null)
            {
                throw new ArgumentNullException(nameof(responsavel), "O responsavel não pode ser nula.");
            }
            return responsavel;
        }

        public async Task UpdateResponsavel(ResponsavelModel model, int id)
        {
            var user = await _appDbContext.Responsaveis.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(model), "O responsavel não pode ser nula.");
            }

            user.Tarefas = model.Tarefas;
            user.Nome = model.Nome;
            await _appDbContext.SaveChangesAsync();

            
        }
    }
}
