using System.ComponentModel;
using Lab07.Helpers;
using Lab07.Models;

namespace Lab07.Forms;

public partial class FrmMain : Form
{
    public FrmMain()
    {
        InitializeComponent();
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public User CurrentUser { get; set; }

    [Browsable(false)]
    public bool LoggedOut { get; private set; }

    private void FrmMain_Load(object sender, EventArgs e)
    {
        lblUser.Text = $"Người dùng: {CurrentUser.FullName}";
        lblRole.Text = $"Vai trò: {CurrentUser.Role}";
        UpdateClock();
    }

    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (LoggedOut || e.CloseReason != CloseReason.UserClosing)
        {
            return;
        }

        e.Cancel = !Msg.Confirm("Bạn có chắc muốn thoát chương trình?");
    }

    private void mnuLogout_Click(object sender, EventArgs e)
    {
        if (!Msg.Confirm("Bạn có chắc muốn đăng xuất?"))
        {
            return;
        }

        LoggedOut = true;
        Close();
    }

    private void mnuExit_Click(object sender, EventArgs e) => Close();

    private void mnuProduct_Click(object sender, EventArgs e) => ShowChild<FrmProduct>();

    private void mnuCustomer_Click(object sender, EventArgs e) => ShowChild<FrmCustomer>();

    private void mnuAbout_Click(object sender, EventArgs e) => ShowChild<FrmAbout>();

    private void tmrClock_Tick(object sender, EventArgs e) => UpdateClock();

    private void UpdateClock() => lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

    private void ShowChild<T>() where T : Form, new()
    {
        T child = MdiChildren.OfType<T>().FirstOrDefault();
        if (child == null)
        {
            new T { MdiParent = this }.Show();
            return;
        }

        if (child.WindowState == FormWindowState.Minimized)
        {
            child.WindowState = FormWindowState.Normal;
        }
        child.Activate();
    }
}
