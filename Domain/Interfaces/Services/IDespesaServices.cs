using Entities.Entidades;

namespace Domain.Interfaces.Services
{
    public interface IDespesaServices
    {
        Task AdicionarDespesa(Despesa despesa);

        Task AtualizarDespesa(Despesa despesa);
    }
}