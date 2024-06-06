using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TransacaoEstoque
    {
        public enum TipoTransacao
        {
            Entrada,
            Saida
        }

        public int Id { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public string FornecedorCliente { get; private set; }
        public string NumeroFatura { get; private set; }
        public string Motivo { get; private set; }

        public TransacaoEstoque(TipoTransacao tipo, int produtoId, int quantidade, decimal valor, DateTime data, string fornecedorCliente, string numeroFatura, string motivo)
        {
            if (quantidade <= 0 || valor <= 0)
            {
                throw new ArgumentException("Tanto a quantidade quanto o valor devem ser superiores a zero.");
            }

            Id = new Random().Next();
            Tipo = tipo;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            Valor = valor;
            Data = data;
            FornecedorCliente = fornecedorCliente;
            NumeroFatura = numeroFatura;
            Motivo = motivo;
        }
    }

}
