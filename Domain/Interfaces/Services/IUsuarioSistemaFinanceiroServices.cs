using Entities.Entidades;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioSistemaFinanceiroServices
    {
        Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);
    }
}