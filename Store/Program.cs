using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Store
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainView());
        }
    }
}
