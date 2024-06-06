using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CadastroTransacoesEstoque
    {
        private List<TransacaoEstoque> transacoes;

        public CadastroTransacoesEstoque()
        {
            transacoes = new List<TransacaoEstoque>();
        }

        public void RegistrarEntrada(int produtoId, int quantidade, decimal valor, DateTime data, string fornecedor, string numeroFatura, string motivo)
        {
            var transacao = new TransacaoEstoque(TransacaoEstoque.TipoTransacao.Entrada, produtoId, quantidade, valor, data, fornecedor, numeroFatura, motivo);
            transacoes.Add(transacao);
        }

        public void RegistrarSaida(int produtoId, int quantidade, decimal valor, DateTime data, string cliente, string motivo)
        {
            var quantidadeDisponivel = transacoes
                .Where(t => t.ProdutoId == produtoId)
                .Sum(t => t.Tipo == TransacaoEstoque.TipoTransacao.Entrada ? t.Quantidade : -t.Quantidade);

            if (quantidade > quantidadeDisponivel)
            {
                throw new InvalidOperationException("Há uma quantidade insuficiente deste item em estoque.");
            }

            var transacao = new TransacaoEstoque(TransacaoEstoque.TipoTransacao.Saida, produtoId, quantidade, valor, data, cliente, null, motivo);
            transacoes.Add(transacao);
        }

        public List<TransacaoEstoque> VisualizarHistorico()
        {
            return transacoes;
        }

        public List<TransacaoEstoque> GerarRelatorio(DateTime? inicio = null, DateTime? fim = null, int? produtoId = null, string fornecedorCliente = null)
        {
            var query = transacoes.AsQueryable();

             if (inicio.HasValue)
            {
                query = query.Where(t => t.Data >= inicio.Value);
            }

            if (fim.HasValue)
            {
                query = query.Where(t => t.Data <= fim.Value);
            }

             if (produtoId.HasValue)
            {
                query = query.Where(t => t.ProdutoId == produtoId.Value);
            }

              if (!string.IsNullOrEmpty(fornecedorCliente))
            {
                query = query.Where(t => t.FornecedorCliente.Contains(fornecedorCliente, StringComparison.OrdinalIgnoreCase));
            }

             return query.ToList();
        }
    }

}
