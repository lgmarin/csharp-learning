// Stopwatch

Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("Super StopWatch");
    Console.WriteLine("S - Contagem em Segundos");
    Console.WriteLine("M - Contagem em minutos");
    Console.WriteLine("0 - Sair do aplicativo");
    Console.WriteLine("--------------------------");
    Console.WriteLine("Insira a opção: ");

    string data = Console.ReadLine().ToLower();

    char type = char.Parse(data.Substring(data.Length - 1, 1));
    int time = int.Parse(data.Substring(0, data.Length - 1));
    int multiplier = 1;

    if (type == 'm')
        multiplier = 60;
    
    if (time == 0)
        System.Environment.Exit(0);

    Start(time * multiplier);
}

static void Start(int time)
{
    
    int currentTime = 0;

    while (currentTime != time)
    {
        currentTime++;
        Console.Clear();
        Console.WriteLine($"Tempo: {currentTime}");
        Thread.Sleep(1000);
    }
    Console.Clear();
    Console.WriteLine("Stopwatch finalizado!");
    Thread.Sleep(2000);
    Menu();
}