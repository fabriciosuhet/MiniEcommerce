namespace Catalogo.API.Filters
{
    public class CategoriaFiltro
    {
        public string? TermoFiltro { get; set; }
        public bool ApenasAtivos { get; set; } = true;
    }
}
