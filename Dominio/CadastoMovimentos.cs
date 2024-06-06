using System.Collections.Generic;
using System.Linq;
using System;

namespace Dominio
{
    public class CadastroMovimentos
    {
        private List<Movimento> movimentos = new List<Movimento>();

        public void RegistrarMovimento(Movimento movimento)
        {
            movimentos.Add(movimento);
        }

        public List<Movimento> ObterMovimentos()
        {
            return movimentos;
        }

        public Movimento VisualizarMovimento(int id)
        {
            return movimentos.FirstOrDefault(m => m.Id == id);
        }

        public int ObterQuantidadeEstoque(int produtoId)
        {
            int entradas = movimentos
                .Where(m => m.ProdutoId == produtoId && m.Tipo == TipoMovimento.Entrada)
                .Sum(m => m.Quantidade);

            int saidas = movimentos
                .Where(m => m.ProdutoId == produtoId && m.Tipo == TipoMovimento.Saida)
                .Sum(m => m.Quantidade);

            return entradas - saidas;
        }
    }
}
