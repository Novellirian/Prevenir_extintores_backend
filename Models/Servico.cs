namespace Prevenir_extintores.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string UrlImagem { get; set; } = string.Empty;


        public Servico(int Id, string Nome, string Descricao, string UrlImagem)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.UrlImagem = UrlImagem;
        }
    }
}
