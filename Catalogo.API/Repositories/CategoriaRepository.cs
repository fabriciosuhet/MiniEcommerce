using Catalogo.API.Entities;
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

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _context.Categorias
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync(string query)
        {
            return await _context.Categorias
                .AsNoTracking()
                .Where(c => string.IsNullOrEmpty(query) || c.Nome.Contains(query))
                .ToListAsync(); 
        }

        public async Task<Categoria?> GetByIdAsync(Guid id)
        {
            return await _context.Categorias
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
