using Catalogo.API.Repositories;
using Catalogo.API.Repositories.Interfaces;
using Catalogo.API.Services;
using Catalogo.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CatalogoDbContext>(opt => opt.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            return services;
        }
    }
}
