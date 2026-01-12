using Catalogo.API.DTOS.Request;
using Catalogo.API.Filters;
using Catalogo.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria is null)
            {
                return NotFound();
            }
            return Ok(categoria);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoriaRequest request)
        {
            var categoriaId = await _categoriaService.CreateAsync(request.Nome);
            return CreatedAtAction(nameof(GetById), new { id = categoriaId }, categoriaId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] CategoriaFiltro filtro)
        {
           
            var categorias = await _categoriaService.GetAllAsync(filtro);
            return Ok(categorias);
        }
    }
}
