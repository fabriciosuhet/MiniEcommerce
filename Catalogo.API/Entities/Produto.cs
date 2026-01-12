namespace Catalogo.API.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public bool Ativo { get; private set; } = true;
        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        protected Produto() { }

        public Produto(string nome, string descricao, decimal preco, int estoque, Guid categoriaId)
        {
            ValidateDomain(nome, descricao, preco, estoque, categoriaId);
        }

        public void AtualizarDados(string nome, string descricao, decimal preco, int estoque, Guid categoriaId)
        {
            ValidateDomain(nome, descricao, preco, estoque, categoriaId);
        }

        public void Inativar()
        {       
            if (!Ativo) throw new DomainException("Produto já está inativo");
            Ativo = false;
        }

        private void ValidateDomain(string nome, string descricao, decimal preco, int estoque, Guid categoriaId)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new DomainException("O nome do produto é obrigatório");
            }

            if (string.IsNullOrEmpty(descricao))
            {
                throw new DomainException("A descrição do produto é obrigatória.");
            }

            if (nome.Length < 3)
            {
                throw new DomainException("O nome do produto deve ter pelo menos 3 caracteres.");
            }

            if (preco < 0)
            {
                throw new DomainException("O preço não pode ser negativo");
            }

            if (estoque < 0)
            {
                throw new DomainException("O estoque não pode ser negativo");
            }

            if (categoriaId == Guid.Empty)
            {
                throw new DomainException("A categória é inválida");
            }

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            CategoriaId = categoriaId;

        }
    }

    public class DomainException : Exception
    {
        public DomainException(string error) : base(error) { }
    }
}
