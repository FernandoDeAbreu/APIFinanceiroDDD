using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class SistemaFinanceiroRepository : GenericRepository<SistemaFinanceiro>, ISistemaFinanceiro
    {
        private readonly DbContextOptions _OptionsBuider;

        public SistemaFinanceiroRepository()
        {
            _OptionsBuider = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<SistemaFinanceiro>> ListaSistemaUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuider))
            {
                return await
                    (from s in banco.SistemaFinanceiros
                     join us in banco.UsuarioSistemaFinanceiros on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario)
                     select s).AsNoTracking().ToListAsync();
            }
        }
    }
}