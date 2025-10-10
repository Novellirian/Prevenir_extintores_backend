// Lembre-se de ajustar o namespace se o seu projeto tiver um nome diferente
using Prevenir_extintores.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- SEÇÃO DE CONFIGURAÇÃO DOS SERVIÇOS ---

// 1. Buscando a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrando o DbContext no container de Injeção de Dependência
// Esta é a linha que a ferramenta de migration precisa encontrar.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString)
);

// Adicionando o serviço de Controllers (para a API funcionar)
builder.Services.AddControllers();

// Serviços para documentação da API (Swagger), que já vêm no template
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// --- FIM DA SEÇÃO DE CONFIGURAÇÃO ---


var app = builder.Build();

// Configurando o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();