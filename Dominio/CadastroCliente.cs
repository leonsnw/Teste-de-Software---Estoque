using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class CadastroClientes
    {
        private List<Cliente> clientes;

        public CadastroClientes()
        {
            clientes = new List<Cliente>();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            if (clientes.Any(c => c.Nome == cliente.Nome && c.Telefone == cliente.Telefone))
            {
                throw new InvalidOperationException("Há um cliente cadastrado com o mesmo número de telefone.");
            }

            clientes.Add(cliente);
        }

        public void AtualizarCliente(int id, string endereco, string telefone)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                throw new InvalidOperationException("Cliente não encontrado.");
            }

            cliente.AtualizarInformacoes(endereco, telefone, cliente.Email);
        }

        public Cliente BuscarCliente(string criterio)
        {
            return clientes.FirstOrDefault(c =>
                c.Nome.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                (c.Email != null && c.Email.Contains(criterio, StringComparison.OrdinalIgnoreCase)) ||
                c.Telefone.Contains(criterio));
        }

        public Cliente VisualizarDetalhes(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                throw new InvalidOperationException("Cliente não encontrado.");
            }

            return cliente;
        }
    }
}

