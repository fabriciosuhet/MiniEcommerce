using Catalogo.API.DTOS.Response;
using Catalogo.API.Entities;
using Catalogo.API.Filters;
using Catalogo.API.Repositories.Interfaces;
using Catalogo.API.Services.Interfaces;

namespace Catalogo.API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Guid> CreateAsync(string nome)
        {
            var categoria = new Categoria(nome);

            await _categoriaRepository.AddAsync(categoria);
            return categoria.Id;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
           return await _categoriaRepository.ExisteAsync(id);
        }

        public async Task<IEnumerable<CategoriaResponse>> GetAllAsync(CategoriaFiltro filtro)
        {
            var categoriaEntidade = await _categoriaRepository.GetAllAsync(filtro);
            var resultado = categoriaEntidade.Select(c => new CategoriaResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Ativa = c.Ativa,
                Produtos = c.Produtos.Select(p => new ProdutoResumoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco
                })
            });

            return [.. resultado];
        }

        public async Task<Categoria?> GetByIdAsync(Guid id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }
    }
}
