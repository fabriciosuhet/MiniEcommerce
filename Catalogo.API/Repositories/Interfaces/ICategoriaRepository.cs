using Catalogo.API.Entities;
using Catalogo.API.Filters;

namespace Catalogo.API.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllAsync(CategoriaFiltro filtro);
        Task<Categoria?> GetByIdAsync(Guid id);
        Task<bool> ExisteAsync(Guid id);
        Task AddAsync(Categoria categoria);
    }
}
