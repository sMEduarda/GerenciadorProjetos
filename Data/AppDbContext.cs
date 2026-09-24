using Microsoft.EntityFrameworkCore;
using GerenciadorProjetos.Models;

namespace GerenciadorProjetos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}