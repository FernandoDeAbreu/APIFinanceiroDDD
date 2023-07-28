using Entities.Entidades;

namespace Domain.Interfaces.Services
{
    public interface ISistemaFinanceiroServices
    {
        Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);

        Task AtulizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
    }
}