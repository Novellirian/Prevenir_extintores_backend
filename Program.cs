// Lembre-se de ajustar o namespace se o seu projeto tiver um nome diferente
using Prevenir_extintores.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- SE��O DE CONFIGURA��O DOS SERVI�OS ---

// 1. Buscando a string de conex�o do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrando o DbContext no container de Inje��o de Depend�ncia
// Esta � a linha que a ferramenta de migration precisa encontrar.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString)
);

// Adicionando o servi�o de Controllers (para a API funcionar)
builder.Services.AddControllers();

// Servi�os para documenta��o da API (Swagger), que j� v�m no template
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// --- FIM DA SE��O DE CONFIGURA��O ---


var app = builder.Build();

// Configurando o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();