#nullable disable
namespace ProductManager
{
    partial class FrmProduct
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuFileExit = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuThem = new ToolStripMenuItem();
            mnuSua = new ToolStripMenuItem();
            mnuXoa = new ToolStripMenuItem();
            mnuLamMoi = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            tsbThem = new ToolStripButton();
            tsbSua = new ToolStripButton();
            tsbXoa = new ToolStripButton();
            tsbLamMoi = new ToolStripButton();
            tsbTimKiem = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            grpThongTin = new GroupBox();
            lblMaSP = new Label();
            lblTenSP = new Label();
            lblLoaiSP = new Label();
            lblDonGia = new Label();
            lblSoLuong = new Label();
            lblNgayNhap = new Label();
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            cboLoaiSP = new ComboBox();
            numDonGia = new NumericUpDown();
            numSoLuong = new NumericUpDown();
            dtpNgayNhap = new DateTimePicker();
            chkConKinhDoanh = new CheckBox();
            picSanPham = new PictureBox();
            btnChonAnh = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvProducts = new DataGridView();
            cmsProduct = new ContextMenuStrip(components);
            cmsSua = new ToolStripMenuItem();
            cmsXoa = new ToolStripMenuItem();
            cmsChiTiet = new ToolStripMenuItem();
            errorProvider1 = new ErrorProvider(components);
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            cmsProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuQuanLy, mnuHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1020, 24);
            menuStrip1.TabIndex = 0;
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Text = "File";
            // 
            // mnuFileExit
            // 
            mnuFileExit.Name = "mnuFileExit";
            mnuFileExit.Text = "Thoát";
            mnuFileExit.Click += mnuFileExit_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuThem, mnuSua, mnuXoa, mnuLamMoi });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuThem
            // 
            mnuThem.Name = "mnuThem";
            mnuThem.ShortcutKeys = Keys.Control | Keys.N;
            mnuThem.Text = "Thêm sản phẩm";
            mnuThem.Click += mnuThem_Click;
            // 
            // mnuSua
            // 
            mnuSua.Name = "mnuSua";
            mnuSua.ShortcutKeys = Keys.Control | Keys.E;
            mnuSua.Text = "Sửa sản phẩm";
            mnuSua.Click += mnuSua_Click;
            // 
            // mnuXoa
            // 
            mnuXoa.Name = "mnuXoa";
            mnuXoa.ShortcutKeys = Keys.Control | Keys.D;
            mnuXoa.Text = "Xóa sản phẩm";
            mnuXoa.Click += mnuXoa_Click;
            // 
            // mnuLamMoi
            // 
            mnuLamMoi.Name = "mnuLamMoi";
            mnuLamMoi.ShortcutKeys = Keys.F5;
            mnuLamMoi.Text = "Làm mới";
            mnuLamMoi.Click += mnuLamMoi_Click;
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Text = "Trợ giúp";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Text = "Giới thiệu";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbThem, tsbSua, tsbXoa, tsbLamMoi, tsbTimKiem });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1020, 25);
            toolStrip1.TabIndex = 1;
            // 
            // tsbThem
            // 
            tsbThem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbThem.Name = "tsbThem";
            tsbThem.Text = "Thêm";
            tsbThem.Click += tsbThem_Click;
            // 
            // tsbSua
            // 
            tsbSua.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbSua.Name = "tsbSua";
            tsbSua.Text = "Sửa";
            tsbSua.Click += tsbSua_Click;
            // 
            // tsbXoa
            // 
            tsbXoa.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbXoa.Name = "tsbXoa";
            tsbXoa.Text = "Xóa";
            tsbXoa.Click += tsbXoa_Click;
            // 
            // tsbLamMoi
            // 
            tsbLamMoi.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbLamMoi.Name = "tsbLamMoi";
            tsbLamMoi.Text = "Làm mới";
            tsbLamMoi.Click += tsbLamMoi_Click;
            // 
            // tsbTimKiem
            // 
            tsbTimKiem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbTimKiem.Name = "tsbTimKiem";
            tsbTimKiem.Text = "Tìm kiếm";
            tsbTimKiem.Click += tsbTimKiem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 618);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1020, 22);
            statusStrip1.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Sẵn sàng";
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblMaSP);
            grpThongTin.Controls.Add(txtMaSP);
            grpThongTin.Controls.Add(lblTenSP);
            grpThongTin.Controls.Add(txtTenSP);
            grpThongTin.Controls.Add(lblLoaiSP);
            grpThongTin.Controls.Add(cboLoaiSP);
            grpThongTin.Controls.Add(lblDonGia);
            grpThongTin.Controls.Add(numDonGia);
            grpThongTin.Controls.Add(lblSoLuong);
            grpThongTin.Controls.Add(numSoLuong);
            grpThongTin.Controls.Add(lblNgayNhap);
            grpThongTin.Controls.Add(dtpNgayNhap);
            grpThongTin.Controls.Add(chkConKinhDoanh);
            grpThongTin.Controls.Add(picSanPham);
            grpThongTin.Controls.Add(btnChonAnh);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Location = new Point(12, 60);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(380, 500);
            grpThongTin.TabIndex = 3;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sản phẩm";
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(15, 33);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Text = "Mã SP:";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(110, 30);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(250, 23);
            txtMaSP.TabIndex = 0;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Location = new Point(15, 71);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Text = "Tên SP:";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(110, 68);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(250, 23);
            txtTenSP.TabIndex = 1;
            // 
            // lblLoaiSP
            // 
            lblLoaiSP.AutoSize = true;
            lblLoaiSP.Location = new Point(15, 109);
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Text = "Loại SP:";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.Location = new Point(110, 106);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(250, 23);
            cboLoaiSP.TabIndex = 2;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(15, 147);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Text = "Đơn giá:";
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(110, 144);
            numDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(250, 23);
            numDonGia.TabIndex = 3;
            numDonGia.ThousandsSeparator = true;
            numDonGia.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(15, 185);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Text = "Số lượng:";
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(110, 182);
            numSoLuong.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(250, 23);
            numSoLuong.TabIndex = 4;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Location = new Point(15, 223);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Format = DateTimePickerFormat.Short;
            dtpNgayNhap.Location = new Point(110, 220);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(250, 23);
            dtpNgayNhap.TabIndex = 5;
            // 
            // chkConKinhDoanh
            // 
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Checked = true;
            chkConKinhDoanh.CheckState = CheckState.Checked;
            chkConKinhDoanh.Location = new Point(110, 258);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.TabIndex = 6;
            chkConKinhDoanh.Text = "Còn kinh doanh";
            chkConKinhDoanh.UseVisualStyleBackColor = true;
            // 
            // picSanPham
            // 
            picSanPham.BorderStyle = BorderStyle.FixedSingle;
            picSanPham.Location = new Point(110, 292);
            picSanPham.Name = "picSanPham";
            picSanPham.Size = new Size(150, 130);
            picSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            picSanPham.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(270, 292);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(90, 28);
            btnChonAnh.TabIndex = 7;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(15, 450);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 32);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(105, 450);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 32);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(195, 450);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(80, 32);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(285, 450);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(80, 32);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(410, 62);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm theo mã hoặc tên sản phẩm...";
            txtTimKiem.Size = new Size(300, 23);
            txtTimKiem.TabIndex = 4;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(720, 60);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(90, 28);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.ContextMenuStrip = cmsProduct;
            dgvProducts.Location = new Point(410, 95);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(598, 505);
            dgvProducts.TabIndex = 6;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellMouseDown += dgvProducts_CellMouseDown;
            dgvProducts.KeyDown += dgvProducts_KeyDown;
            // 
            // cmsProduct
            // 
            cmsProduct.Items.AddRange(new ToolStripItem[] { cmsSua, cmsXoa, cmsChiTiet });
            cmsProduct.Name = "cmsProduct";
            // 
            // cmsSua
            // 
            cmsSua.Name = "cmsSua";
            cmsSua.Text = "Sửa";
            cmsSua.Click += cmsSua_Click;
            // 
            // cmsXoa
            // 
            cmsXoa.Name = "cmsXoa";
            cmsXoa.Text = "Xóa";
            cmsXoa.Click += cmsXoa_Click;
            // 
            // cmsChiTiet
            // 
            cmsChiTiet.Name = "cmsChiTiet";
            cmsChiTiet.Text = "Xem chi tiết";
            cmsChiTiet.Click += cmsChiTiet_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 640);
            Controls.Add(dgvProducts);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(grpThongTin);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(900, 600);
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sản phẩm";
            Load += FrmProduct_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            cmsProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuFileExit;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuThem;
        private ToolStripMenuItem mnuSua;
        private ToolStripMenuItem mnuXoa;
        private ToolStripMenuItem mnuLamMoi;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuAbout;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbThem;
        private ToolStripButton tsbSua;
        private ToolStripButton tsbXoa;
        private ToolStripButton tsbLamMoi;
        private ToolStripButton tsbTimKiem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private GroupBox grpThongTin;
        private Label lblMaSP;
        private Label lblTenSP;
        private Label lblLoaiSP;
        private Label lblDonGia;
        private Label lblSoLuong;
        private Label lblNgayNhap;
        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private ComboBox cboLoaiSP;
        private NumericUpDown numDonGia;
        private NumericUpDown numSoLuong;
        private DateTimePicker dtpNgayNhap;
        private CheckBox chkConKinhDoanh;
        private PictureBox picSanPham;
        private Button btnChonAnh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvProducts;
        private ContextMenuStrip cmsProduct;
        private ToolStripMenuItem cmsSua;
        private ToolStripMenuItem cmsXoa;
        private ToolStripMenuItem cmsChiTiet;
        private ErrorProvider errorProvider1;
    }
}
