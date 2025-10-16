namespace Prevenir_extintores.DTOs;

public class CreateOrcamentoDto
{
    public string NomeCliente { get; set; } = string.Empty;
    public string EmailCliente { get; set; } = string.Empty;
    public string TelefoneCliente { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public string TipoServico { get; set; } = string.Empty;
}