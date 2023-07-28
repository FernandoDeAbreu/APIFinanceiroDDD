using Entities.Entidades;

namespace Domain.Interfaces.Services
{
    public interface ICategoriaServices
    {
        Task AdicionarCategoria(Categoria categoria);
        Task AtualizarCategoria(Categoria categoria);
    }
}