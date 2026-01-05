namespace Auth.API.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }

        protected User()
        {
            
        }

        public User(string email, string senhaHash)
        {
            Email = email;
            SenhaHash = senhaHash;
        }
    }
}
