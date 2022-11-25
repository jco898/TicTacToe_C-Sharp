using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    interface ViewInterface
    {
        void Reset();

        void SetPosition(int player, int row, int col);

        void ShowError(string error);

        void ShowWin(string result);

        void ShowDraw(string result);
    }
}
