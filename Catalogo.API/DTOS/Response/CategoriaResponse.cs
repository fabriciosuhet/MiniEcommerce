namespace Catalogo.API.DTOS.Response
{
    public class CategoriaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public IEnumerable<ProdutoResumoDto> Produtos { get; set; }
    }

    public class ProdutoResumoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
