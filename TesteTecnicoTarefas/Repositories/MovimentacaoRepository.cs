using Microsoft.EntityFrameworkCore;
using TesteTecnicoTarefas.Data;
using TesteTecnicoTarefas.Models;
using TesteTecnicoTarefas.Repositories.Interfaces;

namespace TesteTecnicoTarefas.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly AppDbContext _appDbContext;

        public MovimentacaoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<MovimentacaoTarefaModel>> GetAll()
        {
            List<MovimentacaoTarefaModel> movi = await _appDbContext.Movimentacoes.ToListAsync();
            if(movi == null)
            {
                throw new Exception("Nenhuma movimentação encontrada.");
            }
            return movi;
        }
    }
}
