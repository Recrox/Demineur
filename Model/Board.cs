﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demineur.Model
{
    internal class Board
    {
        private static int x_SIZE = 10;
        private static int y_SIZE = 10;
        private Cell[,] tabCell = new Cell[X_SIZE, Y_SIZE];
        internal Cell[,] TabCell { get => tabCell; set => tabCell = value; }
        public static int X_SIZE { get => x_SIZE; set => x_SIZE = value; }
        public static int Y_SIZE { get => y_SIZE; set => y_SIZE = value; }

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
                    bool hasBomb = findRandomLuckForBomb();
                    this.TabCell[i, y] = new Cell(hasBomb);
                }
            }
        }

        private static bool findRandomLuckForBomb()
        {
            Random rand = new Random();
            bool hasBomb;
            if (rand.Next(1, 4) == 1)
            {
                hasBomb = true;
            }
            else hasBomb = false;
            return hasBomb;
        }
    }
}