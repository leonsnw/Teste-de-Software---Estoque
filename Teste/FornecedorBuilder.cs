using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class FornecedorBuilder
    {
        private string _nomeEmpresa;
        private string _endereco;
        private string _numeroTelefone;
        private string _email;
        private string _termosPagamento;

        public FornecedorBuilder ComNomeEmpresa(string nomeEmpresa)
        {
            _nomeEmpresa = nomeEmpresa;
            return this;
        }

        public FornecedorBuilder ComEndereco(string endereco)
        {
            _endereco = endereco;
            return this;
        }

        public FornecedorBuilder ComNumeroTelefone(string numeroTelefone)
        {
            _numeroTelefone = numeroTelefone;
            return this;
        }

        public FornecedorBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public FornecedorBuilder ComTermosPagamento(string termosPagamento)
        {
            _termosPagamento = termosPagamento;
            return this;
        }

        public Fornecedor Build()
        {
            return new Fornecedor(_nomeEmpresa, _endereco, _numeroTelefone, _email, _termosPagamento);
        }
    }
}

