using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoMovimento
    {
        Entrada,
        Saida
    }

    public class Movimento
    {
        public int Id { get; private set; }
        public int ProdutoId { get; private set; }
        public TipoMovimento Tipo { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public DateTime DataMovimento { get; private set; }
        public string Cliente { get; private set; }
        public string Descricao { get; private set; }

        public Movimento(int id, int produtoId, TipoMovimento tipo, int quantidade, decimal valorUnitario, DateTime dataMovimento, string cliente, string descricao)
        {
            if (produtoId <= 0) throw new ArgumentException("ProdutoId deve ser maior que zero.");
            if (quantidade <= 0) throw new ArgumentException("Quantidade deve ser maior que zero.");
            if (valorUnitario <= 0) throw new ArgumentException("ValorUnitario deve ser maior que zero.");
            if (tipo == TipoMovimento.Saida && string.IsNullOrEmpty(cliente)) throw new ArgumentException("Cliente deve ser fornecido para saídas.");


            Id = id;
            ProdutoId = produtoId;
            Tipo = tipo;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            DataMovimento = dataMovimento;
            Cliente = cliente;
            Descricao = descricao;
        }
    }
}

