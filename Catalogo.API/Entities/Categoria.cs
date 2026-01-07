namespace Catalogo.API.Entities
{
    public class Categoria
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public bool Ativa { get; private set; }
        public ICollection<Produto> Produtos { get; set; } = [];
        public Guid ProdutoId { get; set; }

        public Categoria(string nome, bool ativa)
        {
            Nome = nome;
            Ativa = ativa;
        }
    }
}
