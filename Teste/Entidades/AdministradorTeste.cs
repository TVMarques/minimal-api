using minimal_api.Dominio.Entidades;

namespace Teste.Dominio.Entidades;

[TestClass]
public sealed class AdministradorTeste
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange - Todas as variáveis criadas para fazer as validações.
        var adm = new Administrador();

        //Act - Ação para ser executada pela variável, setando algumas propriedades.
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        //Assert - Validação dos dados.Testando a leitura(o get)
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("teste", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);

    }
}