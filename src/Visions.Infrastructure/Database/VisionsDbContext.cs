using Microsoft.EntityFrameworkCore;
using Visions.Domain.Models;

namespace Visions.Infrastructure.Database
{
    public class VisionsDbContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Emprestimo> Emprestimos { get; set; }

        public VisionsDbContext( DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VisionsDbContext).Assembly);
        }       


    }
}
