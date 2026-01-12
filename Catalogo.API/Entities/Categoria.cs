namespace Catalogo.API.Entities
{
    public class Categoria
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public bool Ativa { get; private set; } = true;
        public ICollection<Produto> Produtos { get; set; } = [];

        public Categoria(string nome)
        {
            ValidateDomain(nome);
        }

        public void Atualizar(string nome, bool ativa)
        {
            ValidateDomain(nome);
            Nome = nome;
            Ativa = ativa;
        }

        private void ValidateDomain(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new DomainException("O nome da categoria é obrigatório.");
            }
            if (nome.Length < 3)
            {
                throw new DomainException("O nome da categoria deve ter pelo menos 3 caracteres.");
            }

            Nome = nome;
        }
    }
}
