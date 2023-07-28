using Domain.Interfaces.ICategoria;
using Domain.Interfaces.Services;
using Entities.Entidades;

namespace Domain.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoria _categoria;

        public CategoriaServices(ICategoria categoria)
        {
            _categoria = categoria;
        }

        public async Task AdicionarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidarPropriedadeString(categoria.Nome, "Nome");
            if (valido)
                await _categoria.Add(categoria);
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidarPropriedadeString(categoria.Nome, "Nome");
            if (valido)
                await _categoria.Update(categoria);
        }
    }
}