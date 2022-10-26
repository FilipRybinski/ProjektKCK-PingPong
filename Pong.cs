using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace ProjektKCK
{
    class Pong
    {
        int width;
        int height;
        Board board;
        Paddle paddle1;
        Paddle paddle2;
        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;
        ConsoleKey consoleKey2;
        Ball ball;

        public Pong(int width, int height)
        {
            this.width = width;
            this.height = height;
            board = new Board(width, height);
            ball = new Ball(width / 2, height / 2,height,width);
        }
        public void Setup()
        {
            paddle1 = new Paddle(2, height);
            paddle2 = new Paddle(width - 2, height);
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
            ball.X = width / 2;
            ball.Y = height / 2;
            ball.Destination = 0;
        }
        void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }
        public void Run(int speed)
        {

            while (true)
            {
                Console.Clear();
                Setup();
                board.Write();
                paddle1.Write();
                paddle2.Write();
                ball.Write();
                while (ball.X != 1 && ball.X != width - 1)
                {
                    Input();
                    switch (consoleKey)
                    {
                        case ConsoleKey.W:
                            paddle1.Up();
                            paddle2.Up();
                            break;
                        case ConsoleKey.S:
                            paddle1.Down();
                            paddle2.Down();
                            break;
                    }
                    consoleKey = ConsoleKey.A;
                    ball.Logic(paddle1, paddle2);
                    ball.Write();
                    Thread.Sleep(speed);
                }
                Console.SetCursorPosition(0, 6);
                Console.Write(@"
                     __      __   ______   __    __        __        ______    ______   ________                                                             
                    |  \    /  \ /      \ |  \  |  \      |  \      /      \  /      \ |        \
                     \$$\  /  $$|  $$$$$$\| $$  | $$      | $$     |  $$$$$$\|  $$$$$$\| $$$$$$$$
                      \$$\/  $$ | $$  | $$| $$  | $$      | $$     | $$  | $$| $$___\$$| $$__    
                       \$$  $$  | $$  | $$| $$  | $$      | $$     | $$  | $$ \$$    \ | $$  \   
                        \$$$$   | $$  | $$| $$  | $$      | $$     | $$  | $$ _\$$$$$$\| $$$$$   
                        | $$    | $$__/ $$| $$__/ $$      | $$_____| $$__/ $$|  \__| $$| $$_____ 
                        | $$     \$$    $$ \$$    $$      | $$     \\$$    $$ \$$    $$| $$     \
                         \$$      \$$$$$$   \$$$$$$        \$$$$$$$$ \$$$$$$   \$$$$$$  \$$$$$$$$
        
");
                Console.SetCursorPosition(30, 20);
                Console.Write("Press Enter to try one more time...., Press any to exit the game");
                Thread.Sleep(1000);
                if(Console.ReadKey().Key!= ConsoleKey.Enter)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
    class Ball
    {
        public int X{set;get;}
        public int Y { set; get; }
        int returnX;
        int returnY;
        int i;
        int boardHeight;
        int boardWidth;
        public int Destination { set; get; }
        public Ball(int x,int y,int boardHeight,int boardWidth)
        {
            X = x;
            Y = y;
            this.boardHeight = boardHeight;
            this.boardWidth = boardWidth;
            returnX = -1;
            returnY = -1;
        }
        public void Logic(Paddle paddle1,Paddle paddle2)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
            if(Y<=1 || Y >= boardHeight)
            {
                returnY *= -1;
            }
            if (((X == 3 || X == boardWidth - 3) && (paddle1.Y - (paddle1.Lenght / 2)) <= Y && (paddle1.Y + (paddle1.Lenght / 2)) > Y))
            {
                returnX *= -1;
                if (Y == paddle1.Y)
                {
                    Destination = 0;
                }
                if ((Y >= (paddle1.Y - (paddle1.Lenght / 2)) && Y < paddle1.Y) || (Y > paddle1.Y && Y < (paddle1.Y + (paddle1.Lenght / 2))))
                {
                    Destination = 1;
                }
            }
                    switch (Destination)
                    {
                        case 0:
                            X += returnX;
                            break;
                        case 1:
                            X += returnX;
                            Y += returnY;
                            break;
                    }
                
        }
        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(X, Y);
            Console.Write("▄");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    class Paddle
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int Lenght { set; get; }
        int boardHeight;
        public Paddle(int x,int boardHeight)
        {
            this.boardHeight = boardHeight;
            X = x;
            Y = boardHeight / 2;
            Lenght = boardHeight / 3;
        }
        public void Up()
        {
            if ((Y - 1 - (Lenght / 2)) != 0)
            {
                Console.SetCursorPosition(X, (Y + (Lenght / 2)) - 1);
                Console.Write(" ");
                Y--;
                Write();
            }
        }
        public void Down()
        {
            if ((Y + 1 + (Lenght / 2)) != boardHeight+2)
            {
                Console.SetCursorPosition(X, (Y - (Lenght / 2)));
                Console.Write(" ");
                Y++;
                Write();
            }

        }
        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for(int i = (Y - (Lenght / 2)); i < (Y + (Lenght / 2)); i++)
            {
                Console.SetCursorPosition(X, i);
                Console.Write("▐");
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
    public class Board
    {
        public int Height { set; get; }
        public int Width { set; get; }
        public Board()
        {
            Height = 20;
            Width = 60;
        }
        public Board(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public void Write()
        {
            for(int i = 1; i <= Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("─");
            }
            for(int i = 1; i <= Width; i++)
            {
                Console.SetCursorPosition(i, (Height+1));
                Console.Write("─");
            }
            for (int i = 1; i <=Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("│");
            }
            for (int i = 1; i <= Height; i++)
            {
                Console.SetCursorPosition((Width+1), i);
                Console.Write("│");
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("┌");
            Console.SetCursorPosition(Width+1, 0);
            Console.Write("┐");
            Console.SetCursorPosition(0, Height+1);
            Console.Write("└");
            Console.SetCursorPosition(Width+1, Height+1);
            Console.Write("┘");
        }
    }
}
