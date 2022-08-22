using Demineur.Model;

namespace Demineur
{
    public partial class DemineurView : Form
    {
        private Board board;
        internal DemineurView(Board board)
        {
            this.board = board;
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Button[,] cells = new Button[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button cell = new Button();
                    cells[i,j] = cell;
                }
                
            }
        }
    }
}