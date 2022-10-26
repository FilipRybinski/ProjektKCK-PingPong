using System;

namespace ProjektKCK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game gierka = new Game();
            gierka.Run();
            Console.ReadKey();
        }
    }
}
