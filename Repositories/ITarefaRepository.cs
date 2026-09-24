using GerenciadorProjetos.Models;

namespace GerenciadorProjetos.Repositories
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        IEnumerable<Tarefa> GetAllWithProjetos();
        Tarefa? GetByIdWithProjeto(int id);
    }
}