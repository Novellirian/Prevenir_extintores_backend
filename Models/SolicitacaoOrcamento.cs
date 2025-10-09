namespace Prevenir_extintores.Models
{
    public class SolicitacaoOrcamento
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public string Mensagem { get; set; }
        public string TipoServico { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public StatusSolicitacao Status { get; set; }
    }
}
