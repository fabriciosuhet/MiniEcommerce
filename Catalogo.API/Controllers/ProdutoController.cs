using Catalogo.API.DTOS.Request;
using Catalogo.API.DTOS.Response;
using Catalogo.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProdutoRequest request)
        {
            var produtoId = await _produtoService.CreateProdutoAsync(
                request.Nome,
                request.Descricao,
                request.Preco,
                request.Estoque,
                request.CategoriaId
                );

            return CreatedAtAction(nameof(GetById) , new { produtoId = produtoId }, new { Id = produtoId});
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto is null)
            {
                return NotFound();
            }

            var response = new ProdutoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque,
                Ativo = produto.Ativo,
                CategoriaId = produto.CategoriaId,
                CategoriaNome = produto.Categoria?.Nome ?? "Não encontrado."
            };

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProdutoRequest request)
        {
            await _produtoService.UpdateProdutoAsync(
               id,
               request.Nome,
               request.Descricao,
               request.Preco,
               request.Estoque,
               request.CategoriaId);

            return NoContent();
        }
    }
}
