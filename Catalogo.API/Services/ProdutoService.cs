using Catalogo.API.Entities;
using Catalogo.API.Repositories.Interfaces;
using Catalogo.API.Services.Interfaces;

namespace Catalogo.API.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoService(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Guid> CreateProdutoAsync(string nome, string descricao, decimal preco, int estoque, Guid categoriaId)
        {
            var categoriaExiste = await _categoriaRepository.ExisteAsync(categoriaId);
           
            var produto = new Produto(nome, descricao, preco, estoque, categoriaId);

            await _produtoRepository.AddAsync(produto);

            return produto.Id;
        }

        public async Task<bool> ExistsAsync(Guid produtoId)
        {
            return await _produtoRepository.ExisteAsync(produtoId);
        }

        public async Task<Produto?> GetByIdAsync(Guid produtoId)
        {
            return await _produtoRepository.GetByIdAsync(produtoId);
        }

        public async Task UpdateProdutoAsync(Guid produtoId, string nome, string descricao, decimal preco, int estoque, Guid categoriaId)
        {
            var produto = await _produtoRepository.GetByIdAsync(produtoId);
            if (produto is null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }

            var categoriaExiste = await _categoriaRepository.ExisteAsync(categoriaId);
            if (!categoriaExiste)
            {
                throw new DomainException("Categoria não encontrada");
            }
            
            produto.AtualizarDados(nome, descricao, preco, estoque, categoriaId);

            await _produtoRepository.UpdateAsync(produto);
        }
    }
}
