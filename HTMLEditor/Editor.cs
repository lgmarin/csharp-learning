using System.Text;

namespace HTMLEditor
{
    public static class Editor
    {
        public static void Show()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("EDITOR MODE - Press ESCAPE to exit.");
            Console.WriteLine("---------------------------------------");

            Start();
        }

        public static void Start()
        {
            var text = new StringBuilder();

            do
            {
                text.Append(Console.ReadLine());
                text.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Do you want to save the file? [Y] or N?");
            Console.WriteLine("---------------------------------------");
            var option = Console.ReadLine().ToLower();

            switch (option)
            {
                case "y": Save(text); break;
                case "n": Menu.Show(); break;
                default: Console.WriteLine("Invalid option, try again!"); break;
            }
        }

        public static void Save(StringBuilder text)
        {
            Console.Clear();
            Console.WriteLine("Where do you want to save your file?");
            Console.WriteLine("---------------------------------------");
            var path = Console.ReadLine();

            using(var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"File successfully saved in {path}");
            Console.WriteLine("---------------------------------------");

            Menu.Show();
        }
    }
}