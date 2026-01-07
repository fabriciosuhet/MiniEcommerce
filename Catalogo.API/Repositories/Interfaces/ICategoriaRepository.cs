using Catalogo.API.Entities;

namespace Catalogo.API.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllAsync(string query);
        Task<Categoria?> GetByIdAsync(Guid id);
        Task<bool> ExisteAsync(Guid id);
    }
}
