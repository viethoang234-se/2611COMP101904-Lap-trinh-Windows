namespace Lab11.Forms;

partial class FrmLop
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
        this.lblMaLop = new Label();
        this.txtMaLop = new TextBox();
        this.lblTenLop = new Label();
        this.txtTenLop = new TextBox();
        this.btnThem = new Button();
        this.btnSua = new Button();
        this.btnXoa = new Button();
        this.btnLamMoi = new Button();
        this.txtTimKiem = new TextBox();
        this.btnTimKiem = new Button();
        this.dgvLop = new DataGridView();
        this.colMaLop = new DataGridViewTextBoxColumn();
        this.colTenLop = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
        this.SuspendLayout();

        this.lblMaLop.Name = "lblMaLop";
        this.lblMaLop.AutoSize = true;
        this.lblMaLop.Location = new Point(20, 23);
        this.lblMaLop.Text = "Mã lớp";
        this.lblMaLop.TabIndex = 0;

        this.txtMaLop.Name = "txtMaLop";
        this.txtMaLop.Location = new Point(100, 20);
        this.txtMaLop.Size = new Size(160, 23);
        this.txtMaLop.MaxLength = 20;
        this.txtMaLop.TabIndex = 1;

        this.lblTenLop.Name = "lblTenLop";
        this.lblTenLop.AutoSize = true;
        this.lblTenLop.Location = new Point(290, 23);
        this.lblTenLop.Text = "Tên lớp";
        this.lblTenLop.TabIndex = 2;

        this.txtTenLop.Name = "txtTenLop";
        this.txtTenLop.Location = new Point(360, 20);
        this.txtTenLop.Size = new Size(260, 23);
        this.txtTenLop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.txtTenLop.MaxLength = 100;
        this.txtTenLop.TabIndex = 3;

        this.btnThem.Name = "btnThem";
        this.btnThem.Location = new Point(20, 62);
        this.btnThem.Size = new Size(100, 32);
        this.btnThem.Text = "Thêm";
        this.btnThem.UseVisualStyleBackColor = true;
        this.btnThem.TabIndex = 4;
        this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

        this.btnSua.Name = "btnSua";
        this.btnSua.Location = new Point(130, 62);
        this.btnSua.Size = new Size(100, 32);
        this.btnSua.Text = "Sửa";
        this.btnSua.UseVisualStyleBackColor = true;
        this.btnSua.TabIndex = 5;
        this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

        this.btnXoa.Name = "btnXoa";
        this.btnXoa.Location = new Point(240, 62);
        this.btnXoa.Size = new Size(100, 32);
        this.btnXoa.Text = "Xóa";
        this.btnXoa.UseVisualStyleBackColor = true;
        this.btnXoa.TabIndex = 6;
        this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

        this.btnLamMoi.Name = "btnLamMoi";
        this.btnLamMoi.Location = new Point(350, 62);
        this.btnLamMoi.Size = new Size(100, 32);
        this.btnLamMoi.Text = "Làm mới";
        this.btnLamMoi.UseVisualStyleBackColor = true;
        this.btnLamMoi.TabIndex = 7;
        this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

        this.txtTimKiem.Name = "txtTimKiem";
        this.txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.txtTimKiem.Location = new Point(20, 116);
        this.txtTimKiem.PlaceholderText = "Nhập mã hoặc tên lớp...";
        this.txtTimKiem.Size = new Size(480, 23);
        this.txtTimKiem.TabIndex = 8;
        this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);

        this.btnTimKiem.Name = "btnTimKiem";
        this.btnTimKiem.Location = new Point(520, 111);
        this.btnTimKiem.Size = new Size(100, 32);
        this.btnTimKiem.Text = "Tìm kiếm";
        this.btnTimKiem.UseVisualStyleBackColor = true;
        this.btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.btnTimKiem.TabIndex = 9;
        this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

        this.dgvLop.Name = "dgvLop";
        this.dgvLop.AllowUserToAddRows = false;
        this.dgvLop.AllowUserToDeleteRows = false;
        this.dgvLop.AllowUserToResizeRows = false;
        this.dgvLop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.dgvLop.AutoGenerateColumns = false;
        this.dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvLop.BackgroundColor = SystemColors.Window;
        this.dgvLop.Location = new Point(20, 155);
        this.dgvLop.MultiSelect = false;
        this.dgvLop.ReadOnly = true;
        this.dgvLop.RowHeadersVisible = false;
        this.dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvLop.Size = new Size(600, 305);
        this.dgvLop.TabIndex = 10;
        this.dgvLop.Columns.AddRange(new DataGridViewColumn[] {
            this.colMaLop,
            this.colTenLop});
        this.dgvLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLop_CellClick);

        this.colMaLop.Name = "colMaLop";
        this.colMaLop.DataPropertyName = "MaLop";
        this.colMaLop.FillWeight = 30F;
        this.colMaLop.HeaderText = "Mã lớp";

        this.colTenLop.Name = "colTenLop";
        this.colTenLop.DataPropertyName = "TenLop";
        this.colTenLop.FillWeight = 70F;
        this.colTenLop.HeaderText = "Tên lớp";

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(640, 480);
        this.MinimumSize = new Size(656, 519);
        this.Name = "FrmLop";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Quản lý lớp học";
        this.Controls.Add(this.lblMaLop);
        this.Controls.Add(this.txtMaLop);
        this.Controls.Add(this.lblTenLop);
        this.Controls.Add(this.txtTenLop);
        this.Controls.Add(this.btnThem);
        this.Controls.Add(this.btnSua);
        this.Controls.Add(this.btnXoa);
        this.Controls.Add(this.btnLamMoi);
        this.Controls.Add(this.txtTimKiem);
        this.Controls.Add(this.btnTimKiem);
        this.Controls.Add(this.dgvLop);
        this.Load += new System.EventHandler(this.FrmLop_Load);

        ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Label lblMaLop;
    private TextBox txtMaLop;
    private Label lblTenLop;
    private TextBox txtTenLop;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;
    private TextBox txtTimKiem;
    private Button btnTimKiem;
    private DataGridView dgvLop;
    private DataGridViewTextBoxColumn colMaLop;
    private DataGridViewTextBoxColumn colTenLop;
}
