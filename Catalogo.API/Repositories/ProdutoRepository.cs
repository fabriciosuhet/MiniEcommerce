using Catalogo.API.Entities;
using Catalogo.API.Filters;
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
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produtoId is null) return;

            _context.Produtos.Remove(produtoId);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _context.Produtos.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetAllAsync(ProdutoFiltro filtro)
        {
            IQueryable<Produto> query = _context.Produtos
                .AsNoTracking()
                .Include(p => p.Categoria);

            if (!string.IsNullOrEmpty(filtro.TermoBusca))
            {
                query = query.Where(p => p.Nome.Contains(filtro.TermoBusca));
            }

            if (filtro.CategoriaId.HasValue)
            {
                query = query.Where(p => p.CategoriaId == filtro.CategoriaId.Value);
            }

            if (filtro.ApenasAtivos)
            {
                query = query.Where(p => p.Ativo);
            }

            return await query.ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(Guid id)
        {
            return await _context.Produtos
                .AsNoTracking()
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
