using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Infraestrutura.Db;


var builder = WebApplication.CreateBuilder(args);

//Importando o serviço do banco no programa principal.
builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();

app.MapGet("/", () => "Olá mundo !");

//Validação de login/senha com este método.
app.MapPost("/login", (LoginDTO loginDTO) =>
{
    //Se o no método loginDTO for passado o email e senha, faz o login.
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
    {
        return Results.Ok("Login feito com sucesso!");
    }
    else
    {
        return Results.Unauthorized();//Senão, não autoriza o login.
    }
});

app.Run();
