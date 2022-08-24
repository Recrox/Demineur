using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demineur.Model
{
    internal class Board
    {
        private static int line_ANALYSYS = 3;
        private static int column_ANALYSYS = 3;
        private const int LuckToFindBomb = 6;
        private static int x_SIZE = 20;
        private static int y_SIZE = 20;
        private Cell[,] tabCell = new Cell[X_SIZE, Y_SIZE];
        public Cell[,] TabCell { get => tabCell; set => tabCell = value; }
        public static int X_SIZE { get => x_SIZE; set => x_SIZE = value; }
        public static int Y_SIZE { get => y_SIZE; set => y_SIZE = value; }
        public static int LINE_ANALYSYS { get => line_ANALYSYS; set => line_ANALYSYS = value; }
        public static int COLUMN_ANALYSYS { get => column_ANALYSYS; set => column_ANALYSYS = value; }

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

        private bool findRandomLuckForBomb()
        {
            Random rand = new Random();
            bool hasBomb;
            if (rand.Next(1, LuckToFindBomb) == 1)
            {
                hasBomb = true;
            }
            else hasBomb = false;
            return hasBomb;
        }

        public void DiscoverCell(int index_x, int index_y)
        {
            this.tabCell[index_x, index_y].IsDiscover = true;

            int BombAround = CountHowManyBombAround(index_x, index_y);
            this.tabCell[index_x, index_y].BombAround = BombAround;
        }

        private int CountHowManyBombAround(int index_x, int index_y)
        {
            int BombAround = 0;

            for (int i = index_x - 1; i < index_x - 1 + LINE_ANALYSYS; i++)
            {
                for (int j = index_y - 1; j < index_y - 1 + COLUMN_ANALYSYS; j++)
                {
                    try
                    {
                        if (this.tabCell[i, j].HasBomb == true)// 'i' mean  index_x     AND     'j' mean  index_y 
                        {
                            BombAround++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        new IndexOutOfRangeException();
                    }

                }
            }
            return BombAround;
        }
    }
}