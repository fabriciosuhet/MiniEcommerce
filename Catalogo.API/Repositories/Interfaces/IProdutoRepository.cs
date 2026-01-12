using Catalogo.API.Entities;
using Catalogo.API.Filters;

namespace Catalogo.API.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto?> GetByIdAsync(Guid id);
        Task<IEnumerable<Produto>> GetAllAsync(ProdutoFiltro filtro);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Guid id);
        Task<bool> ExisteAsync(Guid id);
    }
}
