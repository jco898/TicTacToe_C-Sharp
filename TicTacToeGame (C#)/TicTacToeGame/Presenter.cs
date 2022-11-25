using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe;

namespace TicTacToeGame
{
    class Presenter
    {
        private readonly ViewInterface view;
        private readonly TicTacToeModel model;

        public Presenter(ViewInterface v)
        {
            model = new TicTacToeModel();
            view = v;
            NewGame();
        }

        /// <summary>
        /// Prepares a new game to be started.
        /// </summary>
        public void NewGame()
        {
            model.NewBoard();
            view.Reset();
        }

        /// <summary>
        /// Gets the next player's number.
        /// </summary>
        /// <returns>An int indicating the player.</returns>
        public int GetPlayer()
        {
            return model.NextPlayer;
        }

        /// <summary>
        /// Processes the player's choice and displays an updated board.
        /// </summary>
        /// <param name="player">The player who made the choice</param>
        /// <param name="row">The row number</param>
        /// <param name="col">The column number</param>
        public void ProcessChoice(int player, int row, int col)
        {
            model.MakePlay(player, row, col);
            if (model.GameError != TicTacToeModel.ErrorCodes.NoError)
            {
                string error = "There was an error: " + 
                    Enum.GetName(typeof(TicTacToeModel.ErrorCodes), model.GameError);
                view.ShowError(error);
            }
            else
            {
                view.SetPosition(player, row, col);
            }

            if (model.status == TicTacToeModel.PlayStatus.won)
            {
                string result = $"Player {model.NextPlayer} won the game";
                view.ShowWin(result);
            }

            if (model.status == TicTacToeModel.PlayStatus.draw)
            {
                string result = "The game ended in a draw";
                view.ShowDraw(result);
            }
        }

        /// <summary>
        /// Checks whether the game is still continuable.
        /// </summary>
        /// <returns>True if the game hasn't been won or drawn. Otherwise, returns false.</returns>
        public bool ValidGame()
        {
            return model.status != TicTacToeModel.PlayStatus.won 
                && model.status != TicTacToeModel.PlayStatus.draw;
        }
    }
}
