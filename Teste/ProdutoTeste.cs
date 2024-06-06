
using Dominio;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class ProdutoTeste
    {
        [Fact]
        public void TesteCadastroNovoProduto()
        {
            var cadastro = new CadastroProdutos();
            var produto = new Produto("Blusa", "9876543210987", 20.00m, 40.00m);

            cadastro.CadastrarProduto(produto);

            var produtoCadastrado = cadastro.VisualizarDetalhes("9876543210987");
            var expectedProduto = new
            {
                Descricao = "Blusa",
                CodigoBarras = "9876543210987",
                PrecoCompra = 20.00m,
                PrecoVenda = 40.00m,
                QuantidadeEstoque = 0,
                Fornecedor = (string)null
            };

            Assert.Equal(expectedProduto.Descricao, produtoCadastrado.Descricao);
            Assert.Equal(expectedProduto.CodigoBarras, produtoCadastrado.CodigoBarras);
            Assert.Equal(expectedProduto.PrecoCompra, produtoCadastrado.PrecoCompra);
            Assert.Equal(expectedProduto.PrecoVenda, produtoCadastrado.PrecoVenda);
            Assert.Equal(expectedProduto.QuantidadeEstoque, produtoCadastrado.QuantidadeEstoque);
            Assert.Equal(expectedProduto.Fornecedor, produtoCadastrado.Fornecedor);
        }

        [Fact]
        public void TesteCadastroProdutoDuplicado()
        {
            var cadastro = new CadastroProdutos();
            var produto1 = new Produto("Blusa", "9876543210987", 20.00m, 40.00m);
            var produto2 = new Produto("Calça", "9876543210987", 30.00m, 60.00m);

            cadastro.CadastrarProduto(produto1);
            Assert.Throws<InvalidOperationException>(() => cadastro.CadastrarProduto(produto2));
        }

        [Fact]
        public void TesteAtualizacaoPrecoVenda()
        {
            var cadastro = new CadastroProdutos();
            var produto = new Produto("Blusa", "9876543210987", 20.00m, 40.00m);

            cadastro.CadastrarProduto(produto);
            cadastro.AtualizarProduto("9876543210987", 50.00m);

            var produtoAtualizado = cadastro.VisualizarDetalhes("9876543210987");

            var expectedProduto = new
            {
                Descricao = "Blusa",
                CodigoBarras = "9876543210987",
                PrecoCompra = 20.00m,
                PrecoVenda = 50.00m,
                QuantidadeEstoque = 0,
                Fornecedor = (string)null
            };

            Assert.Equal(expectedProduto.Descricao, produtoAtualizado.Descricao);
            Assert.Equal(expectedProduto.CodigoBarras, produtoAtualizado.CodigoBarras);
            Assert.Equal(expectedProduto.PrecoCompra, produtoAtualizado.PrecoCompra);
            Assert.Equal(expectedProduto.PrecoVenda, produtoAtualizado.PrecoVenda);
            Assert.Equal(expectedProduto.QuantidadeEstoque, produtoAtualizado.QuantidadeEstoque);
            Assert.Equal(expectedProduto.Fornecedor, produtoAtualizado.Fornecedor);

        }

        [Fact]
        public void TesteBuscaProduto()
        {
            var cadastro = new CadastroProdutos();
            var produto = new Produto("Blusa", "9876543210987", 20.00m, 40.00m);

            cadastro.CadastrarProduto(produto);

            var produtoEncontrado = cadastro.BuscarProduto("Blusa");
            var expectedProduto = new
            {
                Descricao = "Blusa",
                CodigoBarras = "9876543210987",
                PrecoCompra = 20.00m,
                PrecoVenda = 40.00m,
                QuantidadeEstoque = 0,
                Fornecedor = (string)null
            };

            Assert.Equal(expectedProduto.Descricao, produtoEncontrado.Descricao);
            Assert.Equal(expectedProduto.CodigoBarras, produtoEncontrado.CodigoBarras);
            Assert.Equal(expectedProduto.PrecoCompra, produtoEncontrado.PrecoCompra);
            Assert.Equal(expectedProduto.PrecoVenda, produtoEncontrado.PrecoVenda);
            Assert.Equal(expectedProduto.QuantidadeEstoque, produtoEncontrado.QuantidadeEstoque);
            Assert.Equal(expectedProduto.Fornecedor, produtoEncontrado.Fornecedor);
        }

        [Fact]
        public void TesteCamposObrigatorios()
        {
            Assert.Throws<ArgumentException>(() => new Produto("", "9876543210987", 20.00m, 40.00m));
            Assert.Throws<ArgumentException>(() => new Produto("Blusa", "", 20.00m, 40.00m));
            Assert.Throws<ArgumentException>(() => new Produto("Blusa", "9876543210987", 20.00m, 0));
        }
    }

}