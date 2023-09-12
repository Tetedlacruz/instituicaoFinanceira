# instituicaoFinanceira
Programação em C#

Olá! Seja bem vindo ao READ ME do projeto controleContas desenvolvido por Diego Fialho, Bruce Henrique e Matheus Alves. Logo abaixo seguem as instruções de como utilizá-lo da melhor forma possível.

O objetivo da aplicação é que você consiga realizar a criação de contas bancárias, depositar e sacar valores, verificar o saldo, além de realizar transferências financeiras, inclusive entre diferentes agências bancárias. Para utilizar as operações financeiras é necessário que o usuário possua uma conta ou, caso não tenha, crie uma conta cumprindo os requisitos abaixo:
-	Possuir mais de 18 anos de idade;
-	Possuir um CPF válido;

Vale ressaltar que caso o usuário informe o CPF com os caracteres(“.” e “-“) o programa fará automaticamente a remoção deles para validar e armazenar no banco de dados. O valor mínimo inicial de depósito para criar uma conta é de R$10,00 (dez reais) e a cada saque realizado pelo usuário.

Como funciona o código:

-	Classes e Métodos

Para desenvolver o programa, foram criadas duas classes (Cliente e Conta). Na classe Cliente definimos um método construtor e atribuímos os parâmetros (nome, cpf e data de nascimento). Já na classe Conta, definimos um método construtor assim como na anterior e herdamos a classe Cliente para que todos os atributos estivessem conectados e assim só poder criar uma conta caso atenda aos requisitos para ser cliente.

Além do método construtor Conta, foi criado também o método Depósito que adiciona valores na conta bancária caso seja um valor maior que zero, o método Saque que retira o valor desejado da conta + R$0,10 de taxa de saque, o método Transferir que envia o valor de uma conta para outra desde que o valor não seja maior que o saldo e por fim o método Transferência que acrescenta esse valor enviado na conta destinatária.

-	Programa Executável

Visando realizar a ponte entre as agências bancárias disponíveis e os clientes, foi criado um dicionário de bancos com seus números de registro e nome e na sequência, ambos foram atribuídos a uma lista com a agência daquele banco, na qual se encontra o número da agência, CEP e telefone de contato, além disso também mostra o saldo atual da conta. Para vincular as agências as contas, foram criados dois dicionários, um para registrar as agências bancárias e outro para vincular as contas a suas respectivas agências. Como exemplo, temos duas contas criadas no código, onde todos os atributos (nome, CPF, data de nascimento, número da conta e valor da conta) estão registrados.

A parte “visual” do programa se inicia com um pequeno menu no qual o usuário irá definir que tipo de ação irá tomar. Dentre as opções você pode acessar sua conta, criar uma nova conta e exibir o saldo. 

Para os usuários que já são clientes, será necessário entrar com sua conta para prosseguir. Um novo menu se lançará com as opções assim que feito o login, e também aparecerá na tela as informações referentes ao banco e agência daquela conta. No menu, temos as operações de saque, depósito e transferência para uma outra conta bancária, além da opção de retornar ao menu anterior. 
