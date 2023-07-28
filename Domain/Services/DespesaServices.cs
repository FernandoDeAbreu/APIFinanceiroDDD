using Domain.Interfaces.IDespesa;
using Domain.Interfaces.Services;
using Entities.Entidades;

namespace Domain.Services
{
    public class DespesaServices : IDespesaServices
    {
        private readonly IDespesa _despesa;

        public DespesaServices(IDespesa despesa)
        {
            _despesa = despesa;
        }

        public async Task AdicionarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _despesa.Add(despesa);
        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
                despesa.DataPagamento = data;

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _despesa.Add(despesa);
        }
    }
}