namespace Catalogo.API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Adicione aqui as extensões de infraestrutura conforme necessário
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Adicione aqui as extensões de repositórios conforme necessário
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Adicione aqui as extensões de serviços conforme necessário
            return services;
        }
    }
}
