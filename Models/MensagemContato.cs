namespace Prevenir_extintores.Models
{
    public class MensagemContato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Lido { get; set; }
    }
}
