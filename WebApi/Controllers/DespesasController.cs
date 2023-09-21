using Domain.Interfaces.IDespesa;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesa _despesas;
        private readonly IDespesaServices _despesaServices;
        public DespesasController(IDespesaServices despesaServices, IDespesa despesas)
        {
            _despesaServices = despesaServices;
            _despesas = despesas;
        }
    }
}
