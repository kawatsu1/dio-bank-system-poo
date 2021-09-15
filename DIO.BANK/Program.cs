using System;
using System.Collections.Generic;

namespace DIO.BANK
{
  class Program
  {
    static List<Conta> listaContas = new List<Conta>();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListaContas();
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
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static void Transferir()
    {
      Console.WriteLine("Digite o número da conta de origem");
      int indiceContaOrigem = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o número da conta de destino");
      int indiceContaDestino = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o valor a ser transferido");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
    }

    private static void Depositar()
    {
      Console.WriteLine("Digite o númnero da conta");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o valor a ser depositado");
      double valorDeposito = double.Parse(Console.ReadLine());

      listaContas[indiceConta].Depositar(valorDeposito);

    }

    private static void Sacar()
    {
      Console.WriteLine("Digite o número da conta");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o valor a ser sacado");
      double valorDeposito = double.Parse(Console.ReadLine());

      listaContas[indiceConta].Sacar(valorDeposito);
    }

    private static void ListaContas()
    {
      Console.WriteLine("Listar contas");

      if (listaContas.Count == 0)
      {
        Console.WriteLine("Nenhuma conta cadastradas");
        return;
      }

      for (int i = 0; i < listaContas.Count; i++)
      {
        Conta conta = listaContas[i];
        Console.WriteLine("#{0} - ", i);
        Console.WriteLine(conta);
      }
    }

    private static void InserirConta()
    {
      Console.WriteLine("Inserir nova conta");
      Console.WriteLine("Digite 1 para Conta Fisica e 2 para Jurídica");
      int entradaTipoConta = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o nome do Cliente");
      string entradaNome = Console.ReadLine();

      Console.WriteLine("Digite o saldo inicial");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.WriteLine("Digite o credito inicial");
      double entradaCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(
          tipoConta: (TipoConta)entradaTipoConta,
          saldo: entradaSaldo,
          credito: entradaCredito,
          nome: entradaNome
          );

      listaContas.Add(novaConta);
      return;
    }

    public static string ObterOpcaoUsuario()
    {
      Console.WriteLine("BANK ---- ");
      Console.WriteLine("Informe a opção desejada");

      Console.WriteLine("1 - Lista contas");
      Console.WriteLine("2 - Inserir nova conta");
      Console.WriteLine("3 - Transferir");
      Console.WriteLine("4 - Sacar");
      Console.WriteLine("5 - Depositar");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcao = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcao;
    }
  }
}
