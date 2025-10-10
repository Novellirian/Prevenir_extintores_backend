namespace Prevenir_extintores.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public PapelUsuario Papel { get; set; }


        public Usuario(int Id, string Nome, string Email, string SenhaHash, PapelUsuario Papel)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Email = Email;
            this.SenhaHash = SenhaHash;
            this.Papel = Papel;
        }
    }
}
