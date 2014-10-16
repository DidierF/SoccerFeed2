using SoccerFeed2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerFeed2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartWindow startW = new StartWindow();
            
            if (startW.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainWindow(startW.NewGame));
            }
        }
    }
}
