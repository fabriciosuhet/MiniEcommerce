using Catalogo.API.Entities;

namespace Catalogo.API.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto?> GetByIdAsync(Guid id);
        Task<IEnumerable<Produto>> GetAllAsync(string? query);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Guid id);
        Task<bool> ExisteAsync(Guid id);
    }
}
