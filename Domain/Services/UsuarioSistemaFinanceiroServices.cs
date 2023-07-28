using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Domain.Interfaces.Services;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UsuarioSistemaFinanceiroServices : IUsuarioSistemaFinanceiroServices
    {
        private readonly IUsuarioSistemaFinanceiro _usuarioSistemaFinanceiro;

        public UsuarioSistemaFinanceiroServices(IUsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            _usuarioSistemaFinanceiro = usuarioSistemaFinanceiro;
        }

        public async Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _usuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}
