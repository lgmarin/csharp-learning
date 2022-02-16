// Console Calculator -- balta.io

Console.Clear();
Menu();

static void Soma(){
    Console.Clear();

    Console.WriteLine("Primeiro Valor: ");
    float valor_1 = float.Parse(Console.ReadLine());
    Console.WriteLine("Segundo Valor: ");
    float valor_2 = float.Parse(Console.ReadLine());

    float resultado = valor_1 + valor_2;
    Console.WriteLine("");
    Console.WriteLine($"O resultado da soma é {resultado}");

    Menu();
}

static void Subtracao(){
    Console.Clear();

    Console.WriteLine("Primeiro Valor: ");
    float valor_1 = float.Parse(Console.ReadLine());
    Console.WriteLine("Segundo Valor: ");
    float valor_2 = float.Parse(Console.ReadLine());

    float resultado = valor_1 - valor_2;
    Console.WriteLine("");
    Console.WriteLine($"O resultado da subtração é {resultado}");

    Menu();
}

static void Divisao(){
    Console.Clear();

    Console.WriteLine("Primeiro Valor: ");
    float valor_1 = float.Parse(Console.ReadLine());
    Console.WriteLine("Segundo Valor: ");
    float valor_2 = float.Parse(Console.ReadLine());

    float resultado = valor_1 / valor_2;
    Console.WriteLine("");
    Console.WriteLine($"O resultado da divisão é {resultado}");

    Menu();
}

static void Multiplicação(){
    Console.Clear();

    Console.WriteLine("Primeiro Valor: ");
    float valor_1 = float.Parse(Console.ReadLine());
    Console.WriteLine("Segundo Valor: ");
    float valor_2 = float.Parse(Console.ReadLine());

    float resultado = valor_1 * valor_2;
    Console.WriteLine("");
    Console.WriteLine($"O resultado da multiplicação é {resultado}");

    Menu();
}

static void Menu(){
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Soma");
    Console.WriteLine("2 - Subtração");
    Console.WriteLine("3 - Divisão");
    Console.WriteLine("4 - Multiplicação");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("------------------------------");
    Console.WriteLine("Digite sua opção:");

    short resposta = short.Parse(Console.ReadLine());

    switch(resposta){
        case 1: Soma(); break;
        case 2: Subtracao(); break;
        case 3: Divisao(); break;
        case 4: Multiplicação(); break;
        case 0: System.Environment.Exit(0); break;
        default: Menu(); break;
    }

}