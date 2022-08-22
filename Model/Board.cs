using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demineur.Model
{
    internal class Board
    {
        public const int X_SIZE = 10;
        public const int Y_SIZE = 10;
        private Cell[,] tabCell = new Cell[X_SIZE, Y_SIZE];
        internal Cell[,] TabCell { get => tabCell; set => tabCell = value; }

        public Board()
        {
            FillBoard();
        }

        private void FillBoard()
        {
            for (int i = 0; i < X_SIZE; i++)
            {
                for (int y = 0; y < Y_SIZE; y++)
                {
                    this.TabCell[i, y] = new Cell(false);
                }
            }
        }
    }
}
