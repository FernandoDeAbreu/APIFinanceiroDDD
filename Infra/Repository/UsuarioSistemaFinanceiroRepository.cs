using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class UsuarioSistemaFinanceiroRepository : GenericRepository<UsuarioSistemaFinanceiro>, IUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions _OptionsBuilder;

        public UsuarioSistemaFinanceiroRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.UsuarioSistemaFinanceiros
                    .Where(s => s.IdSistema == IdSistema).AsNoTracking().ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.UsuarioSistemaFinanceiros.AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                banco.UsuarioSistemaFinanceiros.RemoveRange(usuarios);
                await banco.SaveChangesAsync();
            }

        }
    }
}