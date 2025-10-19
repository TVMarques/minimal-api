using minimal_api.Dominio.Entidades;

namespace Teste.Dominio.Entidades;

[TestClass]
public sealed class VeiculoTeste
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange - Todas as variáveis criadas para fazer as validações.
        var veiculo = new Veiculo();

        //Act - Ação para ser executada pela variável, setando algumas propriedades.
        veiculo.Id = 1;
        veiculo.Nome = "Civic";
        veiculo.Marca = "Honda";
        veiculo.Ano = 2024;

        //Assert - Validação dos dados.Testando a leitura(o get)
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Civic", veiculo.Nome);
        Assert.AreEqual("Honda", veiculo.Marca);
        Assert.AreEqual(2024, veiculo.Ano);

    }
}