using Microsoft.EntityFrameworkCore;
using TesteTecnicoTarefas.Models;

namespace TesteTecnicoTarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TarefaModel>()
                .HasMany(t => t.Movimentacoes)
                .WithOne(m => m.Tarefa)
                .HasForeignKey(m => m.TarefaId);
        }


        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<ResponsavelModel> Responsaveis { get; set; }
        public DbSet<MovimentacaoTarefaModel> Movimentacoes { get; set; }


    }
}
