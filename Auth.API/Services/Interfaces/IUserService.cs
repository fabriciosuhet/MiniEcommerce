
namespace Auth.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(string email, string senha);
        Task<Guid?> AuthenticateAsync(string email, string senha);
        Task<bool> UserExistsAsync(Guid userId);
    }
}
