using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Program
    {
        public BancoDados Banco { get; private set; }
        public Program() 
        {
            Banco = new BancoDados();
            fazerTela();
        }

        public void fazerTela ()
        {
            Console.WriteLine("Hello!");
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
