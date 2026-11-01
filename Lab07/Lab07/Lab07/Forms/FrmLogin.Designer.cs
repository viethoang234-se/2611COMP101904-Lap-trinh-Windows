namespace Lab07.Forms;

partial class FrmLogin
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
        this.lblTitle = new Label();
        this.lblUsername = new Label();
        this.txtUsername = new TextBox();
        this.lblPassword = new Label();
        this.txtPassword = new TextBox();
        this.btnLogin = new Button();
        this.btnExit = new Button();
        this.SuspendLayout();

        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
        this.lblTitle.Location = new Point(16, 16);
        this.lblTitle.Size = new Size(348, 32);
        this.lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        this.lblTitle.TabIndex = 0;

        this.lblUsername.Name = "lblUsername";
        this.lblUsername.AutoSize = true;
        this.lblUsername.Location = new Point(30, 74);
        this.lblUsername.Text = "Tên đăng nhập";
        this.lblUsername.TabIndex = 1;

        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Location = new Point(140, 71);
        this.txtUsername.Size = new Size(210, 23);
        this.txtUsername.TabIndex = 2;

        this.lblPassword.Name = "lblPassword";
        this.lblPassword.AutoSize = true;
        this.lblPassword.Location = new Point(30, 114);
        this.lblPassword.Text = "Mật khẩu";
        this.lblPassword.TabIndex = 3;

        this.txtPassword.Name = "txtPassword";
        this.txtPassword.Location = new Point(140, 111);
        this.txtPassword.Size = new Size(210, 23);
        this.txtPassword.UseSystemPasswordChar = true;
        this.txtPassword.TabIndex = 4;

        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Location = new Point(140, 160);
        this.btnLogin.Size = new Size(100, 32);
        this.btnLogin.Text = "Đăng nhập";
        this.btnLogin.UseVisualStyleBackColor = true;
        this.btnLogin.TabIndex = 5;
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

        this.btnExit.Name = "btnExit";
        this.btnExit.Location = new Point(250, 160);
        this.btnExit.Size = new Size(100, 32);
        this.btnExit.Text = "Thoát";
        this.btnExit.UseVisualStyleBackColor = true;
        this.btnExit.DialogResult = DialogResult.Cancel;
        this.btnExit.TabIndex = 6;

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.AcceptButton = this.btnLogin;
        this.CancelButton = this.btnExit;
        this.ClientSize = new Size(380, 215);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmLogin";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Đăng nhập";
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.lblUsername);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.lblPassword);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.btnLogin);
        this.Controls.Add(this.btnExit);

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Label lblTitle;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblPassword;
    private TextBox txtPassword;
    private Button btnLogin;
    private Button btnExit;
}
