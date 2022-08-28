using Demineur.Model;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Demineur
{
    public partial class DemineurView : Form
    {
        private Board board;
        private const int CELL_SIZE = 25;
        private Button[,] buttons = new Button[Board.X_SIZE, Board.Y_SIZE];

        internal DemineurView(Board board)
        {
            this.board = board;
            InitializeComponent();
            InitializeBoard();
            //this.ActiveControl = null;
    }

        private void InitializeBoard()
        {
            for (int i = 0; i < Board.X_SIZE; i++)
            {
                for (int j = 0; j < Board.Y_SIZE; j++)
                {
                    Button cell = new Button();
                    cell.Location = new System.Drawing.Point(CELL_SIZE * i, CELL_SIZE * j);
                    cell.Size = new System.Drawing.Size(CELL_SIZE, CELL_SIZE);
                    cell.Click += button_Click;

                    buttons[i,j] = cell;
                    this.Controls.Add(cell);
                }
            }
            this.AutoSize = true;
        }

        private void button_Click(object sender, EventArgs eventArgs)
        {

            Button button = (Button)sender;
            button.Enabled = false;

            int index_x = button.Location.X / CELL_SIZE;
            int index_y = button.Location.Y / CELL_SIZE;

            board.DiscoverCell(index_x, index_y);

            if (HadBomb(index_x, index_y))
            {
                button.Text = "X";
                //MessageBox.Show("U Lose noob");
            }
            
            else if (board.Had0BombAround(index_x, index_y))
            {
                DiscoverEmptyCellAround(index_x, index_y);
            }
            
            else
            {
                button.Text = board.TabCell[index_x, index_y].BombAround.ToString();
            }
        }

        

        private bool HadBomb(int index_x, int index_y)
        {
            return board.TabCell[index_x, index_y].HasBomb == true;
        }

        private void DiscoverEmptyCellAround(int index_x, int index_y)
        {
            for (int i = index_x - 1; i < index_x - 1 + Board.LINE_ANALYSYS; i++)
            {
                for (int j = index_y - 1; j < index_y - 1 + Board.COLUMN_ANALYSYS; j++)
                {
                    try
                    {
                        if (!HadBomb(i,j))
                        {
                            this.board.DiscoverCell(i, j);
                            this.buttons[i, j].Text = this.board.TabCell[i, j].BombAround.ToString();
                            this.buttons[i, j].Enabled = false;
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Print(e.Message+" VIEW " + i + j);
                        new IndexOutOfRangeException();
                    }
                }
            }
        }
    }
}