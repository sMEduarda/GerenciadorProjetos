using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorProjetos.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Tarefa> GetAllWithProjetos()
        {
            return _context.Tarefas
                .Include(t => t.Projeto)
                .ToList();
        }

        public Tarefa? GetByIdWithProjeto(int id)
        {
            return _context.Tarefas
                .Include(t => t.Projeto)
                .FirstOrDefault(t => t.Id == id);
        }
    }
}