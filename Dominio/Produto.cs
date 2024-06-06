using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Produto
    {
        public string Descricao { get; private set; }
        public string CodigoBarras { get; private set; }
        public decimal PrecoCompra { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public string Fornecedor { get; private set; }

        public Produto(string descricao, string codigoBarras, decimal precoCompra, decimal precoVenda)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição do produto é necessária.");

            if (string.IsNullOrWhiteSpace(codigoBarras))
                throw new ArgumentException("O código de barras do produto é necessário.");

            if (precoVenda <= 0)
                throw new ArgumentException("O preço de venda precisa ser superior a zero.");

            Descricao = descricao;
            CodigoBarras = codigoBarras;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
            QuantidadeEstoque = 0;
        }

        public void AtualizarPrecoVenda(decimal novoPrecoVenda)
        {
            if (novoPrecoVenda <= 0)
                throw new ArgumentException("O novo preço de venda deve ser superior a zero.");

            PrecoVenda = novoPrecoVenda;
        }
    }
}

