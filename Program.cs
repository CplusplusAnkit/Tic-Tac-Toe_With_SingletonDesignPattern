using System;

namespace MyApp
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static Player player1;
        static Player player2;
        static void Main(string[] args)
        {
            // Initialize the game board
            InitializeBoard();

            // Setup players
            SetupPlayers();

            // Start the game
            StartGame(); 

            Console.ReadLine(); // Wait for user to exit
        }
        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void SetupPlayers()
        {
            // Ask for player 1's name and marker
            Console.WriteLine("Enter Player 1's name:");
            string name1 = Console.ReadLine();
            Console.WriteLine("Do you want to be the first player (X) or second player (O)? (Enter 1 for first, 2 for second):");
            int choice1 = int.Parse(Console.ReadLine());
            char marker1 = choice1 == 1 ? 'X' : 'O';

            // Set player 1
            player1 = Player1.Instance(name1, marker1);
            player1.PrintPlayerInfo();

            // Ask for player 2's name and marker
            Console.WriteLine("Enter Player 2's name:");
            string name2 = Console.ReadLine();
            char marker2 = player1.Marker == 'X' ? 'O' : 'X';

            // Set player 2
            player2 = Player2.Instance(name2, marker2);
            player2.PrintPlayerInfo();
        }

        static void StartGame()
        {
            Player currentPlayer = player1;
            int moves = 0;
            bool isWinner = false;

            while (moves < 9 && !isWinner)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"{currentPlayer.Name}'s turn ({currentPlayer.Marker}). Enter row and column (0, 1, 2):");

                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                Tuple<int, int> currentMove = new Tuple<int, int>(row, col);
                currentPlayer.AllMoves.Add(currentMove);

                // Validate input and check for available position
                if (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ')
                {
                    Console.WriteLine("------- Invalid move. Try again. --------");
                    continue;
                }

                // Place the marker on the board
                board[row, col] = currentPlayer.Marker;
                moves++;

                // Check for a win
                isWinner = CheckWin(currentPlayer.Marker);
                if (isWinner)
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine($"{currentPlayer.Name} wins!");
                    Console.WriteLine("----------- All Move of wining player is ---------");
                    int countMove = 0;
                    foreach(var move in currentPlayer.AllMoves)
                    {
                        Console.WriteLine(++countMove +" Move is "+ move.Item1 +", "+move.Item2);
                    }
                    
                }
                else
                {
                    // Switch players
                    currentPlayer = currentPlayer == player1 ? player2 : player1;
                }
            }

            if (!isWinner)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("It's a draw!");
            }
        }

        static void DisplayBoard()
        {
            Console.WriteLine("Current Board:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2]);
                if (i < 2)
                {
                    Console.WriteLine("---|---|---");
                }
            }
        }

        static bool CheckWin(char marker)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == marker && board[i, 1] == marker && board[i, 2] == marker)
                {
                    return true;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == marker && board[1, i] == marker && board[2, i] == marker)
                {
                    return true;
                }
            }

            // Check main diagonal
            if (board[0, 0] == marker && board[1, 1] == marker && board[2, 2] == marker)
            {
                return true;
            }

            // Check anti-diagonal
            if (board[0, 2] == marker && board[1, 1] == marker && board[2, 0] == marker)
            {
                return true;
            }

            // No winning condition found
            return false;
        }

    }
}