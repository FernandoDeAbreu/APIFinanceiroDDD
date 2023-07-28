using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.ISistemaFinanceiro
{
    public interface ISistemaFinanceiro : IGeneric<SistemaFinanceiro>
    {
        Task<IList<SistemaFinanceiro>> ListaSistemaUsuario(string emailUsuario);
    }
}