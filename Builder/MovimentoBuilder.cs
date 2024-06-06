using System;

namespace Builder
{
    public class MovimentoBuilder
    {
        private int _produtoId;
        private int _quantidade;
        private decimal _valor;
        private DateTime _data;
        private string _clienteFornecedor;
        private string _numeroFatura;
        private string _motivo;

        public MovimentoBuilder ComProdutoId(int produtoId)
        {
            _produtoId = produtoId;
            return this;
        }

        public MovimentoBuilder ComQuantidade(int quantidade)
        {
            _quantidade = quantidade;
            return this;
        }

        public MovimentoBuilder ComValor(decimal valor)
        {
            _valor = valor;
            return this;
        }

        public MovimentoBuilder ComData(DateTime data)
        {
            _data = data;
            return this;
        }

        public MovimentoBuilder ComClienteFornecedor(string clienteFornecedor)
        {
            _clienteFornecedor = clienteFornecedor;
            return this;
        }

        public MovimentoBuilder ComNumeroFatura(string numeroFatura)
        {
            _numeroFatura = numeroFatura;
            return this;
        }

        public MovimentoBuilder ComMotivo(string motivo)
        {
            _motivo = motivo;
            return this;
        }

        public Movimento BuildEntrada()
        {
            return new Movimento(_produtoId, _quantidade, _valor, _data, _clienteFornecedor, _numeroFatura, _motivo, TipoMovimento.Entrada);
        }

        public Movimento BuildSaida()
        {
            return new Movimento(_produtoId, _quantidade, _valor, _data, _clienteFornecedor, _numeroFatura, _motivo, TipoMovimento.Saida);
        }
    }
}

