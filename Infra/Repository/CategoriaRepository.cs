using Domain.Interfaces.ICategoria;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public CategoriaRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Categoria>> ListarCategoriaUsuario(string emailUsuario)
        {
            using ( var banco = new ContextBase(_OptionsBuilder))
            {
                return await (from s in banco.SistemaFinanceiros
                              join c in banco.Categorias on s.Id equals c.IdSistema
                              join us in banco.UsuarioSistemaFinanceiros on s.Id equals us.IdSistema
                              where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                              select c).AsNoTracking().ToListAsync();
            }
        }
    }
}