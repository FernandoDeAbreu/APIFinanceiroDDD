using Domain.Interfaces.IDespesa;
using Entities.Entidades;
using Infra.Repositorio.Generics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class DespesaRepository : GenericRepository<Despesa>, IDespesa
    {
        public Task<IList<Despesa>> ListarDespesasNaoPagasMesesAnteiror(string emailUsuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Despesa>> ListarDespesaUsurio(string emailUsuario)
        {
            throw new System.NotImplementedException();
        }
    }
}