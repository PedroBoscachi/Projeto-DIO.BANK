using System;
using System.Collections.Generic;

namespace API.BANK
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void  Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){

                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "S":                      
                        string opcaoSobre = Sobre();
                        Console.Clear();
                        Informacoes(opcaoSobre);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!!!");
            Console.ReadLine();
        }

        private static void Transferir(){
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
       
        private static void Sacar(){
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar(){
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static void ListarContas(){
            Console.WriteLine("Listar contas");

            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string Sobre(){
            Console.WriteLine("Qual informação deseja saber?\n");
            Console.WriteLine("1- Data de criação");
            Console.WriteLine("2- Local de criação");
            Console.WriteLine("3- Principais Fundadores");
            Console.WriteLine("4- Objetivo da Ultimate Bank");
            Console.WriteLine("S- Sair");
            Console.WriteLine();

            string opcaoSobre = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.Clear();
            return opcaoSobre;
              
        }

        private static void Informacoes(string escolha){
            while(escolha != "S"){
                switch(escolha){

                    case "1":
                        Console.WriteLine("A empresa foi criada em 29 de Dezembro de 1998.");
                        break;
                    case "2":
                        Console.WriteLine("A empresa foi criada em São Paulo, Brasil.");
                        break;
                    case "3":
                        Console.WriteLine("A empresa foi fundada por Bruce Kent e Clark Wayne.");
                        break;
                    case "4":
                        Console.WriteLine("Nosso principal objetivo é alcançar a satisfação total do cliente.");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Aperte qualquer tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
                escolha = Sobre();
            }
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("---ULTIMATE BANK---");
            Console.WriteLine("Insira a opção escolhida:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("S- Sobre o Banco");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }    
    }
}
