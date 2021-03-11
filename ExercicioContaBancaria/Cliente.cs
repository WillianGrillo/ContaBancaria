using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria1
{
    public class Cliente
    {
        public Cliente(string cpf, string nome)
        {
            Cpf = cpf;
            Nome = nome;

        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public Conta Conta{ get; set; }

    }
    



}

