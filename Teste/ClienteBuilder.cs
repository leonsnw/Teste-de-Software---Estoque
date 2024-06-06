using Dominio;
using System;


namespace Teste
{
    public class ClienteBuilder
    {
        private int _id;
        private string _nome = string.Empty; // Inicializando com string vazia
        private string _endereco = string.Empty; // Inicializando com string vazia
        private string _telefone = string.Empty; // Inicializando com string vazia
        private string _email = string.Empty; // Inicializando com string vazia

        public ClienteBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public ClienteBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public ClienteBuilder ComEndereco(string endereco)
        {
            _endereco = endereco;
            return this;
        }

        public ClienteBuilder ComTelefone(string telefone)
        {
            _telefone = telefone;
            return this;
        }

        public ClienteBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public Cliente Build()
        {
            return new Cliente(_nome, _endereco, _telefone, _email);
        }
    }
}
