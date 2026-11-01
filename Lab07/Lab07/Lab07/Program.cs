using Lab07.Forms;

namespace Lab07;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        bool showLoginAgain;
        do
        {
            using var login = new FrmLogin();
            if (login.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using var main = new FrmMain { CurrentUser = login.CurrentUser };
            Application.Run(main);
            showLoginAgain = main.LoggedOut;
        }
        while (showLoginAgain);
    }
}
