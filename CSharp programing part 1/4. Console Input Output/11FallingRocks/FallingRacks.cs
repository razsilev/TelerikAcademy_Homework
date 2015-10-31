using System;
using System.Threading;
using System.Collections.Generic;

namespace FallingRocks
{

    class Element
    {
        public int coordX;
        public int coordY;
        public char symbol;
        public ConsoleColor color;

        public Element(int coordX, int coordY, char symbol, ConsoleColor color)
        {
            this.coordX = coordX;
            this.coordY = coordY;
            this.symbol = symbol;
            this.color = color;
        }

        public void Print()
        {
            Console.SetCursorPosition(coordX, coordY);
            Console.ForegroundColor = color;
            Console.Write(symbol);
        }

        public void Delete()
        {
            Console.SetCursorPosition(coordX, coordY);
            Console.ForegroundColor = color;
            Console.Write(' ');
        }
    }

    class FallingRocks
    {

        static void PrintStringOnPosition(int coordX, int coordY, 
            string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(coordX, coordY);
            Console.ForegroundColor = color;
            Console.Write(str);
        }

        static void Main()
        {
            int playfieldWidth = 27;
            int livesCount = 3;
            int score = 0;
            int speed = 0;
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 50;
            Element dwarf = new Element(13, Console.WindowHeight - 1, 'O', ConsoleColor.White);
            Random randomGenerator = new Random();
            Queue<Element> rocks = new Queue<Element>();
            char[] symbols = new char[] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };

            DrawPlayfield(playfieldWidth);
            DrawDwarf(dwarf);

            while (true)
            {
                CreatingRocks(playfieldWidth, symbols, randomGenerator, rocks);

                MoveRocks(playfieldWidth, ref livesCount, ref score, ref speed, dwarf, rocks);

                // Draw "Game over"
                if (livesCount <= 0)
                {
                    Console.Clear();
                    PrintStringOnPosition(17, 8, "GAME OVER !!!", ConsoleColor.Red);
                    PrintStringOnPosition(12, 16, "Your score is : " + score, ConsoleColor.Green);
                    PrintStringOnPosition(14, 24, "Press [Enter] to exit", ConsoleColor.Red);
                    Console.ReadLine();
                    return;
                }

                // Draw info
                PrintStringOnPosition(35, 8, "Lives: " + livesCount, ConsoleColor.White);
                PrintStringOnPosition(35, 16, "Speed: " + speed / 20, ConsoleColor.White);
                PrintStringOnPosition(33, 24, "Score: " + score, ConsoleColor.White);

                // Slow down program
                if (speed < 100)
                {
                    speed++;
                }
                Thread.Sleep(250 - speed);
             }
        }

        private static void MoveRocks(int playfieldWidth, ref int livesCount,
            ref int score, ref int speed, Element dwarf, Queue<Element> rocks)
        {
            if (IsMoveRocksHitDwarf(rocks, dwarf))
            {
                livesCount--;
                speed = 0;

                DrawDwarf(new Element(dwarf.coordX, dwarf.coordY, 'X', ConsoleColor.Red));
                PrintStringOnPosition(32, 3, "Press [Enter]", ConsoleColor.Green);
                PrintStringOnPosition(33, 5, "to continue", ConsoleColor.Green);

                Console.ReadLine();
                DeleteRocks(rocks);
                DeletePrintedString(32, 3, "Press [Enter]");
                DeletePrintedString(33, 5, "to continue");
            }
            else
            {
                score++;

                DeleteDwarf(dwarf);

                MoveDwarf(playfieldWidth, dwarf);

                DrawDwarf(dwarf);
            }
        }

        private static void DeletePrintedString(int x, int y, string str)
        {
            Console.SetCursorPosition(x, y);

            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(' ');
            }
        }

        private static void DeleteRocks(Queue<Element> rocks)
        {
            foreach (var rock in rocks)
            {
                rock.Delete();
            }

            rocks.Clear();
        }

        private static void DeleteDwarf(Element dwarf)
        {
            dwarf.coordX--;
            dwarf.Delete();
            dwarf.coordX += 2;
            dwarf.Delete();

            // return old state
            dwarf.coordX--;
        }

        private static void MoveDwarf(int playfieldWidth, Element dwarf)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.coordX - 1 >= 1)
                    {
                        dwarf.coordX--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.coordX + 1 < playfieldWidth - 1)
                    {
                        dwarf.coordX++;
                    }
                }
            }
        }

        private static void DrawDwarf(Element dwarf)
        {
            if (dwarf.symbol == 'O')
            {
                dwarf.Print();
                dwarf.symbol = '(';
                dwarf.coordX--;
                dwarf.Print();
                dwarf.symbol = ')';
                dwarf.coordX += 2;
                dwarf.Print();

                // return old state
                dwarf.symbol = 'O';
                dwarf.coordX--;
            }
            else
            {
                dwarf.Print();
                dwarf.coordX--;
                dwarf.Print();
                dwarf.coordX += 2;
                dwarf.Print();
            }
        }

        private static bool IsMoveRocksHitDwarf(Queue<Element> rocks, Element dwarf)
        {
            int countRocks = rocks.Count;

            for (int i = 0; i < countRocks; i++)
            {
                Element oldRock = rocks.Dequeue();

                oldRock.Delete();

                // Check if rocks are hitting dwarf
                if (((oldRock.coordY == dwarf.coordY) && (oldRock.coordX == (dwarf.coordX - 1))) ||
                    ((oldRock.coordY == dwarf.coordY) && (oldRock.coordX == dwarf.coordX)) ||
                    ((oldRock.coordY == dwarf.coordY) && (oldRock.coordX == (dwarf.coordX + 1))))
                {
                    return true;
                }

                if ((oldRock.coordY + 1) < Console.WindowHeight)
                {
                    oldRock.coordY++;
                    oldRock.Print();
                    rocks.Enqueue(oldRock);
                }
            }

            return false;
        }

        private static void CreatingRocks(int playfieldWidth, char[] symbols,
            Random randomGenerator, Queue<Element> rocks)
        {
            int rocksOnRow = randomGenerator.Next(3);
            for (int i = 0; i < rocksOnRow; i++)
            {
                int coordX = randomGenerator.Next(playfieldWidth);
                int numberOfSymbol = randomGenerator.Next(symbols.Length);
                int randomNumber = randomGenerator.Next(100);
                char symbol = symbols[numberOfSymbol];
                int rockLength = 0;
                ConsoleColor color = (ConsoleColor)randomGenerator.Next(9, 15);
                Element newRock = new Element(coordX, 0, symbol, color);

                if (randomNumber < 70)
                {
                    rockLength = 1;
                }
                else if (randomNumber < 95)
                {
                    rockLength = 2;
                }
                else
                {
                    rockLength = 3;
                }

                for (int rocksNumber = 0; rocksNumber < rockLength; rocksNumber++)
                {
                    if (newRock.coordX < playfieldWidth)
                    {
                        rocks.Enqueue(newRock);
                    }
                    Element old = new Element(newRock.coordX + 1, newRock.coordY,
                        newRock.symbol, newRock.color);
                    newRock = old;
                }
            }
        }

        private static void DrawPlayfield(int playfieldWidth)
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                new Element(playfieldWidth, i, '|', ConsoleColor.White).Print();
            }
        }

    }
}