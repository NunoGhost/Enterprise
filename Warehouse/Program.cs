using System;
using System.Windows.Forms;
//using System.ServiceModel;

namespace Warehouse
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            int a = 2;
            int b = 3;
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new OrdersView());
        }
    }
}
