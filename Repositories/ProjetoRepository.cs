using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models;

namespace GerenciadorProjetos.Repositories
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}