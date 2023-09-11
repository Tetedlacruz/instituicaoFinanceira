using controleContas;
using System.Diagnostics.CodeAnalysis;

var banco = new Dictionary<int, string>
{   {260, "Nubank"},
    {341, "Itau"} };

var agencia0001 = new List<string>() {"0001", "27281-000", "40028922", $"{banco.ElementAt(0).Value}"};
var agencia0375 = new List<string>() {"0375", "27245-000", "33445566", $"{banco.ElementAt(1).Value}"};

var agencias = new Dictionary<int, List<string>>() { };
var contas = new Dictionary<int, Conta> { };

Conta conta1 = new("Diego", "182.561.117-39", 2000, 123456, 1235.42m);
Conta conta2 = new("Diogo", "160.546.617-44", 1994, 654321, 2341.42m);

contas.Add(conta1.Numero, conta1);
contas.Add(conta2.Numero, conta2);

agencias.Add(conta1.Numero, agencia0375);
agencias.Add(conta2.Numero, agencia0375);

int numeroConta = 100000;

Console.WriteLine($"Bem vindo a Aplicação Bancária");
var opcao = 0;
while (opcao != -1) //Menu Principal
{
    Console.WriteLine("\nEscolha uma das opções a seguir:\n" +
        " 1 - Sou Cliente\n" +
        " 2 - Nova Conta\n" +
        " 3 - Mostrar o valor das contas\n" +
        "-1 - Sair");

    opcao = Convert.ToInt32(Console.ReadLine());
    if (opcao == 1)
    {
        Console.WriteLine($"Informe o numero da sua conta para continuar\n");
        int conta = Convert.ToInt32(Console.ReadLine());
        if (contas.ContainsKey(conta))
        {
            Console.WriteLine($"Banco {agencias[conta][3]}, Agência {agencias[conta][0]}, Conta {conta}\n" +
                $"CEP da Agência: {agencias[conta][1]}\n" +
                $"Telefone da Agência: {agencias[conta][2]}\n");
            Console.WriteLine($"Bem vindo {contas[conta].Nome}\n");
            
            int operacao = 0;
            while (operacao != -1) //Menu do cliente
            {
                Console.WriteLine("Escolha a operação desejada:\n" +
                    " 1 - Saque\n" +
                    " 2 - Depósito\n" +
                    " 3 - Transferência\n" +
                    "-1 - Retornar ao menu anterior\n");
                operacao = Convert.ToInt32(Console.ReadLine());
                if (operacao == 1) //Saque
                { 
                    Console.WriteLine("Informe o valor a ser sacado.\n" +
                        "Lembrando que é cobrado o valor de R$0,10 por cada saque.");
                    decimal valor = Convert.ToDecimal(Console.ReadLine());
                    contas[conta].Sacar(valor);
                }
                else if (operacao == 2) //Depósito
                {                   
                    Console.WriteLine("Informne o valor a ser depositado.");
                    decimal valor = Convert.ToDecimal(Console.ReadLine());
                    contas[conta].Deposito(valor);
                }
                else if (operacao == 3) //Transferência
                {
                    Console.WriteLine("Informe o valor a ser transferido");
                    decimal valor = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Qual será a conta de destino?");
                    int contaDestino;
                    while (true)
                    {
                        contaDestino = Convert.ToInt32(Console.ReadLine()); //Conta que irá a transferência
                        if (!contas.ContainsKey(contaDestino))
                        {
                            Console.WriteLine("Essa conta não existe, tente novamente com uma conta existente.");
                        }
                        else if (contaDestino == conta)
                        {
                            Console.WriteLine("Não é possível transferir para sua própria conta. Informe uma outra conta.");
                        }
                        else 
                        {
                            break; 
                        }
                    }
                    Console.WriteLine($"Verifique se as informações de transação estão corretas.\n" + 
                        $"\nTransferindo para conta: {contaDestino}.\n" +
                        $"Titular da conta: {contas[contaDestino].Nome}\n" + 
                        $"Valor: R${valor}\n" + 
                        $"Data e Hora:{DateTime.Now}\n" +
                        $"\nPara confirmar Digite 'S' ou digite 'N' para cancelar");
                    string? confirmacao = Console.ReadLine();
                    if (confirmacao.ToUpper() == "S")
                    {
                        string _ = contas[conta].Transferir(valor); //Transferência iniciada
                        Console.WriteLine(_);
                        if (_ != "\nSaldo Insuficiente\n")
                        {
                            if (_ != "\nO valor de transferência tem que ser maior que 0\n")
                            {
                                contas[contaDestino].Transferencia(valor); //Recebendo na conta destino
                            }   
                        }
                    }
                    else
                    {
                        Console.WriteLine("Transferência Cancelada\n" +
                            "Retornando ao menu anterior.\n");
                    }
                }
                else if (operacao == -1)
                {
                    Console.WriteLine("\nRetornando.\n");
                }
                else
                {
                    Console.WriteLine("\nOperação Inválida\n");
                }
            }
        }
        else
        {
            Console.WriteLine("Não encontrado, verifique o numero e tente novamente\n");
        }
    }
    else if (opcao == 2)
    {
        Console.WriteLine("Para abrir uma nova conta é necessário algumas informações.\n" +
            "Informe seu nome:");
        string? nome;
        while (true)
        {
            nome = Console.ReadLine();
            if (nome == "")
            {
                Console.WriteLine("O nome não pode estar vazio");
            }
            else
            {
                break;
            }
        }   

        string? cpf;
        Console.WriteLine("Informe seu CPF:");
        while (true) //Verificar CPF
        {
            cpf = Console.ReadLine();
            cpf = cpf?.Replace(".", null);
            cpf = cpf?.Replace("-", null);
            if (cpf?.Length != 11)
            {
                Console.WriteLine("CPF Inválido");
            }
            else 
            { 
                break; 
            }
        }

        int data;
        Console.WriteLine("Informe seu ano de nascimento:");
        while (true) //Verificar Idade
        { 
            data = Convert.ToInt32(Console.ReadLine());
            if ((DateTime.Now.Year - data) >= 18)
            {
                break;
            }
            else
            {
                Console.WriteLine("Não possui 18 anos de idade ou mais");
            }
        }
        Console.WriteLine("Informações verificadas.\n" +
            "Agora para prosseguir com a criação da conta é necessário fazer um depósito de, no mínimo, R$10,00 para continuar.\n" +
            "Informe o valor a ser depositado:");

        decimal valor; 
        while (true) //Verificar valor mínimo para criar conta
        {
            valor = Convert.ToDecimal(Console.ReadLine());
            if (valor < 10.00m)
            {
                Console.WriteLine("Saldo inicial inferior ao mínimo (R$10,00)");
            }
            else
            {
                break;
            }
        }

        Conta novaConta = new(nome, cpf, data, numeroConta, valor);
        contas.Add(novaConta.Numero, novaConta);
        agencias.Add(novaConta.Numero, agencia0001);
        Console.WriteLine("Conta criada com sucesso!");
        numeroConta++;
    }
    else if (opcao == 3)
    {
        int contaMaiorSaldo = 0;
        decimal maiorSaldo = 0;
        decimal totalContas = 0;
        for (int i= 0; i < contas.Count; i++)
        {
            totalContas += contas.ElementAt(i).Value.Saldo;
            Console.WriteLine($"Conta {contas.ElementAt(i).Key}. Valor: R${contas.ElementAt(i).Value.Saldo}");
            if (maiorSaldo < contas.ElementAt(i).Value.Saldo)
            {
                maiorSaldo = contas.ElementAt(i).Value.Saldo;
                contaMaiorSaldo = contas.ElementAt(i).Key;
            }
            
        }
        Console.WriteLine($"\nA Conta com maior saldo é {contaMaiorSaldo} com o valor de {maiorSaldo}\n");
        Console.WriteLine($"O Total das Contas é de {totalContas}");
    }      
    else if (opcao == -1)
    {
        Console.WriteLine("\nEncerrando a aplicação.\n");
    }
    else
    {
        Console.WriteLine("Opção Invalida");
    }
}