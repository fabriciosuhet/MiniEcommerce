namespace Catalogo.API.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public bool Ativo { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(string nome, string descricao, decimal preco, int estoque, bool ativo, Guid categoriaId, Categoria categoria)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            Ativo = ativo;
            CategoriaId = categoriaId;
            Categoria = categoria;
        }
    }
}
