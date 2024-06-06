using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class ProdutoBuilder
    {
        private string _descricao;
        private string _codigoBarras;
        private decimal _precoCompra;
        private decimal _precoVenda;

        public ProdutoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public ProdutoBuilder ComCodigoBarras(string codigoBarras)
        {
            _codigoBarras = codigoBarras;
            return this;
        }

        public ProdutoBuilder ComPrecoCompra(decimal precoCompra)
        {
            _precoCompra = precoCompra;
            return this;
        }

        public ProdutoBuilder ComPrecoVenda(decimal precoVenda)
        {
            _precoVenda = precoVenda;
            return this;
        }

        public Produto Build()
        {
            return new Produto(_descricao, _codigoBarras, _precoCompra, _precoVenda);
        }
    }
}
