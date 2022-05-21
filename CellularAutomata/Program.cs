namespace CellularAutomata
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using (var game = new CellularAutomataGame())
                game.Run();
        }

    }
}