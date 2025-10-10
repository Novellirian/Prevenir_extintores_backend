using Microsoft.AspNetCore.Mvc;
using Prevenir_extintores.Data;
using Prevenir_extintores.Models;
using Microsoft.EntityFrameworkCore;
using Prevenir_extintores.DTOs; // 1. Importe seus DTOs

namespace Prevenir_extintores.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServicosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/servicos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
    {
        var servicos = await _context.Servicos.ToListAsync();
        return Ok(servicos);
    }

    // --- CÓDIGO NOVO ABAIXO ---

    // 2. Nosso segundo Endpoint: POST /api/servicos
    [HttpPost]
    public async Task<ActionResult<Servico>> PostServico(CreateServicoDto servicoDto)
    {
        // 3. Mapeia o DTO para o Modelo de dados
        var novoServico = new Servico
        {
            Nome = servicoDto.Nome,
            Descricao = servicoDto.Descricao,
            UrlImagem = servicoDto.UrlImagem
        };

        // 4. Adiciona o novo objeto ao DbContext
        _context.Servicos.Add(novoServico);

        // 5. Salva as mudanças no banco de dados
        await _context.SaveChangesAsync();

        // 6. Retorna uma resposta HTTP 201 Created
        return CreatedAtAction(nameof(GetServicos), new { id = novoServico.Id }, novoServico);
    }

    // Adicione este método dentro da classe ServicosController

    // PUT: api/servicos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutServico(int id, CreateServicoDto servicoDto)
    {
        // 1. Encontra o serviço no banco de dados pelo Id
        var servico = await _context.Servicos.FindAsync(id);

        // 2. Se o serviço não for encontrado, retorna um erro 404
        if (servico == null)
        {
            return NotFound();
        }

        // 3. Atualiza as propriedades do objeto que veio do banco
        servico.Nome = servicoDto.Nome;
        servico.Descricao = servicoDto.Descricao;
        servico.UrlImagem = servicoDto.UrlImagem;

        // 4. Marca a entidade como modificada (embora o EF Core geralmente detecte isso)
        _context.Entry(servico).State = EntityState.Modified;

        // 5. Salva as alterações no banco de dados
        await _context.SaveChangesAsync();

        // 6. Retorna uma resposta de sucesso sem conteúdo
        return NoContent();
    }

    // Adicione este método dentro da classe ServicosController

    // DELETE: api/servicos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServico(int id)
    {
        // 1. Encontra o serviço no banco
        var servico = await _context.Servicos.FindAsync(id);
        if (servico == null)
        {
            // 2. Se não existir, retorna 404
            return NotFound();
        }

        // 3. Marca o objeto para ser removido
        _context.Servicos.Remove(servico);

        // 4. Salva as mudanças (aplica a exclusão)
        await _context.SaveChangesAsync();

        // 5. Retorna sucesso sem conteúdo
        return NoContent();
    }
}