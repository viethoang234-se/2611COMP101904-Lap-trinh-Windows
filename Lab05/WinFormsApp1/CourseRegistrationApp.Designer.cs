namespace CourseRegistrationApp
{
    partial class frmDangKyKhoaHoc
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTen = new Label();
            grpHocVien = new GroupBox();
            lblEmailStatus = new Label();
            chkNhanEmail = new CheckBox();
            dtpNgaySinh = new DateTimePicker();
            lblCount = new Label();
            lblNgaySinh = new Label();
            txtSoDienThoai = new TextBox();
            lblSDT = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            grpKhoaHoc = new GroupBox();
            lblTienTong = new Label();
            lblTongTien = new Label();
            lblHocPhi = new Label();
            numSoThang = new NumericUpDown();
            radOffline = new RadioButton();
            radOnline = new RadioButton();
            cboKhoaHoc = new ComboBox();
            lblHienThiHocPhi = new Label();
            lblSoThang = new Label();
            lblHinhThucHoc = new Label();
            lblKhoaHoc = new Label();
            panel1 = new Panel();
            btnThoat = new Button();
            btnLamMoi = new Button();
            btnDangKy = new Button();
            grpHocVien.SuspendLayout();
            grpKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Calibri", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTen.ForeColor = Color.FromArgb(0, 0, 192);
            lblTen.Location = new Point(322, 28);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(317, 42);
            lblTen.TabIndex = 0;
            lblTen.Text = "ĐĂNG KÝ KHOÁ HỌC";
            // 
            // grpHocVien
            // 
            grpHocVien.BackColor = Color.Lavender;
            grpHocVien.Controls.Add(lblEmailStatus);
            grpHocVien.Controls.Add(chkNhanEmail);
            grpHocVien.Controls.Add(dtpNgaySinh);
            grpHocVien.Controls.Add(lblCount);
            grpHocVien.Controls.Add(lblNgaySinh);
            grpHocVien.Controls.Add(txtSoDienThoai);
            grpHocVien.Controls.Add(lblSDT);
            grpHocVien.Controls.Add(txtHoTen);
            grpHocVien.Controls.Add(lblHoTen);
            grpHocVien.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpHocVien.ForeColor = SystemColors.ActiveCaptionText;
            grpHocVien.Location = new Point(26, 91);
            grpHocVien.Name = "grpHocVien";
            grpHocVien.Size = new Size(432, 222);
            grpHocVien.TabIndex = 1;
            grpHocVien.TabStop = false;
            grpHocVien.Text = "THÔNG TIN HỌC VIÊN";
            // 
            // lblEmailStatus
            // 
            lblEmailStatus.AutoSize = true;
            lblEmailStatus.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmailStatus.ForeColor = SystemColors.ActiveCaptionText;
            lblEmailStatus.Location = new Point(127, 181);
            lblEmailStatus.Name = "lblEmailStatus";
            lblEmailStatus.Size = new Size(194, 18);
            lblEmailStatus.TabIndex = 10;
            lblEmailStatus.Text = "(Không nhận email thông báo)";
            // 
            // chkNhanEmail
            // 
            chkNhanEmail.AutoSize = true;
            chkNhanEmail.Checked = true;
            chkNhanEmail.CheckState = CheckState.Checked;
            chkNhanEmail.Location = new Point(13, 156);
            chkNhanEmail.Name = "chkNhanEmail";
            chkNhanEmail.Size = new Size(163, 22);
            chkNhanEmail.TabIndex = 9;
            chkNhanEmail.Text = "Nhận email thông báo";
            chkNhanEmail.UseVisualStyleBackColor = true;
            chkNhanEmail.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(91, 113);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(262, 26);
            dtpNgaySinh.TabIndex = 8;
            dtpNgaySinh.UseWaitCursor = true;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.ForeColor = SystemColors.ActiveBorder;
            lblCount.Location = new Point(359, 43);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(35, 18);
            lblCount.TabIndex = 6;
            lblCount.Text = "0/50";
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(13, 121);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(72, 18);
            lblNgaySinh.TabIndex = 4;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(91, 73);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(262, 26);
            txtSoDienThoai.TabIndex = 3;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(51, 81);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(34, 18);
            lblSDT.TabIndex = 2;
            lblSDT.Text = "SĐT:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(91, 35);
            txtHoTen.MaxLength = 50;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(262, 26);
            txtHoTen.TabIndex = 1;
            txtHoTen.TextChanged += txtHoTen_TextChanged;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(32, 43);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(53, 18);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên:";
            // 
            // grpKhoaHoc
            // 
            grpKhoaHoc.BackColor = Color.Lavender;
            grpKhoaHoc.Controls.Add(lblTienTong);
            grpKhoaHoc.Controls.Add(lblTongTien);
            grpKhoaHoc.Controls.Add(lblHocPhi);
            grpKhoaHoc.Controls.Add(numSoThang);
            grpKhoaHoc.Controls.Add(radOffline);
            grpKhoaHoc.Controls.Add(radOnline);
            grpKhoaHoc.Controls.Add(cboKhoaHoc);
            grpKhoaHoc.Controls.Add(lblHienThiHocPhi);
            grpKhoaHoc.Controls.Add(lblSoThang);
            grpKhoaHoc.Controls.Add(lblHinhThucHoc);
            grpKhoaHoc.Controls.Add(lblKhoaHoc);
            grpKhoaHoc.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpKhoaHoc.ForeColor = SystemColors.ActiveCaptionText;
            grpKhoaHoc.Location = new Point(473, 91);
            grpKhoaHoc.Name = "grpKhoaHoc";
            grpKhoaHoc.Size = new Size(432, 222);
            grpKhoaHoc.TabIndex = 11;
            grpKhoaHoc.TabStop = false;
            grpKhoaHoc.Text = "THÔNG TIN KHOÁ HỌC";
            // 
            // lblTienTong
            // 
            lblTienTong.AutoSize = true;
            lblTienTong.Location = new Point(20, 181);
            lblTienTong.Name = "lblTienTong";
            lblTienTong.Size = new Size(68, 18);
            lblTienTong.TabIndex = 17;
            lblTienTong.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongTien.ForeColor = Color.ForestGreen;
            lblTongTien.Location = new Point(119, 181);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(47, 18);
            lblTongTien.TabIndex = 16;
            lblTongTien.Text = "0 VNĐ";
            // 
            // lblHocPhi
            // 
            lblHocPhi.AutoSize = true;
            lblHocPhi.Location = new Point(20, 156);
            lblHocPhi.Name = "lblHocPhi";
            lblHocPhi.Size = new Size(95, 18);
            lblHocPhi.TabIndex = 15;
            lblHocPhi.Text = "Học phí tháng:";
            // 
            // numSoThang
            // 
            numSoThang.Location = new Point(119, 113);
            numSoThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(120, 26);
            numSoThang.TabIndex = 14;
            numSoThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.ValueChanged += numThang_ValueChanged_1;
            // 
            // radOffline
            // 
            radOffline.AutoSize = true;
            radOffline.Location = new Point(253, 79);
            radOffline.Name = "radOffline";
            radOffline.Size = new Size(68, 22);
            radOffline.TabIndex = 13;
            radOffline.TabStop = true;
            radOffline.Text = "Offline";
            radOffline.UseVisualStyleBackColor = true;
            radOffline.CheckedChanged += rbOffline_CheckedChanged;
            // 
            // radOnline
            // 
            radOnline.AutoSize = true;
            radOnline.Location = new Point(127, 79);
            radOnline.Name = "radOnline";
            radOnline.Size = new Size(68, 22);
            radOnline.TabIndex = 12;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            radOnline.CheckedChanged += rbOnline_CheckedChanged;
            // 
            // cboKhoaHoc
            // 
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(119, 40);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(234, 26);
            cboKhoaHoc.TabIndex = 11;
            cboKhoaHoc.SelectedIndexChanged += cbKhoaHoc_SelectedIndexChanged;
            // 
            // lblHienThiHocPhi
            // 
            lblHienThiHocPhi.AutoSize = true;
            lblHienThiHocPhi.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHienThiHocPhi.ForeColor = SystemColors.ActiveCaptionText;
            lblHienThiHocPhi.Location = new Point(119, 156);
            lblHienThiHocPhi.Name = "lblHienThiHocPhi";
            lblHienThiHocPhi.Size = new Size(47, 18);
            lblHienThiHocPhi.TabIndex = 10;
            lblHienThiHocPhi.Text = "0 VNĐ";
            // 
            // lblSoThang
            // 
            lblSoThang.AutoSize = true;
            lblSoThang.Location = new Point(20, 119);
            lblSoThang.Name = "lblSoThang";
            lblSoThang.Size = new Size(65, 18);
            lblSoThang.TabIndex = 4;
            lblSoThang.Text = "Số tháng:";
            // 
            // lblHinhThucHoc
            // 
            lblHinhThucHoc.AutoSize = true;
            lblHinhThucHoc.Location = new Point(20, 81);
            lblHinhThucHoc.Name = "lblHinhThucHoc";
            lblHinhThucHoc.Size = new Size(96, 18);
            lblHinhThucHoc.TabIndex = 2;
            lblHinhThucHoc.Text = "Hình thức học:";
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(20, 48);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(68, 18);
            lblKhoaHoc.TabIndex = 0;
            lblKhoaHoc.Text = "Khoá học:";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(btnDangKy);
            panel1.Location = new Point(231, 336);
            panel1.Name = "panel1";
            panel1.Size = new Size(473, 62);
            panel1.TabIndex = 12;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Maroon;
            btnThoat.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnThoat.ForeColor = SystemColors.ButtonHighlight;
            btnThoat.Location = new Point(325, 13);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(133, 36);
            btnThoat.TabIndex = 2;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click_1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.MidnightBlue;
            btnLamMoi.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnLamMoi.ForeColor = SystemColors.ButtonHighlight;
            btnLamMoi.Location = new Point(170, 13);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(133, 36);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click_1;
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Color.DarkGreen;
            btnDangKy.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnDangKy.ForeColor = SystemColors.ButtonHighlight;
            btnDangKy.Location = new Point(15, 12);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(133, 36);
            btnDangKy.TabIndex = 0;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click_1;
            // 
            // frmDangKyKhoaHoc
            // 
            AutoScaleDimensions = new SizeF(6F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 439);
            Controls.Add(panel1);
            Controls.Add(grpKhoaHoc);
            Controls.Add(grpHocVien);
            Controls.Add(lblTen);
            Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmDangKyKhoaHoc";
            Text = "Đăng ký khoá học";
            Load += Form1_Load;
            grpHocVien.ResumeLayout(false);
            grpHocVien.PerformLayout();
            grpKhoaHoc.ResumeLayout(false);
            grpKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTen;
        private GroupBox grpHocVien;
        private Label lblHoTen;
        private CheckBox chkNhanEmail;
        private DateTimePicker dtpNgaySinh;
        private Label lblCount;
        private Label lblNgaySinh;
        private TextBox txtSoDienThoai;
        private Label lblSDT;
        private TextBox txtHoTen;
        private Label lblEmailStatus;
        private GroupBox grpKhoaHoc;
        private Label lblHienThiHocPhi;
        private Label lblSoThang;
        private Label lblHinhThucHoc;
        private Label lblKhoaHoc;
        private ComboBox cboKhoaHoc;
        private RadioButton radOffline;
        private RadioButton radOnline;
        private NumericUpDown numSoThang;
        private Label lblHocPhi;
        private Label lblTienTong;
        private Label lblTongTien;
        private Panel panel1;
        private Button btnThoat;
        private Button btnLamMoi;
        private Button btnDangKy;
    }
}
