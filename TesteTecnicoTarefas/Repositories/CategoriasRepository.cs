using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoTarefas.Data;
using TesteTecnicoTarefas.Models;
using TesteTecnicoTarefas.Repositories.Interfaces;

namespace TesteTecnicoTarefas.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoriasRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AdcionarCategoria(CategoriaModel model)
        {
            _appDbContext.Categorias.Add(model);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoria(int id)
        {
            var categoria = await _appDbContext.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria), "A categoria não pode ser nula.");
            }
            _appDbContext.Categorias.Remove(categoria);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoriaModel>> GetAll()
        {
            List<CategoriaModel> lista = await _appDbContext.Categorias.ToListAsync();
            return lista;
        }

    }
}
