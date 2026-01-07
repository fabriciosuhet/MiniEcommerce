using Catalogo.API.Entities;
using Catalogo.API.Infrastructure;
using Catalogo.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoDbContext _context;
        public ProdutoRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var produtoId = await _context.Produtos
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);

            if (produtoId is null) return;

            _context.Produtos.Remove(produtoId);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _context.Produtos.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetAllAsync(string? query)
        {
            return await _context.Produtos
                .AsNoTracking()
                .Include(p => p.CategoriaId)
                .Where(p => string.IsNullOrEmpty(query) || p.Nome.Contains(query))
                .ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(Guid id)
        {
            return await _context.Produtos
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
