using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prevenir_extintores.Data;
using Prevenir_extintores.Models;
using Prevenir_extintores.DTOs;

namespace Prevenir_extintores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContatoController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/contato
        // Este endpoint será usado pelo formulário público do site
        [HttpPost]
        public async Task<ActionResult<MensagemContato>> PostMensagemContato(CreateMensagemContatoDto mensagemDto)
        {
            var novaMensagem = new MensagemContato
            {
                Nome = mensagemDto.Nome,
                Email = mensagemDto.Email,
                Mensagem = mensagemDto.Mensagem,
                // Definimos os valores padrão no backend para segurança e consistência
                DataEnvio = DateTime.UtcNow,
                Lido = false
            };

            _context.MensagensContato.Add(novaMensagem);
            await _context.SaveChangesAsync();

            // Retornamos 201 Created com o objeto salvo
            return CreatedAtAction(nameof(GetMensagens), new { id = novaMensagem.Id }, novaMensagem);
        }

        // GET: api/contato
        // Este endpoint será usado pela área administrativa do site
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MensagemContato>>> GetMensagens()
        {
            var mensagens = await _context.MensagensContato.OrderByDescending(m => m.DataEnvio).ToListAsync();
            return Ok(mensagens);
        }
    }
}