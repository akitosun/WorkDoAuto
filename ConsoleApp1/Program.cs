using System;
using System.Text;
using System.Windows.Forms;

namespace WorkDoWinService
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WorkDoAutoPunchService", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
