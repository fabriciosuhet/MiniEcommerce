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

        public Produto(string nome, string descricao, decimal preco, int estoque, Guid categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            CategoriaId = categoriaId;
        }

        public void AtualizarDados(
            string nome,
            string descricao,
            decimal preco,
            int estoque,
            Guid categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            CategoriaId = categoriaId;
        }

        public void Inativar()
        {
            Ativo = false;
        }
    }
}
