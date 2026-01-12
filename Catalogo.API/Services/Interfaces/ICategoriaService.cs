using Catalogo.API.DTOS.Response;
using Catalogo.API.Entities;
using Catalogo.API.Filters;

namespace Catalogo.API.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<Guid> CreateAsync(string nome);
        Task<IEnumerable<CategoriaResponse>> GetAllAsync(CategoriaFiltro filtro);
        Task<Categoria?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
