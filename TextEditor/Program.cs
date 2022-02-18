static void Menu()
{
    Console.Clear();
    Console.WriteLine("Escolha a opção:");
    Console.WriteLine("1 - Abrir arquivo");
    Console.WriteLine("2 - Criar novo arquivo");
    Console.WriteLine("0 - Sair");

    short option = short.Parse(Console.ReadLine());

    switch(option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: Abrir(); break;
        case 2: Editar(); break;
        default: Menu(); break;
    }
}


static void Abrir()
{
    Console.Clear();
    Console.WriteLine("Ditite o caminho do seu arquivo: ");
    string path = Console.ReadLine();

    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }

    Console.WriteLine("_________________________________________________");
    Console.WriteLine($"Visualizando o arquivo: {path}");
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu!");
    Console.ReadLine();
    
    Menu();
}


static void Editar()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo. Para sair pressione ESC");
    Console.WriteLine("------------------------------");
    string text = "";

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;

    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(text);
}


static void Salvar(string text)
{
    Console.Clear();
    Console.WriteLine("Digite o caminho para salvar o arquivo: ");
    var path = Console.ReadLine();

    // abre e fechar automaticamente a stream
    using(var file  = new StreamWriter(path))
    {
        file.Write(text);
    }

    Console.WriteLine($"Arquivo salvo com sucesso em {path}");
    Console.ReadLine();
    
    Menu();
}


Menu();