using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CadastroFornecedores
    {
        private List<Fornecedor> fornecedores;

        public CadastroFornecedores()
        {
            fornecedores = new List<Fornecedor>();
        }

        public void CadastrarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedores.Any(f => f.NomeEmpresa == fornecedor.NomeEmpresa && f.Telefone == fornecedor.Telefone))
            {
                throw new InvalidOperationException("Há um fornecedor com mesmo numero de telefone e nome.");
            }

            fornecedores.Add(fornecedor);
        }

        public void AtualizarFornecedor(int id, string endereco, string telefone, string email, string termosPagamento)
        {
            var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
            if (fornecedor == null)
            {
                throw new InvalidOperationException("Fornecedor não encontrado.");
            }

            fornecedor.AtualizarInformacoes(endereco, telefone, email, termosPagamento);
        }

        public Fornecedor BuscarFornecedor(string criterio)
        {
            return fornecedores.FirstOrDefault(f =>
                f.NomeEmpresa.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                (f.Email != null && f.Email.Contains(criterio, StringComparison.OrdinalIgnoreCase)) ||
                f.Telefone.Contains(criterio));
        }

        public Fornecedor VisualizarDetalhes(int id)
        {
            var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
            if (fornecedor == null)
            {
                throw new InvalidOperationException("Fornecedor não encontrado.");
            }

            return fornecedor;
        }
    }
}
