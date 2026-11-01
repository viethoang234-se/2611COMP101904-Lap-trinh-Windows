namespace Lab12.Forms
{
    partial class FrmNhapDiemTheoLop
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            grpChon = new GroupBox();
            btnTaiDanhSach = new Button();
            cboMonHoc = new ComboBox();
            lblMonHoc = new Label();
            cboLop = new ComboBox();
            lblLop = new Label();
            dgvKetQua = new DataGridView();
            btnLuuTatCa = new Button();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblThongKe = new ToolStripStatusLabel();
            grpChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(31, 78, 140);
            lblTieuDe.Location = new Point(20, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(260, 30);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "NHẬP ĐIỂM THEO LỚP";
            // 
            // grpChon
            // 
            grpChon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChon.Controls.Add(btnTaiDanhSach);
            grpChon.Controls.Add(cboMonHoc);
            grpChon.Controls.Add(lblMonHoc);
            grpChon.Controls.Add(cboLop);
            grpChon.Controls.Add(lblLop);
            grpChon.Location = new Point(20, 55);
            grpChon.Name = "grpChon";
            grpChon.Size = new Size(920, 80);
            grpChon.TabIndex = 1;
            grpChon.TabStop = false;
            grpChon.Text = "Chọn lớp và môn học";
            // 
            // btnTaiDanhSach
            // 
            btnTaiDanhSach.BackColor = Color.FromArgb(31, 78, 140);
            btnTaiDanhSach.FlatStyle = FlatStyle.Flat;
            btnTaiDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaiDanhSach.ForeColor = Color.White;
            btnTaiDanhSach.Location = new Point(700, 29);
            btnTaiDanhSach.Name = "btnTaiDanhSach";
            btnTaiDanhSach.Size = new Size(190, 36);
            btnTaiDanhSach.TabIndex = 4;
            btnTaiDanhSach.Text = "Tải danh sách";
            btnTaiDanhSach.UseVisualStyleBackColor = false;
            btnTaiDanhSach.Click += btnTaiDanhSach_Click;
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(440, 33);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(230, 25);
            cboMonHoc.TabIndex = 3;
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Location = new Point(365, 36);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(61, 17);
            lblMonHoc.TabIndex = 2;
            lblMonHoc.Text = "Môn học:";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(70, 33);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(270, 25);
            cboLop.TabIndex = 1;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(20, 36);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(34, 17);
            lblLop.TabIndex = 0;
            lblLop.Text = "Lớp:";
            // 
            // dgvKetQua
            // 
            dgvKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKetQua.BackgroundColor = SystemColors.Window;
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKetQua.Location = new Point(20, 150);
            dgvKetQua.MultiSelect = false;
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvKetQua.Size = new Size(920, 370);
            dgvKetQua.TabIndex = 2;
            dgvKetQua.CellEndEdit += dgvKetQua_CellEndEdit;
            dgvKetQua.DataError += dgvKetQua_DataError;
            // 
            // btnLuuTatCa
            // 
            btnLuuTatCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuuTatCa.BackColor = Color.FromArgb(40, 140, 90);
            btnLuuTatCa.Enabled = false;
            btnLuuTatCa.FlatStyle = FlatStyle.Flat;
            btnLuuTatCa.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLuuTatCa.ForeColor = Color.White;
            btnLuuTatCa.Location = new Point(770, 534);
            btnLuuTatCa.Name = "btnLuuTatCa";
            btnLuuTatCa.Size = new Size(170, 42);
            btnLuuTatCa.TabIndex = 3;
            btnLuuTatCa.Text = "Lưu tất cả";
            btnLuuTatCa.UseVisualStyleBackColor = false;
            btnLuuTatCa.Click += btnLuuTatCa_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, lblThongKe });
            statusStrip1.Location = new Point(0, 590);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(960, 30);
            statusStrip1.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(500, 25);
            lblStatus.Spring = true;
            lblStatus.Text = "Sẵn sàng";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblThongKe
            // 
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new Size(300, 25);
            lblThongKe.Text = "Sinh viên: 0 | Đã nhập: 0 | Đạt: 0 | ĐTB: 0.00";
            // 
            // FrmNhapDiemTheoLop
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 620);
            Controls.Add(statusStrip1);
            Controls.Add(btnLuuTatCa);
            Controls.Add(dgvKetQua);
            Controls.Add(grpChon);
            Controls.Add(lblTieuDe);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(800, 500);
            Name = "FrmNhapDiemTheoLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "COMP1019 - Lab 12: Nhập điểm theo lớp";
            Load += FrmNhapDiemTheoLop_Load;
            grpChon.ResumeLayout(false);
            grpChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private GroupBox grpChon;
        private Label lblLop;
        private ComboBox cboLop;
        private Label lblMonHoc;
        private ComboBox cboMonHoc;
        private Button btnTaiDanhSach;
        private DataGridView dgvKetQua;
        private Button btnLuuTatCa;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblThongKe;
    }
}
