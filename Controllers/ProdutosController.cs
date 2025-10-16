using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prevenir_extintores.Data;
using Prevenir_extintores.Models;
using Prevenir_extintores.DTOs;

namespace Prevenir_extintores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return Ok(produtos);
        }

        // POST: api/produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(CreateProdutoDto produtoDto)
        {
            var novoProduto = new Produto
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                UrlImagem = produtoDto.UrlImagem
            };

            _context.Produtos.Add(novoProduto);
            await _context.SaveChangesAsync();

            // Retorna a rota para o método GetProdutos (poderíamos criar um GetProdutoPorId no futuro)
            // e o objeto criado.
            return CreatedAtAction(nameof(GetProdutos), new { id = novoProduto.Id }, novoProduto);
        }

        // PUT: api/produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, CreateProdutoDto produtoDto)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            produto.Nome = produtoDto.Nome;
            produto.Descricao = produtoDto.Descricao;
            produto.UrlImagem = produtoDto.UrlImagem;

            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}