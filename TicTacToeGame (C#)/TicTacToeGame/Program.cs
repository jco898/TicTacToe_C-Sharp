using System;

namespace TicTacToeGame
{
    class Program : ViewInterface
    {
        private static char[] positions = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        private static char symbol;
        private static Presenter presenter;

        static void Main(string[] args)
        {
            presenter = new Presenter(new Program());

            while (true)
            {
                presenter.NewGame();

                while (presenter.ValidGame())
                {
                    Console.Clear();
                    Draw();

                    int player = presenter.GetPlayer();

                    Console.ForegroundColor = ConsoleColor.White;

                    try
                    {
                        Console.WriteLine($"Player {player}, it is your turn to play");
                        Console.WriteLine("Enter row number: ");
                        var row = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter col number: ");
                        var col = Int32.Parse(Console.ReadLine());
                        
                        presenter.ProcessChoice(player, row, col);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the TicTacToe board with positions.
        /// </summary>
        private static void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", positions[0], positions[1], positions[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", positions[3], positions[4], positions[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", positions[6], positions[7], positions[8]);
            Console.WriteLine("     |     |      ");
            Console.WriteLine();
        }

        /// <summary>
        /// Resets all current symbols.
        /// </summary>
        public void Reset()
        {
            positions[0] = ' ';
            positions[1] = ' ';
            positions[2] = ' ';
            positions[3] = ' ';
            positions[4] = ' ';
            positions[5] = ' ';
            positions[6] = ' ';
            positions[7] = ' ';
            positions[8] = ' ';
        }

        /// <summary>
        /// Sets the symbol (X / O) of the player in its position.
        /// </summary>
        /// <param name="player">The current player</param>
        /// <param name="row">The row number</param>
        /// <param name="col">The column number</param>
        public void SetPosition(int player, int row, int col)
        {
            if (player == 1)
            {
                symbol = 'X';
            }
            else if (player == 2)
            {
                symbol = 'O';
            }

            switch (row, col)
            {
                case (0, 0):
                    positions[0] = symbol;
                    break;
                case (0, 1):
                    positions[1] = symbol;
                    break;
                case (0, 2):
                    positions[2] = symbol;
                    break;
                case (1, 0):
                    positions[3] = symbol;
                    break;
                case (1, 1):
                    positions[4] = symbol;
                    break;
                case (1, 2):
                    positions[5] = symbol;
                    break;
                case (2, 0):
                    positions[6] = symbol;
                    break;
                case (2, 1):
                    positions[7] = symbol;
                    break;
                case (2, 2):
                    positions[8] = symbol;
                    break;
            }
        }

        /// <summary>
        /// Displays an error message to the console.
        /// </summary>
        /// <param name="error"></param>
        public void ShowError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays a message indicating a win.
        /// </summary>
        /// <param name="result"></param>
        public void ShowWin(string result)
        {
            Console.Clear();
            Draw();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays a message indicating a draw.
        /// </summary>
        /// <param name="result"></param>
        public void ShowDraw(string result)
        {
            Console.Clear();
            Draw();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}