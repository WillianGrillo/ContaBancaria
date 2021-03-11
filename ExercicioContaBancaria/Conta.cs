using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria1
{
    public class Conta
    {
        public Conta(int numero, Cliente cliente)
        {   
            Numero = numero;
            Saldo = 0.0;
            Cliente = cliente;
        }

        #region Propriedade
        
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public Cliente Cliente { get; set; }
       
        #endregion
        public void Depositar(double dinheiro)
        {
            this.Saldo += dinheiro;

        }
        public void Sacar(double dinherio)
        {
            if(Saldo >= dinherio)
            {
                this.Saldo -= dinherio;

                Console.WriteLine("Valor Sacado com Sucesso");

            }
            else
            {
                Console.WriteLine("Saldo Insuficiente");
            }
        
        }
        public void Consultar() 
        {
            Console.WriteLine("Saldo: " + Saldo);
        }
              
    
    
    
    }

    
}
