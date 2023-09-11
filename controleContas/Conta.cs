using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace controleContas
{
    //Classe Conta herdando os atributos da classe Cliente
    public class Conta : Cliente
    {        
        public int Numero { get; private set; }
        public decimal Saldo { get; private set; }
        //Construtor da classe ja com os atributos herdados da outra classe para ser utilizados.
        public Conta(string nome, string cpf, int data, int numero, decimal saldo) : base(nome, cpf, data)
        {   
            Nome = nome;
            Cpf = cpf;
            AnoNascimento = data;
            Numero = numero;
            Saldo = saldo;
        }
        public decimal Extrato()
        {
            return Saldo;
        }
        public void Deposito(decimal valor) 
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"Depositado com sucesso\n" +
                    $"Saldo após o Depósito:{Saldo,2:C}\n");
            }
            else
            {
                Console.WriteLine("Operação Inválida");
            }
        }
        public void Sacar(decimal valor) 
        {  
            if (valor + 0.10m <= Saldo) 
            {  
                Saldo -= (valor + 0.10m);
                Console.WriteLine($"Saque realizado com sucesso\n" +
                    $"Saldo após o Saque:{Saldo,2:C}\n");
            } 
            else
            {
                Console.WriteLine("Saldo Insuficiente\n");
            }
        }
        public string Transferir(decimal valor)
        {
            if (valor == 0)
            {
                return "\nO valor de transferência tem que ser maior que 0\n";
            }
            else if (valor < Saldo)
            {
                Saldo -= valor;
                return $"\nTransferência realizada com sucesso\n\n" +
                    $"Saldo de sua conta após a Transferência:{Saldo,2:C}\n";   
            }
            else 
            { 
                return "\nSaldo Insuficiente\n"; 
            }
        }
        public void Transferencia(decimal valor)
        {
            Saldo += valor;
            Console.WriteLine($"Saldo do destinatário {Numero} após a Transferência:{Saldo,2:C}\n");
        }
    }
}
