using Microsoft.EntityFrameworkCore;
using ms_tracker.Models;

namespace ms_tracker.Context
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
        {}

        public DbSet<Projeto> Projetos {get; set;}
        public DbSet<Tarefa> Tarefas {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarefa>()
            .HasOne(tarefa => tarefa.Projeto)
            .WithMany(projeto => projeto.Tarefas)
            .HasForeignKey(tarefa => tarefa.ProjetoId);

        }
    }
}