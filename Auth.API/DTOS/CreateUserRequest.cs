namespace Auth.API.DTOS
{
    public record CreateUserRequest(string Email, string Senha);
    public record LoginRequest(string Email, string Senha);
}
