using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace ProjektKCK
{
    class Game
    {
        public string NameOfGame= @"
                                    ______ _            ______                 
                                    | ___ (_)           | ___ \                
                                    | |_/ /_ _ __   __ _| |_/ /__  _ __   __ _ 
                                    |  __/| | '_ \ / _` |  __/ _ \| '_ \ / _` |
                                    | |   | | | | | (_| | | | (_) | | | | (_| |
                                    \_|   |_|_| |_|\__, \_|  \___/|_| |_|\__, |
                                                __/ |                 __/ |
                                                    |___/                 |___/ 
";
        private int speed=100;
        public void Run()
        {
            RunMainMenu();
        }
        private void RunMainMenu()
        {
            string[] menu = { "Start Game", "Settings","About", "Exit" };
            Menu mainMenu = new Menu(NameOfGame, menu);
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunGame();
                    break;
                case 1:
                    SettingsInfo();
                    break;
                case 2:
                    DisplayAboutInfo();
                    break;
                case 3:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }
        private void ExitGame()
        {
            WriteLine("\n Press any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
        private void SettingsInfo()
        {
            string[] lvls = { "Easy", "Medium", "Hard" };
            Menu menu_settings = new Menu(NameOfGame, lvls);
            int selectedIndex = menu_settings.Run();
            switch (selectedIndex)
            {
                case 0:
                    speed = 30;
                    break;
                case 1:
                    speed = 20;
                    break;
                case 2:
                    speed = 10;
                    break;

            }
            RunMainMenu();
        }
        private void DisplayAboutInfo()
        {
            SetCursorPosition((Console.WindowWidth / 4) + 15,  15);
            Write("Filip R. made this :))");
            ReadKey(true);
            RunMainMenu();
        }
        private void RunGame()
        {
            Pong pong = new Pong(Console.WindowWidth-3, Console.WindowHeight-3);
            pong.Run(speed);
        }

    }
}
