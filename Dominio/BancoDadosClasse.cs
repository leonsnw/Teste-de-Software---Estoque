using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class BancoDados
    {
        public List<Cliente> Clientes { get; set; }
        public BancoDados()
        {
            Clientes = new List<Cliente>();
        }
        
        public Cliente buscarCliente(string variavel, string valor)
        {
            PropertyInfo property = typeof(Cliente).GetProperty(variavel, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
            {
                throw new ArgumentException($"Property '{variavel}' not found on type '{typeof(Cliente).Name}'");
            }

            return Clientes.FirstOrDefault(c => property.GetValue(c)?.ToString() == valor);
        }
    }
}
