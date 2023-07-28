using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("SistemaFinanceiro")]
    public class SistemaFinanceiro : Base
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int DiaFechamento { get; set; }
        public bool GerarCopiaDespesa { get; set; }
        public bool MesCopia { get; set; }
        public bool AnoCopia { get; set; }
    }
}