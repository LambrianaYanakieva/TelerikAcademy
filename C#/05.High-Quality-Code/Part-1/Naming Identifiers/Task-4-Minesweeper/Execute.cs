namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Execute
    {
        public static void Ranking(List<Player> champions)
        {
            Console.WriteLine("\nChampions Score:");

            if (champions.Count > 0)
            {
                for (int i = 0; i < champions.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, champions[i].Name, champions[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking list!");
            }
        }

       public static void NextPlayerTurn(char[,] gameField, char[,] mineField, int row, int column)
        {
            char mines = MinesCounter(mineField, row, column);

            mineField[row, column] = mines;
            gameField[row, column] = mines;
        }

       public static void LoadField(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

       public static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;

            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        public static char[,] CreateMinesField()
        {
            int rows = 5;
            int columns = 10;
            char[,] board = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> existingMines = new List<int>();

            while (existingMines.Count < 15)
            {
                Random generateRandomNumber = new Random();

                int randomNumber = generateRandomNumber.Next(50);

                if (!existingMines.Contains(randomNumber))
                {
                    existingMines.Add(randomNumber);
                }
            }

            foreach (int mine in existingMines)
            {
                int col = mine / columns;
                int row = mine % columns;

                if (row == 0 && mine != 0)
                {
                    col--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        public static void MinesLeft(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char mines = MinesCounter(board, i, j);
                        board[i, j] = mines;
                    }
                }
            }
        }

        public static char MinesCounter(char[,] board, int currentRow, int currentCol)
        {
            int minesCount = 0;

            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (board[currentRow - 1, currentCol] == '*')
                {
                    minesCount++;
                }
            }

            if (currentRow + 1 < boardRows)
            {
                if (board[currentRow + 1, currentCol] == '*')
                {
                    minesCount++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (board[currentRow, currentCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (currentCol + 1 < boardColumns)
            {
                if (board[currentRow, currentCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (board[currentRow - 1, currentCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < boardColumns))
            {
                if (board[currentRow - 1, currentCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow + 1 < boardRows) && (currentCol - 1 >= 0))
            {
                if (board[currentRow + 1, currentCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow + 1 < boardRows) && (currentCol + 1 < boardColumns))
            {
                if (board[currentRow + 1, currentCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}
