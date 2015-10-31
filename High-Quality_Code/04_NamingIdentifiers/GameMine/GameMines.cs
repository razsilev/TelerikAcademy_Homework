namespace GameMine
{
    using System;
    using System.Collections.Generic;

    public class GameMines
    {
        public static void Main(string[] аргументи)
        {
            const int MAX_POINTS = 35;

            string command = string.Empty;
            char[,] gameBoard = CreateGameBoard();
            char[,] mines = PasteMines();
            List<Player> players = new List<Player>(6);
            int points = 0;
            int row = 0;
            int column = 0;
            bool hasMineExplosion = false;
            bool isGameOver = true;
            bool isWin = false;

            // game loop
            do
            {
                if (isGameOver)
                {
                    Console.WriteLine("Let's play the game “Mini4KI”. Try your luck, to find a mine-free fields." +
                    " Command 'top' show rank, 'restart' start new game, 'exit' exit from game and BYE!");
                    PrintGameField(gameBoard);
                    isGameOver = false;
                }

                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= gameBoard.GetLength(0) &&
                        column <= gameBoard.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRanking(players);
                        break;
                    case "restart":
                        gameBoard = CreateGameBoard();
                        mines = PasteMines();
                        PrintGameField(gameBoard);
                        hasMineExplosion = false;
                        isGameOver = false;
                        break;
                    case "exit":
                        Console.WriteLine("bye, bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                WriteOnPositionMinesCountAroundIt(gameBoard, mines, row, column);
                                points++;
                            }

                            if (MAX_POINTS == points)
                            {
                                isWin = true;
                            }
                            else
                            {
                                PrintGameField(gameBoard);
                            }
                        }
                        else
                        {
                            hasMineExplosion = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! invalid Command\n");
                        break;
                }

                if (hasMineExplosion)
                {
                    PrintGameField(mines);

                    Console.Write("\nHrrrrrr! Died heroically whit {0} points. Enter your name: ", points);
                    string currentPlayerName = Console.ReadLine();

                    Player currentPlayer = new Player(currentPlayerName, points);
                    if (players.Count < 5)
                    {
                        players.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < currentPlayer.Points)
                            {
                                players.Insert(i, currentPlayer);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player first, Player second) => second.Name.CompareTo(first.Name));
                    players.Sort((Player first, Player second) => second.Points.CompareTo(first.Points));

                    PrintRanking(players);

                    gameBoard = CreateGameBoard();
                    mines = PasteMines();
                    points = 0;
                    hasMineExplosion = false;
                    isGameOver = true;
                }

                if (isWin)
                {
                    Console.WriteLine("\nCONGRATULATIONS! Open 35 cells without drop of blood.");
                    PrintGameField(mines);
                    Console.WriteLine("Enter ypur name, brother: ");
                    string winnerName = Console.ReadLine();

                    Player winner = new Player(winnerName, points);
                    players.Add(winner);

                    PrintRanking(players);

                    gameBoard = CreateGameBoard();
                    mines = PasteMines();
                    points = 0;
                    isWin = false;
                    isGameOver = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintRanking(List<Player> players)
        {
            Console.WriteLine("\nPlayers rank:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("empty rank!\n");
            }
        }

        private static void WriteOnPositionMinesCountAroundIt(char[,] gameBoard, char[,] mines, int row, int column)
        {
            char minesCount = NumberOfMinesAraundPosition(mines, row, column);
            mines[row, column] = minesCount;
            gameBoard[row, column] = minesCount;
        }

        private static void PrintGameField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] PasteMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameBoard = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    gameBoard[row, col] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            Random random = new Random();
            while (randomNumbers.Count < 15)
            {
                int currentNumber = random.Next(50);
                if (!randomNumbers.Contains(currentNumber))
                {
                    randomNumbers.Add(currentNumber);
                }
            }

            foreach (int number in randomNumbers)
            {
                int col = number / cols;
                int row = number % cols;

                if (row == 0 && number != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameBoard[col, row - 1] = '*';
            }

            return gameBoard;
        }

        private static char NumberOfMinesAraundPosition(char[,] gameBoard, int currentRow, int currentCol)
        {
            int minesCount = 0;
            int rols = gameBoard.GetLength(0);
            int cols = gameBoard.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (gameBoard[currentRow - 1, currentCol] == '*')
                {
                    minesCount++;
                }
            }

            if (currentRow + 1 < rols)
            {
                if (gameBoard[currentRow + 1, currentCol] == '*')
                {
                    minesCount++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (gameBoard[currentRow, currentCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (currentCol + 1 < cols)
            {
                if (gameBoard[currentRow, currentCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (gameBoard[currentRow - 1, currentCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
            {
                if (gameBoard[currentRow - 1, currentCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow + 1 < rols) && (currentCol - 1 >= 0))
            {
                if (gameBoard[currentRow + 1, currentCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow + 1 < rols) && (currentCol + 1 < cols))
            {
                if (gameBoard[currentRow + 1, currentCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}
