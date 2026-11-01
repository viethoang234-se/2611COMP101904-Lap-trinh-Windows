namespace Lab07.Forms;

partial class FrmCustomer
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
        this.grpInfo = new GroupBox();
        this.lblId = new Label();
        this.txtId = new TextBox();
        this.lblFullName = new Label();
        this.txtFullName = new TextBox();
        this.lblPhone = new Label();
        this.txtPhone = new TextBox();
        this.lblType = new Label();
        this.cboType = new ComboBox();
        this.btnAdd = new Button();
        this.btnEdit = new Button();
        this.btnDelete = new Button();
        this.btnRefresh = new Button();
        this.txtSearch = new TextBox();
        this.btnSearch = new Button();
        this.dgvCustomers = new DataGridView();
        this.colId = new DataGridViewTextBoxColumn();
        this.colFullName = new DataGridViewTextBoxColumn();
        this.colPhone = new DataGridViewTextBoxColumn();
        this.colType = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
        this.grpInfo.SuspendLayout();
        this.SuspendLayout();

        this.grpInfo.Name = "grpInfo";
        this.grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.grpInfo.Location = new Point(12, 12);
        this.grpInfo.Size = new Size(796, 105);
        this.grpInfo.Text = "Thông tin khách hàng";
        this.grpInfo.TabIndex = 0;
        this.grpInfo.Controls.Add(this.lblId);
        this.grpInfo.Controls.Add(this.txtId);
        this.grpInfo.Controls.Add(this.lblFullName);
        this.grpInfo.Controls.Add(this.txtFullName);
        this.grpInfo.Controls.Add(this.lblPhone);
        this.grpInfo.Controls.Add(this.txtPhone);
        this.grpInfo.Controls.Add(this.lblType);
        this.grpInfo.Controls.Add(this.cboType);

        this.lblId.Name = "lblId";
        this.lblId.AutoSize = true;
        this.lblId.Location = new Point(16, 32);
        this.lblId.Text = "Mã khách hàng";
        this.lblId.TabIndex = 0;

        this.txtId.Name = "txtId";
        this.txtId.Location = new Point(115, 29);
        this.txtId.Size = new Size(170, 23);
        this.txtId.TabIndex = 1;

        this.lblFullName.Name = "lblFullName";
        this.lblFullName.AutoSize = true;
        this.lblFullName.Location = new Point(330, 32);
        this.lblFullName.Text = "Họ tên";
        this.lblFullName.TabIndex = 2;

        this.txtFullName.Name = "txtFullName";
        this.txtFullName.Location = new Point(430, 29);
        this.txtFullName.Size = new Size(345, 23);
        this.txtFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.txtFullName.TabIndex = 3;

        this.lblPhone.Name = "lblPhone";
        this.lblPhone.AutoSize = true;
        this.lblPhone.Location = new Point(16, 72);
        this.lblPhone.Text = "Số điện thoại";
        this.lblPhone.TabIndex = 4;

        this.txtPhone.Name = "txtPhone";
        this.txtPhone.Location = new Point(115, 69);
        this.txtPhone.Size = new Size(170, 23);
        this.txtPhone.TabIndex = 5;

        this.lblType.Name = "lblType";
        this.lblType.AutoSize = true;
        this.lblType.Location = new Point(330, 72);
        this.lblType.Text = "Loại khách hàng";
        this.lblType.TabIndex = 6;

        this.cboType.Name = "cboType";
        this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboType.Location = new Point(430, 69);
        this.cboType.Size = new Size(150, 23);
        this.cboType.TabIndex = 7;
        this.cboType.Items.AddRange(new object[] {
            "Thường",
            "Thân thiết",
            "VIP"});

        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Location = new Point(12, 127);
        this.btnAdd.Size = new Size(100, 32);
        this.btnAdd.Text = "Thêm";
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.TabIndex = 1;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Location = new Point(122, 127);
        this.btnEdit.Size = new Size(100, 32);
        this.btnEdit.Text = "Sửa";
        this.btnEdit.UseVisualStyleBackColor = true;
        this.btnEdit.TabIndex = 2;
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Location = new Point(232, 127);
        this.btnDelete.Size = new Size(100, 32);
        this.btnDelete.Text = "Xóa";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.TabIndex = 3;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.Location = new Point(342, 127);
        this.btnRefresh.Size = new Size(100, 32);
        this.btnRefresh.Text = "Làm mới";
        this.btnRefresh.UseVisualStyleBackColor = true;
        this.btnRefresh.TabIndex = 4;
        this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

        this.txtSearch.Name = "txtSearch";
        this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.txtSearch.Location = new Point(480, 132);
        this.txtSearch.PlaceholderText = "Nhập mã, tên hoặc SĐT...";
        this.txtSearch.Size = new Size(230, 23);
        this.txtSearch.TabIndex = 5;
        this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);

        this.btnSearch.Name = "btnSearch";
        this.btnSearch.Location = new Point(720, 127);
        this.btnSearch.Size = new Size(88, 32);
        this.btnSearch.Text = "Tìm kiếm";
        this.btnSearch.UseVisualStyleBackColor = true;
        this.btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.btnSearch.TabIndex = 6;
        this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

        this.dgvCustomers.Name = "dgvCustomers";
        this.dgvCustomers.AllowUserToAddRows = false;
        this.dgvCustomers.AllowUserToDeleteRows = false;
        this.dgvCustomers.AllowUserToResizeRows = false;
        this.dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.dgvCustomers.AutoGenerateColumns = false;
        this.dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCustomers.BackgroundColor = SystemColors.Window;
        this.dgvCustomers.Location = new Point(12, 169);
        this.dgvCustomers.MultiSelect = false;
        this.dgvCustomers.ReadOnly = true;
        this.dgvCustomers.RowHeadersVisible = false;
        this.dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvCustomers.Size = new Size(796, 299);
        this.dgvCustomers.TabIndex = 7;
        this.dgvCustomers.Columns.AddRange(new DataGridViewColumn[] {
            this.colId,
            this.colFullName,
            this.colPhone,
            this.colType});
        this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);

        this.colId.Name = "colId";
        this.colId.DataPropertyName = "Id";
        this.colId.FillWeight = 20F;
        this.colId.HeaderText = "Mã khách hàng";

        this.colFullName.Name = "colFullName";
        this.colFullName.DataPropertyName = "FullName";
        this.colFullName.FillWeight = 35F;
        this.colFullName.HeaderText = "Họ tên";

        this.colPhone.Name = "colPhone";
        this.colPhone.DataPropertyName = "Phone";
        this.colPhone.FillWeight = 25F;
        this.colPhone.HeaderText = "Số điện thoại";

        this.colType.Name = "colType";
        this.colType.DataPropertyName = "Type";
        this.colType.FillWeight = 20F;
        this.colType.HeaderText = "Loại khách hàng";

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(820, 480);
        this.MinimumSize = new Size(836, 519);
        this.Name = "FrmCustomer";
        this.Text = "Quản lý khách hàng";
        this.Controls.Add(this.grpInfo);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnRefresh);
        this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.dgvCustomers);
        this.Load += new System.EventHandler(this.FrmCustomer_Load);

        ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
        this.grpInfo.ResumeLayout(false);
        this.grpInfo.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private GroupBox grpInfo;
    private Label lblId;
    private TextBox txtId;
    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblPhone;
    private TextBox txtPhone;
    private Label lblType;
    private ComboBox cboType;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnRefresh;
    private TextBox txtSearch;
    private Button btnSearch;
    private DataGridView dgvCustomers;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colFullName;
    private DataGridViewTextBoxColumn colPhone;
    private DataGridViewTextBoxColumn colType;
}
