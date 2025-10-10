namespace Prevenir_extintores.Models
{
    public class MensagemContato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataEnvio { get; set; }
        public bool Lido { get; set; }




        public MensagemContato(int id, string nome, string email, string mensagem, DateTime dataEnvio, bool lido)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Mensagem = mensagem;
            DataEnvio = dataEnvio;
            Lido = lido;
        }
    }
}
