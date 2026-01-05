using Auth.API.Entities;
using Auth.API.Repositories.Interfaces;
using Auth.API.Services.Interfaces;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Auth.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid?> AuthenticateAsync(string email, string senha)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            var hash = SenhaHash(senha);
            return user.SenhaHash == hash ? user.Id : null;
        }

        public async Task<Guid> CreateUserAsync(string email, string senha)
        {
            var existsUser = await _userRepository.GetByEmailAsync(email);

            if (existsUser != null)
            {
                throw new Exception("User already exists");
            }

            var passwordHash = SenhaHash(senha);
            var user = new User(email, passwordHash);

            await _userRepository.AddAsync(user);

            return user.Id;
        }

        public async Task<bool> UserExistsAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return user != null;
        }

        private static string SenhaHash(string senha) 
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes);
        }

    }
}
