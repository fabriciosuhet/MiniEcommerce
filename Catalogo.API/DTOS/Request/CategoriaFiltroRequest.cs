namespace Catalogo.API.DTOS.Request
{
    public class CategoriaFiltroRequest
    {
        public string? TermoFiltro { get; set; }
        public bool ApenasAtivos { get; set; }
    }
}
