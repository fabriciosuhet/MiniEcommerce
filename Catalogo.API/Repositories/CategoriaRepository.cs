using Catalogo.API.Entities;
using Catalogo.API.Filters;
using Catalogo.API.Infrastructure;
using Catalogo.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.API.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly CatalogoDbContext _context;

        public CategoriaRepository(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _context.Categorias
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync(CategoriaFiltro filtro)
        {
            IQueryable<Categoria> query = _context.Categorias
                .AsNoTracking()
                .Include(c => c.Produtos);

            if (!string.IsNullOrEmpty(filtro.TermoFiltro))
            {
                query = query.Where(c => c.Nome.Contains(filtro.TermoFiltro));
            }

            if (filtro.ApenasAtivos)
            {
                query = query.Where(c => c.Ativa);
            }

            return await query.ToListAsync();
        }

        public async Task<Categoria?> GetByIdAsync(Guid id)
        {
            return await _context.Categorias
                .AsNoTracking()
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
