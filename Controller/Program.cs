using Demineur.Model;

namespace Demineur.Controller
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            Board board = new Board();
            ApplicationConfiguration.Initialize();
            Application.Run(new DemineurView(board));
        }
    }
}