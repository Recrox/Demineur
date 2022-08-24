using Demineur.Model;
using System.Runtime.CompilerServices;

namespace Demineur
{
    public partial class DemineurView : Form
    {
        private Board board;
        private const int CELL_SIZE = 25;
        private Button[,] buttons;

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

                    //this.buttons[i, j] = cell;
                    this.Controls.Add(cell);
                }
            }
            this.AutoSize = true;
            //this.Size = new System.Drawing.Size(CELL_SIZE* Board.X_SIZE, CELL_SIZE* Board.Y_SIZE);
        }

        private void button_Click(object sender, EventArgs eventArgs)
        {

            Button button = (Button)sender;
            button.Enabled = false;

            int index_x = button.Location.X / CELL_SIZE;
            int index_y = button.Location.Y / CELL_SIZE;

            board.DiscoverCell(index_x, index_y);

            if (board.TabCell[index_x, index_y].HasBomb == true) {
                button.Text = "X";
                MessageBox.Show("U Lose noob");
            }
            else if (board.TabCell[index_x, index_y].BombAround == 0)
            {
                for (int i = index_x - 1; i < index_x - 1 + Board.LINE_ANALYSYS; i++)
                {
                    for (int j = index_y - 1; j < index_y - 1 + Board.COLUMN_ANALYSYS; j++)
                    {
                        try
                        {
                            //this.board.DiscoverCell(i, j);
                            //this.buttons[i, j].Enabled = false;


                            if (this.board.TabCell[i, j].HasBomb == true)// 'i' mean  index_x     AND     'j' mean  index_y 
                            {

                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            new IndexOutOfRangeException();
                        }

                    }
                }
            }
            else
                button.Text = board.TabCell[index_x, index_y].BombAround.ToString();
        }
    }
}