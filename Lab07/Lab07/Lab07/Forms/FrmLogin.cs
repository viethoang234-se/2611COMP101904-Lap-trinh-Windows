using Lab07.Data;
using Lab07.Helpers;
using Lab07.Models;

namespace Lab07.Forms;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
    }

    public User CurrentUser { get; private set; }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        if (username.Length == 0 || password.Length == 0)
        {
            Msg.Warn("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
            (username.Length == 0 ? txtUsername : txtPassword).Focus();
            return;
        }

        User user = DataStore.Users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);

        if (user == null)
        {
            Msg.Error("Tên đăng nhập hoặc mật khẩu không đúng.");
            txtPassword.Clear();
            txtPassword.Focus();
            return;
        }

        CurrentUser = user;
        DialogResult = DialogResult.OK;
    }
}
