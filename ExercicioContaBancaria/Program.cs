using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria1
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            int opcaoEscolhida;

            do
            {
                Console.WriteLine("Selecione uma opção!");
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Consultar");
                Console.WriteLine("4 - Transferir");
                Console.WriteLine("5 - Cadastrar cliente");
                Console.WriteLine("0 - Sair");

                opcaoEscolhida = Convert.ToInt32(Console.ReadLine());
                switch (opcaoEscolhida)
                {
                    case 1:
                        Depositar();
                        break;
                    case 2:
                        Sacar();
                        break;
                    case 3:
                        Consultar();
                        break;
                    case 4:
                        Transferir();
                        break;
                    case 5:
                        CadastrarCliente();
                        break;
                    default:
                        break;

                }
            } while (opcaoEscolhida != 0);
        }

        public static void CadastrarCliente()
        {
            Console.WriteLine("Digite o nome do Cliente");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite o CPF do Cliente");
            var cpf = Console.ReadLine();
            if (CpfJaExistenteOuInvalido(cpf))
                return;

            var ultimaConta = 0;
            if (clientes.Count > 0)
            {
                ultimaConta = clientes.Max(x => x.Conta.Numero);
            }


            var cliente = new Cliente(cpf, nome);
            cliente.Conta = new Conta(ultimaConta + 1, cliente);
            clientes.Add(cliente);
            Console.WriteLine($"Cliente Cadastrado: {cliente.Nome}/ Conta: {cliente.Conta.Numero}");
        }

        public static void Depositar()
        {
            Console.WriteLine("Digite numero da conta");
            var numeroConta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a quantidade");
            var quantidadeDepositar = Convert.ToDouble(Console.ReadLine());

            var cliente = clientes.First(x => x.Conta.Numero == numeroConta);
            cliente.Conta.Depositar(quantidadeDepositar);

        }

        public static void Sacar()
        {
            Console.WriteLine("Digite numero da conta");
            var numeroConta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a quantidade");
            var quantidadeSacar = Convert.ToDouble(Console.ReadLine());

            var cliente = clientes.First(x => x.Conta.Numero == numeroConta);
            cliente.Conta.Sacar(quantidadeSacar);

        }

        public static void Consultar()
        {
            Console.WriteLine("Digite numero da conta");
            var numeroConta = Convert.ToInt32(Console.ReadLine());
            var cliente = clientes.First(x => x.Conta.Numero == numeroConta);
            Console.WriteLine(cliente.Conta.Saldo);
        }

        public static void Transferir()
        {
            Console.WriteLine("Digite numero da sua conta");
            var numeroContaTransferidora = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite numero da conta para transferir");
            var numeroContaRecebedora = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Valor a transferir");
            var valorATransferir = Convert.ToDouble(Console.ReadLine());

            var contaTransferidora = clientes.First(x => x.Conta.Numero == numeroContaTransferidora).Conta;
            var contaRecebedora = clientes.First(x => x.Conta.Numero == numeroContaRecebedora).Conta;

            Console.WriteLine("Transferência concluída!");

            contaTransferidora.Sacar(valorATransferir);
            Console.WriteLine($"Saldo conta transferidora: {contaTransferidora.Saldo}");

            contaRecebedora.Depositar(valorATransferir);
            Console.WriteLine($"Saldo conta recebedora: {contaRecebedora.Saldo}");
        }

        private static bool CpfJaExistenteOuInvalido(string cpf)
        {
            List<string> erros = new List<string>();
            if (!(cpf.Length == 11))
            {
                Console.WriteLine("CPF inválido");
                erros.Add("CPF inválido");
            }

            if (clientes.Where(x => x.Cpf.Equals(cpf)).ToList().Count > 0)
            {
                Console.WriteLine("CPF já cadastrado");
                erros.Add("CPF inválido");
            }

            return erros.Count > 0;
        }
    }
}
