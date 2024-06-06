using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ExpectedObjects;
using Xunit;

namespace Teste
{
    public class CadastroFornecedoresTests
    {
        [Fact]
        public void TesteCadastroNovoFornecedor()
        {
            var cadastro = new CadastroFornecedores();
            var fornecedor = new Fornecedor("Victoria Ltda", "Rua Y", "9876-5432", "contato@victoria.com", "30 dias");

            cadastro.CadastrarFornecedor(fornecedor);

            var fornecedorCadastrado = cadastro.VisualizarDetalhes(fornecedor.Id);
            fornecedor.ToExpectedObject().ShouldMatch(fornecedorCadastrado);
        }

        [Fact]
        public void TesteCadastroFornecedorDuplicado()
        {
            var cadastro = new CadastroFornecedores();
            var fornecedor1 = new Fornecedor("Victoria Ltda", "Rua Y", "9876-5432");
            var fornecedor2 = new Fornecedor("Victoria Ltda", "Rua Z", "9876-5432");

            cadastro.CadastrarFornecedor(fornecedor1);
            Assert.Throws<InvalidOperationException>(() => cadastro.CadastrarFornecedor(fornecedor2));
        }

        [Fact]
        public void TesteAtualizacaoFornecedor()
        {
            var cadastro = new CadastroFornecedores();
            var fornecedor = new Fornecedor("Victoria Ltda", "Rua Y", "9876-5432");

            cadastro.CadastrarFornecedor(fornecedor);
            cadastro.AtualizarFornecedor(fornecedor.Id, "Rua Z", "5678-1234", "novoemail@victoria.com", "60 dias");

            var fornecedorAtualizado = cadastro.VisualizarDetalhes(fornecedor.Id);
            var expectedFornecedor = new
            {
                NomeEmpresa = "Victoria Ltda",
                Endereco = "Rua Z",
                Telefone = "5678-1234",
                Email = "novoemail@victoria.com",
                TermosPagamento = "60 dias",
                Id = fornecedor.Id
            };

            expectedFornecedor.ToExpectedObject().ShouldMatch(fornecedorAtualizado);
        }

        [Fact]
        public void TesteBuscaFornecedor()
        {
            var cadastro = new CadastroFornecedores();
            var fornecedor = new Fornecedor("Victoria Ltda", "Rua Y", "9876-5432", "contato@victoria.com");

            cadastro.CadastrarFornecedor(fornecedor);

            var fornecedorEncontrado = cadastro.BuscarFornecedor("Victoria Ltda");
            fornecedor.ToExpectedObject().ShouldMatch(fornecedorEncontrado);
        }

        [Fact]
        public void TesteCamposObrigatorios()
        {
            Assert.Throws<ArgumentException>(() => new Fornecedor("", "Rua Y", "9876-5432"));
            Assert.Throws<ArgumentException>(() => new Fornecedor("Victoria Ltda", "", "9876-5432"));
            Assert.Throws<ArgumentException>(() => new Fornecedor("Victoria Ltda", "Rua Y", ""));
        }
    }
}
