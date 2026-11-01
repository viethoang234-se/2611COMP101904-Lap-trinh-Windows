using Lab12.Forms;

namespace Lab12
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmNhapDiemTheoLop());
        }
    }
}
