namespace Lab07.Forms;

partial class FrmMain
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.menuStrip = new MenuStrip();
        this.mnuSystem = new ToolStripMenuItem();
        this.mnuLogout = new ToolStripMenuItem();
        this.mnuExit = new ToolStripMenuItem();
        this.mnuCatalog = new ToolStripMenuItem();
        this.mnuProduct = new ToolStripMenuItem();
        this.mnuCustomer = new ToolStripMenuItem();
        this.mnuHelp = new ToolStripMenuItem();
        this.mnuAbout = new ToolStripMenuItem();
        this.statusStrip = new StatusStrip();
        this.lblUser = new ToolStripStatusLabel();
        this.lblRole = new ToolStripStatusLabel();
        this.lblTime = new ToolStripStatusLabel();
        this.tmrClock = new System.Windows.Forms.Timer(this.components);
        this.menuStrip.SuspendLayout();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();

        this.menuStrip.Name = "menuStrip";
        this.menuStrip.Location = new Point(0, 0);
        this.menuStrip.Size = new Size(1100, 24);
        this.menuStrip.TabIndex = 0;
        this.menuStrip.Items.AddRange(new ToolStripItem[] {
            this.mnuSystem,
            this.mnuCatalog,
            this.mnuHelp});

        this.mnuSystem.Name = "mnuSystem";
        this.mnuSystem.Text = "Hệ thống";
        this.mnuSystem.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuLogout,
            this.mnuExit});

        this.mnuLogout.Name = "mnuLogout";
        this.mnuLogout.Text = "Đăng xuất";
        this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);

        this.mnuExit.Name = "mnuExit";
        this.mnuExit.Text = "Thoát";
        this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);

        this.mnuCatalog.Name = "mnuCatalog";
        this.mnuCatalog.Text = "Danh mục";
        this.mnuCatalog.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuProduct,
            this.mnuCustomer});

        this.mnuProduct.Name = "mnuProduct";
        this.mnuProduct.Text = "Quản lý sản phẩm";
        this.mnuProduct.Click += new System.EventHandler(this.mnuProduct_Click);

        this.mnuCustomer.Name = "mnuCustomer";
        this.mnuCustomer.Text = "Quản lý khách hàng";
        this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);

        this.mnuHelp.Name = "mnuHelp";
        this.mnuHelp.Text = "Trợ giúp";
        this.mnuHelp.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuAbout});

        this.mnuAbout.Name = "mnuAbout";
        this.mnuAbout.Text = "Giới thiệu";
        this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);

        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Location = new Point(0, 678);
        this.statusStrip.Size = new Size(1100, 22);
        this.statusStrip.TabIndex = 1;
        this.statusStrip.Items.AddRange(new ToolStripItem[] {
            this.lblUser,
            this.lblRole,
            this.lblTime});

        this.lblUser.Name = "lblUser";
        this.lblUser.Text = "Người dùng:";

        this.lblRole.Name = "lblRole";
        this.lblRole.Text = "Vai trò:";

        this.lblTime.Name = "lblTime";
        this.lblTime.Spring = true;
        this.lblTime.Text = "";
        this.lblTime.TextAlign = ContentAlignment.MiddleRight;

        this.tmrClock.Enabled = true;
        this.tmrClock.Interval = 1000;
        this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1100, 700);
        this.IsMdiContainer = true;
        this.MainMenuStrip = this.menuStrip;
        this.Name = "FrmMain";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Lab07 - Quản lý cửa hàng mini";
        this.Controls.Add(this.statusStrip);
        this.Controls.Add(this.menuStrip);
        this.Load += new System.EventHandler(this.FrmMain_Load);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);

        this.menuStrip.ResumeLayout(false);
        this.menuStrip.PerformLayout();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private MenuStrip menuStrip;
    private ToolStripMenuItem mnuSystem;
    private ToolStripMenuItem mnuLogout;
    private ToolStripMenuItem mnuExit;
    private ToolStripMenuItem mnuCatalog;
    private ToolStripMenuItem mnuProduct;
    private ToolStripMenuItem mnuCustomer;
    private ToolStripMenuItem mnuHelp;
    private ToolStripMenuItem mnuAbout;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblUser;
    private ToolStripStatusLabel lblRole;
    private ToolStripStatusLabel lblTime;
    private System.Windows.Forms.Timer tmrClock;
}
