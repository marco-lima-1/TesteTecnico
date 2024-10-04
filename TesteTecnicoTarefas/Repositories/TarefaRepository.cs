using Microsoft.EntityFrameworkCore;
using TesteTecnicoTarefas.Data;
using TesteTecnicoTarefas.Models;
using TesteTecnicoTarefas.Repositories.Interfaces;

namespace TesteTecnicoTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _appDbContext;

        public TarefaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AdcionarTarefa(TarefaModel model)
        {
            _appDbContext.Tarefas.Add(model);
            await _appDbContext.SaveChangesAsync();

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "A Tarefa não pode ser nula.");
            }
        }

        public async Task AtualizarTarefa(TarefaModel model, int id)
        {
            var tarefa = await _appDbContext.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
            if (tarefa == null)
            {
                throw new ArgumentNullException(nameof(model), "A Tarefa não pode ser nula.");
            }
            tarefa.Categoria = model.Categoria;
            tarefa.Responsavel = model.Responsavel;
            tarefa.Nome = model.Nome;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task ExcluirTarefa(int id)
        {
            var tarefa = await _appDbContext.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
            _appDbContext.Tarefas.Remove(tarefa);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task FinalizarTarefa(int id)
        {
            var tarefaFinalizada = await _appDbContext.Tarefas.Include(t => t.Movimentacoes).FirstOrDefaultAsync(t => t.Id == id);
            if (tarefaFinalizada == null)
            {
                throw new ArgumentNullException(nameof(tarefaFinalizada), "A Tarefa não pode ser nula.");
            }
            _appDbContext.Movimentacoes.Add(new MovimentacaoTarefaModel
            {
                TarefaId = id,
                DataHora = DateTime.Now,
                Tipo = "Finalizar"
            });

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TarefaModel>> GetAll()
        {
            List<TarefaModel> tarefas = await _appDbContext.Tarefas
            .Include(t => t.Categoria)
            .Include(t => t.Responsavel)
            .Include(t => t.Movimentacoes)
            .ToListAsync();

            return tarefas;

        }

        public async Task<TarefaModel> GetById(int id)
        {
            TarefaModel tarefa = await _appDbContext.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
            return tarefa;
        }

        public async Task IniciarTarefa(int id)
        {
            var tarefaIniciada = await _appDbContext.Tarefas.Include(t => t.Movimentacoes).FirstOrDefaultAsync(t => t.Id == id);
            if (tarefaIniciada == null)
            {
                throw new ArgumentNullException(nameof(tarefaIniciada), "A Tarefa não pode ser nula.");
            }
            _appDbContext.Movimentacoes.Add(new MovimentacaoTarefaModel
            {
                TarefaId = id,
                DataHora = DateTime.Now,
                Tipo = "Iniciar"
            });

            await _appDbContext.SaveChangesAsync();

        }

        public async Task PausarTarefa(int id)
        {
            var tarefaPausada = await _appDbContext.Tarefas.Include(t => t.Movimentacoes).FirstOrDefaultAsync(t => t.Id == id);
            if (tarefaPausada == null)
            {
                throw new ArgumentNullException(nameof(tarefaPausada), "A Tarefa não pode ser nula.");
            }
            _appDbContext.Movimentacoes.Add(new MovimentacaoTarefaModel
            {
                TarefaId = id,
                DataHora = DateTime.Now,
                Tipo = "Pausar"
            });

            await _appDbContext.SaveChangesAsync();
        }
    }
}
