using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Dominio
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }

        public Cliente(string nome, string endereco, string telefone, string email = "")
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("É necessário fornecer o nome do cliente.");

            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("É necessário fornecer o endereço do cliente.");

            if (string.IsNullOrWhiteSpace(telefone))
                throw new ArgumentException("É necessário fornecer o telefone do cliente.");

            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }

        public void AtualizarInformacoes(string endereco, string telefone, string email)
        {
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }
    }
}
