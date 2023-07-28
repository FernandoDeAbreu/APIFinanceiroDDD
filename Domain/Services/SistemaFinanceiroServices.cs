using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.Services;
using Entities.Entidades;

namespace Domain.Services
{
    public class SistemaFinanceiroServices : ISistemaFinanceiroServices
    {
        private readonly ISistemaFinanceiro _sistemaFinanceiro;

        public SistemaFinanceiroServices(ISistemaFinanceiro sistemaFinanceiro)
        {
            _sistemaFinanceiro = sistemaFinanceiro;
        }

        public async Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
            {
                var data = DateTime.Now;
                sistemaFinanceiro.DiaFechamento = 1;
                sistemaFinanceiro.Ano = data.Year;
                sistemaFinanceiro.Mes = data.Month;
                sistemaFinanceiro.AnoCopia = data.Year;
                sistemaFinanceiro.MesCopia = data.Month;

                await _sistemaFinanceiro.Add(sistemaFinanceiro);
            }
        }

        public async Task AtulizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
            {
                sistemaFinanceiro.DiaFechamento = 1;
                await _sistemaFinanceiro.Update(sistemaFinanceiro);
            }
        }
    }
}