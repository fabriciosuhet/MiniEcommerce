using Catalogo.API.Entities;

namespace Catalogo.API.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Guid> CreateProdutoAsync(string nome, string descricao, decimal preco, int estoque, Guid categoriaId);
        Task UpdateProdutoAsync(Guid produtoId, string nome, string descricao, decimal preco, int estoque, Guid categoriaId);
        Task<Produto?> GetByIdAsync(Guid produtoId);
        Task<bool> ExistsAsync(Guid produtoId);
    }
}
