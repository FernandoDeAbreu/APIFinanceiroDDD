using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.Services;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SistemaFinanceiroController : ControllerBase
    {
        private readonly ISistemaFinanceiro _iSistemaFinanceiro;
        private readonly ISistemaFinanceiroServices _iSistemaFinanceiroServices;

        public SistemaFinanceiroController(ISistemaFinanceiro iSistemaFinanceiro, ISistemaFinanceiroServices iSistemaFinanceiroServices)
        {
            _iSistemaFinanceiro = iSistemaFinanceiro;
            _iSistemaFinanceiroServices = iSistemaFinanceiroServices;
        }

        [HttpGet("/api/ListaSistemasUsuario")]
        [Produces("application/json")]
        public async Task<Object> ListaSistemaUsuario(string emailUsuario)
        {
            return await _iSistemaFinanceiro.ListaSistemaUsuario(emailUsuario);
        }

        [HttpPost("/api/AddSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<Object> AddSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiroServices.AdicionarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<Object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiroServices.AtualizarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpGet("/api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<Object> ObterSistemaFinanceiro(int id)
        {
            return await _iSistemaFinanceiro.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<Object> DeleteSistemaFinanceiro(int id)
        {
            try
            {
                var sistemaFinanceiro = await _iSistemaFinanceiro.GetEntityById(id);
                await _iSistemaFinanceiro.Delete(sistemaFinanceiro);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}