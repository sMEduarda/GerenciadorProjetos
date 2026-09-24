using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models;

namespace GerenciadorProjetos.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}