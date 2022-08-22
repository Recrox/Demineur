using Demineur.Model;
using System.Runtime.CompilerServices;

namespace Demineur
{
    public partial class DemineurView : Form
    {
        private Board board;
        private const int CELL_SIZE = 25;
        public int x_size;
        public int y_size;

        internal DemineurView(Board board)
        {
            this.board = board;
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {

            x_size = board.TabCell.GetLength(0);
            y_size = board.TabCell.GetLength(1);
            Button[,] cells = new Button[x_size, y_size];

            for (int i = 0; i < x_size; i++)
            {
                for (int j = 0; j < y_size; j++)
                {
                    Button cell = new Button();
                    cell.Location = new System.Drawing.Point(CELL_SIZE * j, CELL_SIZE * i);
                    cell.Size = new System.Drawing.Size(CELL_SIZE, CELL_SIZE);
                    cells[i, j] = cell;
                    cell.Click += button_Click;
                    //cell. = board[j, i];

                    this.Controls.Add(cell);
                    
                }
            }
        }

        private static void button_Click(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;
            button.Enabled = false;
            if (true)
            {
                button.Text = "B";
            }
        }


    }
}