using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Fornecedor
    {
        public int Id { get; private set; }
        public string NomeEmpresa { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string TermosPagamento { get; private set; }

        public Fornecedor(string nomeEmpresa, string endereco, string telefone, string email = "", string termosPagamento = "")
        {
            if (string.IsNullOrWhiteSpace(nomeEmpresa))
                throw new ArgumentException("É necessário fornecer o nome da empresa do fornecedor.");

            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("É necessário fornecer o endereço do fornecedor.");

            if (string.IsNullOrWhiteSpace(telefone))
                throw new ArgumentException("É necessário fornecer o telefone do fornecedor.");

            NomeEmpresa = nomeEmpresa;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            TermosPagamento = termosPagamento;
        }

        public void AtualizarInformacoes(string endereco, string telefone, string email, string termosPagamento)
        {
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            TermosPagamento = termosPagamento;
        }
    }
}
