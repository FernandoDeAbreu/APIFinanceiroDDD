using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Domain.Interfaces.Services;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly IUsuarioSistemaFinanceiro _usuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServices _usuarioSistemaFinanceiroServices;

        public UsuarioSistemaFinanceiroController(IUsuarioSistemaFinanceiro usuarioSistemaFinanceiro, IUsuarioSistemaFinanceiroServices usuarioSistemaFinanceiroServices)
        {
            _usuarioSistemaFinanceiro = usuarioSistemaFinanceiro;
            _usuarioSistemaFinanceiroServices = usuarioSistemaFinanceiroServices;
        }

        [HttpGet("api/ListarUsuariosSistema")]
        [Produces("application/json")]
        public async Task<object> ListaSistamasUsuario(int idSistema)
        {
            return await _usuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        [HttpPost("api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _usuarioSistemaFinanceiroServices.CadastrarUsuarioNoSistema(
                new UsuarioSistemaFinanceiro
                {
                    IdSistema = idSistema,
                    EmailUsuario = emailUsuario,
                    Administrador = false,
                    SistemaAtual = true,
                });
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        [HttpDelete("api/DeleteUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioNoSistema(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _usuarioSistemaFinanceiro.GetEntityById(id);
                await _usuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}