using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IDespesa
{
    public interface IDespesa : IGeneric<Despesa>
    {
        Task<IList<Despesa>> ListarDespesaUsurio(string emailUsuario);

        Task<IList<Despesa>> ListarDespesasNaoPagasMesesAnteiror(string emailUsuario);
    }
}