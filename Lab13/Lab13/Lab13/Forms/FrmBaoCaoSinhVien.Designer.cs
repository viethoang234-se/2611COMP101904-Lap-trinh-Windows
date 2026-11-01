#nullable disable
namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
    {
        private System.ComponentModel.IContainer components = null;

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
            lblLop = new Label();
            cboLop = new ComboBox();
            lblKetQua = new Label();
            cboKetQua = new ComboBox();
            lblTuKhoa = new Label();
            txtTuKhoa = new TextBox();
            btnXemBaoCao = new Button();
            btnThongKe = new Button();
            btnXuatFile = new Button();
            dgvBaoCao = new DataGridView();
            statusStrip1 = new StatusStrip();
            lblThongKe = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(15, 19);
            lblLop.Name = "lblLop";
            lblLop.Text = "Lớp:";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(55, 15);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(200, 23);
            cboLop.TabIndex = 0;
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Location = new Point(275, 19);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Text = "Kết quả:";
            // 
            // cboKetQua
            // 
            cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQua.Location = new Point(335, 15);
            cboKetQua.Name = "cboKetQua";
            cboKetQua.Size = new Size(130, 23);
            cboKetQua.TabIndex = 1;
            // 
            // lblTuKhoa
            // 
            lblTuKhoa.AutoSize = true;
            lblTuKhoa.Location = new Point(485, 19);
            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(545, 15);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Mã hoặc họ tên...";
            txtTuKhoa.Size = new Size(220, 23);
            txtTuKhoa.TabIndex = 2;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.Location = new Point(15, 55);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(120, 30);
            btnXemBaoCao.TabIndex = 3;
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(145, 55);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(120, 30);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnXuatFile
            // 
            btnXuatFile.Location = new Point(275, 55);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(120, 30);
            btnXuatFile.TabIndex = 5;
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.UseVisualStyleBackColor = true;
            btnXuatFile.Click += btnXuatFile_Click;
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBaoCao.Location = new Point(15, 100);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.Size = new Size(860, 405);
            dgvBaoCao.TabIndex = 6;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblThongKe });
            statusStrip1.Location = new Point(0, 518);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(890, 22);
            statusStrip1.TabIndex = 7;
            // 
            // lblThongKe
            // 
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Text = "Sẵn sàng";
            // 
            // FrmBaoCaoSinhVien
            // 
            AcceptButton = btnXemBaoCao;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 540);
            Controls.Add(dgvBaoCao);
            Controls.Add(btnXuatFile);
            Controls.Add(btnThongKe);
            Controls.Add(btnXemBaoCao);
            Controls.Add(txtTuKhoa);
            Controls.Add(lblTuKhoa);
            Controls.Add(cboKetQua);
            Controls.Add(lblKetQua);
            Controls.Add(cboLop);
            Controls.Add(lblLop);
            Controls.Add(statusStrip1);
            MinimumSize = new Size(800, 450);
            Name = "FrmBaoCaoSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo danh sách sinh viên";
            Load += FrmBaoCaoSinhVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLop;
        private ComboBox cboLop;
        private Label lblKetQua;
        private ComboBox cboKetQua;
        private Label lblTuKhoa;
        private TextBox txtTuKhoa;
        private Button btnXemBaoCao;
        private Button btnThongKe;
        private Button btnXuatFile;
        private DataGridView dgvBaoCao;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblThongKe;
    }
}
