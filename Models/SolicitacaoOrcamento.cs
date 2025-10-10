namespace Prevenir_extintores.Models
{
    public class SolicitacaoOrcamento
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string EmailCliente { get; set; } = string.Empty;
        public string TelefoneCliente { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public string TipoServico { get; set; } = string.Empty;
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;
        public StatusSolicitacao Status { get; set; }


        public SolicitacaoOrcamento(int Id, string NomeCliente, string EmailCliente, string TelefoneCliente, string Mensagem, string TipoServico)
        {
            this.Id = Id;
            this.NomeCliente = NomeCliente;
            this.EmailCliente = EmailCliente;
            this.TelefoneCliente = TelefoneCliente;
            this.Mensagem = Mensagem;
            this.TipoServico = TipoServico;
        }
    }
}
