using Demineur.Model;
using System.Runtime.CompilerServices;

namespace Demineur
{
    public partial class DemineurView : Form
    {
        private Board board;
        private const int CELL_SIZE = 25;

        internal DemineurView(Board board)
        {
            this.board = board;
            InitializeComponent();
            InitializeBoard();
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
                    
                    this.Controls.Add(cell);
                }
            }
        }

        private void button_Click(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;
            button.Enabled = false;

            int index_x = button.Location.X / CELL_SIZE;
            int index_y = button.Location.Y / CELL_SIZE;
            
            if (board.TabCell[index_x,index_y].HasBomb == true ) button.Text = "X"; 
            else button.Text = "-";
            

        }
    }
}