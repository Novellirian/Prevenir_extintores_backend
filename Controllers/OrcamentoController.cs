using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prevenir_extintores.Data;
using Prevenir_extintores.Models;
using Prevenir_extintores.DTOs;

namespace Prevenir_extintores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrcamentoController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/orcamento
        // Endpoint para o formulário público de solicitação de orçamento
        [HttpPost]
        public async Task<ActionResult<SolicitacaoOrcamento>> PostSolicitacao(CreateOrcamentoDto orcamentoDto)
        {
            var novaSolicitacao = new SolicitacaoOrcamento
            {
                NomeCliente = orcamentoDto.NomeCliente,
                EmailCliente = orcamentoDto.EmailCliente,
                TelefoneCliente = orcamentoDto.TelefoneCliente,
                Mensagem = orcamentoDto.Mensagem,
                TipoServico = orcamentoDto.TipoServico,

                // Valores definidos pelo servidor para consistência
                DataSolicitacao = DateTime.UtcNow,
                Status = StatusSolicitacao.Nova // Toda nova solicitação começa com o status "Nova"
            };

            _context.SolicitacoesOrcamento.Add(novaSolicitacao);
            await _context.SaveChangesAsync();

            // Retorna a rota para o método GetSolicitacoes para seguir o padrão RESTful
            return CreatedAtAction(nameof(GetSolicitacoes), new { id = novaSolicitacao.Id }, novaSolicitacao);
        }

        // GET: api/orcamento
        // Endpoint para a área administrativa listar todas as solicitações
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitacaoOrcamento>>> GetSolicitacoes()
        {
            var solicitacoes = await _context.SolicitacoesOrcamento
                                             .OrderByDescending(s => s.DataSolicitacao)
                                             .ToListAsync();
            return Ok(solicitacoes);
        }
    }
}