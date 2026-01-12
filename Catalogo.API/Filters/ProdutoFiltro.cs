namespace Catalogo.API.Filters
{
    public class ProdutoFiltro
    {
        public string? TermoBusca { get; set; }
        public Guid? CategoriaId { get; set; }
        public bool ApenasAtivos { get; set; } = true;
    }
}
