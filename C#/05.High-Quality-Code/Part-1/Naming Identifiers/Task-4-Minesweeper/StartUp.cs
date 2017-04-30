namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const int MaxTurnsAllowed = 35;

        public static void Main()
        {
            string command = string.Empty;

            char[,] gameField = Execute.CreateGameField();
            char[,] minesField = Execute.CreateMinesField();

            List<Player> champions = new List<Player>(6);

            int turnsCounter = 0;
            int row = 0;
            int column = 0;

            bool activateMine = false;
            bool startGame = true;
            bool winner = false;

            do
            {
                if (startGame)
                {
                    Console.WriteLine("Wellcome to Mineweeper!");
                    Console.WriteLine("You task is to jump over cells without activate mine!");
                    Console.WriteLine("Lets get started!");
                    Execute.LoadField(gameField);
                    startGame = false;
                }

                Console.Write("Please enter coordinates of target position: ");

                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    bool parsedRow = int.TryParse(command[0].ToString(), out row);
                    bool parsedColumn = int.TryParse(command[2].ToString(), out column);
                    bool validRow = row <= gameField.GetLength(0);
                    bool validColumn = column <= gameField.GetLength(1);

                    if (parsedRow && parsedColumn && validRow && validColumn)
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Execute.Ranking(champions);
                        break;

                    case "restart":
                        gameField = Execute.CreateGameField();
                        minesField = Execute.CreateMinesField();
                        Execute.LoadField(gameField);
                        activateMine = false;
                        startGame = false;
                        break;

                    case "exit":
                        Console.WriteLine("Thank you for playing!\nHave a nice day!");
                        break;

                    case "turn":
                        if (minesField[row, column] != '*')
                        {
                            if (minesField[row, column] == '-')
                            {
                                Execute.NextPlayerTurn(gameField, minesField, row, column);
                                turnsCounter++;
                            }

                            if (MaxTurnsAllowed == turnsCounter)
                            {
                                winner = true;
                            }
                            else
                            {
                                Execute.LoadField(gameField);
                            }
                        }
                        else
                        {
                            activateMine = true;
                        }

                        break;

                    default:
                        Console.WriteLine("\nError: Invalid Command!\n");
                        break;
                }

                if (activateMine)
                {
                    Execute.LoadField(minesField);

                    Console.Write("\nHrrrrrr! You died like a hero with {0} points." + "Please enter your Nickname: ", turnsCounter);

                    string nickname = Console.ReadLine();

                    Player deadPlayer = new Player(nickname, turnsCounter);

                    if (champions.Count < 5)
                    {
                        champions.Add(deadPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < deadPlayer.Points)
                            {
                                champions.Insert(i, deadPlayer);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Player playerOne, Player playerTwo) => playerTwo.Name.CompareTo(playerOne.Name));
                    champions.Sort((Player playerOne, Player playerTwo) => playerTwo.Points.CompareTo(playerOne.Points));
                    Execute.Ranking(champions);

                    gameField = Execute.CreateGameField();
                    minesField = Execute.CreateMinesField();
                    turnsCounter = 0;
                    activateMine = false;
                    startGame = true;
                }

                if (winner)
                {
                    Console.WriteLine("\nBRAVOOO! You opened 35 cages without getting hurt.");

                    Execute.LoadField(minesField);

                    Console.WriteLine("Enter your name, champion: ");

                    string playerName = Console.ReadLine();

                    Player winnerPlayer = new Player(playerName, turnsCounter);

                    champions.Add(winnerPlayer);
                    Execute.Ranking(champions);

                    gameField = Execute.CreateGameField();
                    minesField = Execute.CreateMinesField();
                    turnsCounter = 0;
                    winner = false;
                    startGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("All rights reserved!");
            Console.Read();
        }
    }
}
