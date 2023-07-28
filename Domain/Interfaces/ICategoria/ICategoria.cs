using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.ICategoria
{
    public interface ICategoria : IGeneric<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriaUsuario();
    }
}