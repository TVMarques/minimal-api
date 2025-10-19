using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Teste.Dominio.Entidades;

[TestClass]
public sealed class AdministradorServicoTeste
{
    private DbContexto CriarContextoDeTeste()//Parou no Teste de persitência - tem que arrumar isso no code Teste/
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
        //var path = Path.Combine(Directory.GetParent (Directory.GetCurrentDirectory()) .Parent.Parent.Parent.FullName, "API");


        // Configurar o ConfigurationBuilder
        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        //Arrange - Todas as variáveis criadas para fazer as validações.
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);


        //Act - Ação para ser executada pela variável, setando algumas propriedades.
        administradorServico.Incluir(adm);
        administradorServico.BuscaPorId(adm.Id);

        //Assert - Validação dos dados.Testando a leitura(o get)
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
    }

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        //Arrange - Todas as variáveis criadas para fazer as validações.
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);


        //Act - Ação para ser executada pela variável, setando algumas propriedades.
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);

        //Assert - Validação dos dados.Testando a leitura(o get)
        Assert.AreEqual(1, admDoBanco?.Id);
    }
}

//Parou no Criando teste de request