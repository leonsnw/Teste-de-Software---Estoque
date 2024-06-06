using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CadastroProdutos
    {
        private List<Produto> produtos;

        public CadastroProdutos()
        {
            produtos = new List<Produto>();
        }

        public void CadastrarProduto(Produto produto)
        {
            if (produtos.Any(p => p.CodigoBarras == produto.CodigoBarras))
            {
                throw new InvalidOperationException("Um produto com este código de barras já foi registrado.");
            }

            produtos.Add(produto);
        }

        public Produto BuscarProduto(string criterio)
        {
            return produtos.FirstOrDefault(p =>
                p.Descricao.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                p.CodigoBarras.Contains(criterio, StringComparison.OrdinalIgnoreCase)
            );
        }

        public void AtualizarProduto(string codigoBarras, decimal novoPrecoVenda)
        {
            var produto = produtos.FirstOrDefault(p => p.CodigoBarras == codigoBarras);
            if (produto == null)
            {
                throw new InvalidOperationException("Produto não encontrado.");
            }

            produto.AtualizarPrecoVenda(novoPrecoVenda);
        }

        public Produto VisualizarDetalhes(string codigoBarras)
        {
            var produto = produtos.FirstOrDefault(p => p.CodigoBarras == codigoBarras);
            if (produto == null)
            {
                throw new InvalidOperationException("Produto não encontrado.");
            }

            return produto;
        }
    }
    
}
