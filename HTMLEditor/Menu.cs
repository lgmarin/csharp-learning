namespace HTMLEditor
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen(100, 20);
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        public static void DrawLine(char init_char, char middle_char, int cols = 100)
        {
            Console.Write(init_char);
            for (int row = 0; row <= cols; row++)
            {
                Console.Write(middle_char);
            }
            Console.Write(init_char);
            Console.Write("\n");
        }

        public static void DrawScreen(int cols, int lines)
        {
            DrawLine('+', '-', cols);
            for (int line = 0; line <= lines; line++)
                DrawLine('|', ' ', cols);
            DrawLine('+', '-', cols);       
        }
    
        public static void WriteOptions()
        {
            Console.SetCursorPosition(3,2);
            Console.WriteLine("HTML Editor");
            Console.SetCursorPosition(3,3);
            Console.WriteLine("------------------------------");
            Console.SetCursorPosition(3,4);
            Console.WriteLine("Select one of the options:");
            Console.SetCursorPosition(3,6);
            Console.WriteLine("1 - New File");
            Console.SetCursorPosition(3,7);
            Console.WriteLine("2 - Open File");                                              
            Console.SetCursorPosition(3,9);
            Console.WriteLine("0 - EXIT");
            Console.SetCursorPosition(3,10);            
            Console.WriteLine("------------------------------");
            Console.SetCursorPosition(3,11);
            Console.Write("Enter your option: ");                      
        }
    
        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1: Console.WriteLine("Editor"); break;
                case 2: Console.WriteLine("View"); break;
                case 0: {
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                };
                default: Show(); break;
            }
        }
    } 
}

