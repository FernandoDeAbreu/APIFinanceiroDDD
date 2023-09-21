using Domain.Interfaces.ICategoria;
using Domain.Interfaces.Services;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _categoria;
        private readonly ICategoriaServices _categoriaServices;

        public CategoriaController(ICategoria categoria, ICategoriaServices categoriaServices)
        {
            _categoria = categoria;
            _categoriaServices = categoriaServices;
        }

        [HttpGet("/api/ListarCategoriaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriaUsuario(string emailUsuario)
        {
            return _categoria.ListarCategoriaUsuario(emailUsuario);
        }

        [HttpPut("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
            await _categoriaServices.AdicionarCategoria(categoria);
            return categoria;
        }

        [HttpPut("/api/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categoria categoria)
        {
            await _categoriaServices.AtualizarCategoria(categoria);
            return categoria;
        }

        [HttpGet("/api/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            var categoria = await _categoria.GetEntityById(id);
            await _categoria.Delete(categoria);
            return true;
        }
    }
}