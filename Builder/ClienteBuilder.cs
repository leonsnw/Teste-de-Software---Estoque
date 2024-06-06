using System;

namespace Builder
{
    public class ClienteBuilder
    {
        private string _nome;
        private string _endereco;
        private string _numeroTelefone;
        private string _email;

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

        public ClienteBuilder ComNumeroTelefone(string numeroTelefone)
        {
            _numeroTelefone = numeroTelefone;
            return this;
        }

        public ClienteBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public Cliente Build()
        {
            return new Cliente(_nome, _endereco, _numeroTelefone, _email);
        }
    }
}

