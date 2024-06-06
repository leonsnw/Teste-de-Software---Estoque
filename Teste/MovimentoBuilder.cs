using Dominio;
using System;

namespace Teste
{
    public class MovimentoBuilder
    {
        private int _id;
        private int _produtoId;
        private TipoMovimento _tipo;
        private int _quantidade;
        private decimal _valorUnitario;
        private DateTime _dataMovimento;
        private string _cliente = string.Empty; // Inicializando com string vazia
        private string _descricao = string.Empty; // Inicializando com string vazia

        public MovimentoBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public MovimentoBuilder ComProdutoId(int produtoId)
        {
            _produtoId = produtoId;
            return this;
        }

        public MovimentoBuilder ComTipo(TipoMovimento tipo)
        {
            _tipo = tipo;
            return this;
        }

        public MovimentoBuilder ComQuantidade(int quantidade)
        {
            _quantidade = quantidade;
            return this;
        }

        public MovimentoBuilder ComValorUnitario(decimal valorUnitario)
        {
            _valorUnitario = valorUnitario;
            return this;
        }

        public MovimentoBuilder ComDataMovimento(DateTime dataMovimento)
        {
            _dataMovimento = dataMovimento;
            return this;
        }

        public MovimentoBuilder ComCliente(string cliente)
        {
            _cliente = cliente;
            return this;
        }

        public MovimentoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public Movimento Build()
        {
            return new Movimento(_id, _produtoId, _tipo, _quantidade, _valorUnitario, _dataMovimento, _cliente, _descricao);
        }
    }
}
