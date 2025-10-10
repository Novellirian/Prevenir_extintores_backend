namespace Prevenir_extintores.Models
{
    public class Produto
    {
        public int Id { get; set; } = 0;
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string UrlImagem { get; set; } = string.Empty;
        public float Preco { get; set; }


        public Produto(int Id, string Nome, string Descricao, string UrlImagem, float Preco)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.UrlImagem = UrlImagem;
            this.Preco = Preco;
        }

        private void atualizarPreco()
        {
            Console.WriteLine("Preço atualizado");
        }

        private void consultarEstoque()
        {
            Console.WriteLine("Estoque atualizado");
        }
        private void atualizarEstoque()
        {
            Console.WriteLine("Consulta do Estoque concluída");
        }
    }


}
