using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomesForSaleExeCS
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
            Form homesForSale = new HomesForSaleGUI();
            homesForSale.Text = "Homes For Sale";
            Application.Run(homesForSale);
        }
    }
}
