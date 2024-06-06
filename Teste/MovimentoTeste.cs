using Dominio;
using ExpectedObjects;
using Xunit;
using System;
using System.Linq;

namespace Teste
{
    public class MovimentoTeste
    {
        [Fact]
        public void TesteCadastroNovaEntrada()
        {
            var cadastro = new CadastroMovimentos();
            var entrada = new Movimento(1, 123, TipoMovimento.Entrada, 10, 15.5m, DateTime.Now, null, "Chegada de produtos");

            cadastro.RegistrarMovimento(entrada);

            var movimentoCadastrado = cadastro.ObterMovimentos().FirstOrDefault();
            entrada.ToExpectedObject().ShouldMatch(movimentoCadastrado);
        }

        [Fact]
        public void TesteCadastroNovaSaida()
        {
            var cadastro = new CadastroMovimentos();
            var saida = new Movimento(2, 456, TipoMovimento.Saida, 5, 25.75m, DateTime.Now, "Cliente A", "Venda de produto");

            cadastro.RegistrarMovimento(saida);

            var movimentoCadastrado = cadastro.ObterMovimentos().FirstOrDefault();
            saida.ToExpectedObject().ShouldMatch(movimentoCadastrado);
        }

        [Fact]
        public void TesteVisualizarMovimento()
        {
            var cadastro = new CadastroMovimentos();
            var entrada = new Movimento(3, 789, TipoMovimento.Entrada, 20, 10.0m, DateTime.Now, null, "Chegada de produtos");

            cadastro.RegistrarMovimento(entrada);

            var movimentoEncontrado = cadastro.VisualizarMovimento(3);
            entrada.ToExpectedObject().ShouldMatch(movimentoEncontrado);
        }

        [Fact]
        public void TesteCamposObrigatoriosEntrada()
        {
            Assert.Throws<ArgumentException>(() => new Movimento(4, 0, TipoMovimento.Entrada, 10, 15.5m, DateTime.Now, null, "Chegada de produtos"));
            Assert.Throws<ArgumentException>(() => new Movimento(5, 123, TipoMovimento.Entrada, 0, 15.5m, DateTime.Now, null, "Chegada de produtos"));
            Assert.Throws<ArgumentException>(() => new Movimento(6, 123, TipoMovimento.Entrada, 10, 0m, DateTime.Now, null, "Chegada de produtos"));
        }

        [Fact]
        public void TesteCamposObrigatoriosSaida()
        {
            Assert.Throws<ArgumentException>(() => new Movimento(7, 0, TipoMovimento.Saida, 5, 25.75m, DateTime.Now, "Cliente A", "Venda de produto"));
            Assert.Throws<ArgumentException>(() => new Movimento(8, 456, TipoMovimento.Saida, 0, 25.75m, DateTime.Now, "Cliente A", "Venda de produto"));
            Assert.Throws<ArgumentException>(() => new Movimento(9, 456, TipoMovimento.Saida, 5, 0m, DateTime.Now, "Cliente A", "Venda de produto"));
            Assert.Throws<ArgumentException>(() => new Movimento(10, 456, TipoMovimento.Saida, 5, 25.75m, DateTime.Now, null, "Venda de produto"));
        }
    }
}
