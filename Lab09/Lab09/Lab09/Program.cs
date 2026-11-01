using System;
using System.Windows.Forms;

namespace Lab09
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmStudentCard());
        }
    }
}
