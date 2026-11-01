namespace Lab07.Forms;

partial class FrmAbout
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
        this.lblAppName = new Label();
        this.lblDescription = new Label();
        this.lblCourse = new Label();
        this.lblStudent = new Label();
        this.lblClass = new Label();
        this.btnClose = new Button();
        this.SuspendLayout();

        this.lblAppName.Name = "lblAppName";
        this.lblAppName.AutoSize = true;
        this.lblAppName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        this.lblAppName.Location = new Point(24, 20);
        this.lblAppName.Text = "Lab07";
        this.lblAppName.TabIndex = 0;

        this.lblDescription.Name = "lblDescription";
        this.lblDescription.AutoSize = true;
        this.lblDescription.Location = new Point(26, 66);
        this.lblDescription.Text = "Ứng dụng quản lý cửa hàng mini";
        this.lblDescription.TabIndex = 1;

        this.lblCourse.Name = "lblCourse";
        this.lblCourse.AutoSize = true;
        this.lblCourse.Location = new Point(26, 98);
        this.lblCourse.Text = "Môn học: COMP1019 - Lập trình trên Windows";
        this.lblCourse.TabIndex = 2;

        this.lblStudent.Name = "lblStudent";
        this.lblStudent.AutoSize = true;
        this.lblStudent.Location = new Point(26, 130);
        this.lblStudent.Text = "Sinh viên: Đỗ Việt Hoàng - MSSV: 51.01.104.031";
        this.lblStudent.TabIndex = 3;

        this.lblClass.Name = "lblClass";
        this.lblClass.AutoSize = true;
        this.lblClass.Location = new Point(26, 162);
        this.lblClass.Text = "Lớp: 51.CNTT.A";
        this.lblClass.TabIndex = 4;

        this.btnClose.Name = "btnClose";
        this.btnClose.Location = new Point(304, 206);
        this.btnClose.Size = new Size(96, 32);
        this.btnClose.Text = "Đóng";
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.TabIndex = 5;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(420, 250);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "FrmAbout";
        this.Text = "Giới thiệu";
        this.Controls.Add(this.lblAppName);
        this.Controls.Add(this.lblDescription);
        this.Controls.Add(this.lblCourse);
        this.Controls.Add(this.lblStudent);
        this.Controls.Add(this.lblClass);
        this.Controls.Add(this.btnClose);

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Label lblAppName;
    private Label lblDescription;
    private Label lblCourse;
    private Label lblStudent;
    private Label lblClass;
    private Button btnClose;
}
