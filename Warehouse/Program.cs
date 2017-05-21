using System;
using System.Windows.Forms;
//using System.ServiceModel;
using System.Diagnostics;
using System.Windows;

namespace Warehouse
{
    public class Program : System.Windows.Application
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new OrdersView());
        }
    }
}
