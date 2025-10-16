namespace Prevenir_extintores.Models
{
    public class Produto
    {
        public int Id { get; set; } = 0;
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string UrlImagem { get; set; } = string.Empty;
        public float Preco { get; private set; }
        public int Estoque { get; private set; }


        public Produto(int Id, string Nome, string Descricao, string UrlImagem, float Preco)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.UrlImagem = UrlImagem;
            this.Preco = Preco;
        }

        private void atualizarPreco(float novoPreco)
        {
            if (novoPreco <= 0)
            {
                throw new ArgumentException("Preço inválido");
            }
            Preco = novoPreco;

        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser positiva.");

            Estoque += quantidade;
        }

        public void RemoverEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser positiva.");

            if (quantidade > Estoque)
                throw new InvalidOperationException("Estoque insuficiente.");

            Estoque -= quantidade;

        }


    }
}
