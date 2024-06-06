using Dominio;
using Xunit;
using ExpectedObjects;

namespace Teste
{
    public class ClienteTeste
    {
        [Fact]
        public void TesteCriarCliente()
        {
            var cliente = new Cliente("Victoria", "Rua A", "98765432", "victoria@example.com");
            cliente.Nome.ToExpectedObject().ShouldEqual("Victoria");
            cliente.Endereco.ToExpectedObject().ShouldEqual("Rua A");
            cliente.Telefone.ToExpectedObject().ShouldEqual("98765432");
            cliente.Email.ToExpectedObject().ShouldEqual("victoria@example.com");
        }

        [Fact]
        public void TesteAtualizarInformacoes()
        {
            var cliente = new Cliente("Leonardo", "Rua B", "23456789");
            cliente.AtualizarInformacoes("Rua C", "11223344", "leonardo@example.com");
            cliente.Endereco.ToExpectedObject().ShouldEqual("Rua C");
            cliente.Telefone.ToExpectedObject().ShouldEqual("11223344");
            cliente.Email.ToExpectedObject().ShouldEqual("leonardo@example.com");
        }

        [Fact]
        public void TesteCamposObrigatorios()
        {
            Assert.Throws<ArgumentException>(() => new Cliente("", "Rua D", "55667788"));
            Assert.Throws<ArgumentException>(() => new Cliente("Pedro", "", "55667788"));
            Assert.Throws<ArgumentException>(() => new Cliente("Pedro", "Rua E", ""));
        }
    }
}
