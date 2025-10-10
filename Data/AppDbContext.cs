using Prevenir_extintores.Models;
using Microsoft.EntityFrameworkCore;

namespace Prevenir_extintores.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<SolicitacaoOrcamento> SolicitacoesOrcamento { get; set; }
        public DbSet<MensagemContato> MensagensContato { get; set; }
    }
}
