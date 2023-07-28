using Domain.Interfaces.ICategoria;
using Entities.Entidades;
using Infra.Repositorio.Generics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
    {
        public Task<IList<Categoria>> ListarCategoriaUsuario()
        {
            throw new System.NotImplementedException();
        }
    }
}