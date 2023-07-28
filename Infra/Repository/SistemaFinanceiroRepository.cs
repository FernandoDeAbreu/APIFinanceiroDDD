using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Infra.Repositorio.Generics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class SistemaFinanceiroRepository : GenericRepository<SistemaFinanceiro>, ISistemaFinanceiro
    {
        public Task<IList<SistemaFinanceiro>> ListaSistemaUsuario(string emailUsuario)
        {
            throw new System.NotImplementedException();
        }
    }
}