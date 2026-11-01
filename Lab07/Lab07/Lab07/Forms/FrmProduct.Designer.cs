namespace Lab07.Forms;

partial class FrmProduct
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
        this.lblName = new Label();
        this.txtName = new TextBox();
        this.lblCategory = new Label();
        this.cboCategory = new ComboBox();
        this.lblPrice = new Label();
        this.txtPrice = new TextBox();
        this.lblQuantity = new Label();
        this.txtQuantity = new TextBox();
        this.btnAdd = new Button();
        this.btnEdit = new Button();
        this.btnDelete = new Button();
        this.btnRefresh = new Button();
        this.txtSearch = new TextBox();
        this.btnSearch = new Button();
        this.dgvProducts = new DataGridView();
        this.colId = new DataGridViewTextBoxColumn();
        this.colName = new DataGridViewTextBoxColumn();
        this.colCategory = new DataGridViewTextBoxColumn();
        this.colPrice = new DataGridViewTextBoxColumn();
        this.colQuantity = new DataGridViewTextBoxColumn();
        DataGridViewCellStyle numberCellStyle = new DataGridViewCellStyle();
        numberCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        numberCellStyle.Format = "N0";
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
        this.grpInfo.SuspendLayout();
        this.SuspendLayout();

        this.grpInfo.Name = "grpInfo";
        this.grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.grpInfo.Location = new Point(12, 12);
        this.grpInfo.Size = new Size(796, 145);
        this.grpInfo.Text = "Thông tin sản phẩm";
        this.grpInfo.TabIndex = 0;
        this.grpInfo.Controls.Add(this.lblId);
        this.grpInfo.Controls.Add(this.txtId);
        this.grpInfo.Controls.Add(this.lblName);
        this.grpInfo.Controls.Add(this.txtName);
        this.grpInfo.Controls.Add(this.lblCategory);
        this.grpInfo.Controls.Add(this.cboCategory);
        this.grpInfo.Controls.Add(this.lblPrice);
        this.grpInfo.Controls.Add(this.txtPrice);
        this.grpInfo.Controls.Add(this.lblQuantity);
        this.grpInfo.Controls.Add(this.txtQuantity);

        this.lblId.Name = "lblId";
        this.lblId.AutoSize = true;
        this.lblId.Location = new Point(16, 32);
        this.lblId.Text = "Mã sản phẩm";
        this.lblId.TabIndex = 0;

        this.txtId.Name = "txtId";
        this.txtId.Location = new Point(115, 29);
        this.txtId.Size = new Size(170, 23);
        this.txtId.TabIndex = 1;

        this.lblName.Name = "lblName";
        this.lblName.AutoSize = true;
        this.lblName.Location = new Point(330, 32);
        this.lblName.Text = "Tên sản phẩm";
        this.lblName.TabIndex = 2;

        this.txtName.Name = "txtName";
        this.txtName.Location = new Point(430, 29);
        this.txtName.Size = new Size(345, 23);
        this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.txtName.TabIndex = 3;

        this.lblCategory.Name = "lblCategory";
        this.lblCategory.AutoSize = true;
        this.lblCategory.Location = new Point(16, 72);
        this.lblCategory.Text = "Loại sản phẩm";
        this.lblCategory.TabIndex = 4;

        this.cboCategory.Name = "cboCategory";
        this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboCategory.Location = new Point(115, 69);
        this.cboCategory.Size = new Size(170, 23);
        this.cboCategory.TabIndex = 5;
        this.cboCategory.Items.AddRange(new object[] {
            "Đồ uống",
            "Thực phẩm",
            "Gia dụng",
            "Văn phòng phẩm"});

        this.lblPrice.Name = "lblPrice";
        this.lblPrice.AutoSize = true;
        this.lblPrice.Location = new Point(330, 72);
        this.lblPrice.Text = "Đơn giá";
        this.lblPrice.TabIndex = 6;

        this.txtPrice.Name = "txtPrice";
        this.txtPrice.Location = new Point(430, 69);
        this.txtPrice.Size = new Size(150, 23);
        this.txtPrice.TabIndex = 7;

        this.lblQuantity.Name = "lblQuantity";
        this.lblQuantity.AutoSize = true;
        this.lblQuantity.Location = new Point(16, 112);
        this.lblQuantity.Text = "Số lượng";
        this.lblQuantity.TabIndex = 8;

        this.txtQuantity.Name = "txtQuantity";
        this.txtQuantity.Location = new Point(115, 109);
        this.txtQuantity.Size = new Size(170, 23);
        this.txtQuantity.TabIndex = 9;

        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Location = new Point(12, 167);
        this.btnAdd.Size = new Size(100, 32);
        this.btnAdd.Text = "Thêm";
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.TabIndex = 1;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Location = new Point(122, 167);
        this.btnEdit.Size = new Size(100, 32);
        this.btnEdit.Text = "Sửa";
        this.btnEdit.UseVisualStyleBackColor = true;
        this.btnEdit.TabIndex = 2;
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Location = new Point(232, 167);
        this.btnDelete.Size = new Size(100, 32);
        this.btnDelete.Text = "Xóa";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.TabIndex = 3;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.Location = new Point(342, 167);
        this.btnRefresh.Size = new Size(100, 32);
        this.btnRefresh.Text = "Làm mới";
        this.btnRefresh.UseVisualStyleBackColor = true;
        this.btnRefresh.TabIndex = 4;
        this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

        this.txtSearch.Name = "txtSearch";
        this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.txtSearch.Location = new Point(480, 172);
        this.txtSearch.PlaceholderText = "Nhập mã, tên hoặc loại...";
        this.txtSearch.Size = new Size(230, 23);
        this.txtSearch.TabIndex = 5;
        this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);

        this.btnSearch.Name = "btnSearch";
        this.btnSearch.Location = new Point(720, 167);
        this.btnSearch.Size = new Size(88, 32);
        this.btnSearch.Text = "Tìm kiếm";
        this.btnSearch.UseVisualStyleBackColor = true;
        this.btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.btnSearch.TabIndex = 6;
        this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

        this.dgvProducts.Name = "dgvProducts";
        this.dgvProducts.AllowUserToAddRows = false;
        this.dgvProducts.AllowUserToDeleteRows = false;
        this.dgvProducts.AllowUserToResizeRows = false;
        this.dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.dgvProducts.AutoGenerateColumns = false;
        this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProducts.BackgroundColor = SystemColors.Window;
        this.dgvProducts.Location = new Point(12, 209);
        this.dgvProducts.MultiSelect = false;
        this.dgvProducts.ReadOnly = true;
        this.dgvProducts.RowHeadersVisible = false;
        this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProducts.Size = new Size(796, 299);
        this.dgvProducts.TabIndex = 7;
        this.dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colCategory,
            this.colPrice,
            this.colQuantity});
        this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);

        this.colId.Name = "colId";
        this.colId.DataPropertyName = "Id";
        this.colId.FillWeight = 18F;
        this.colId.HeaderText = "Mã sản phẩm";

        this.colName.Name = "colName";
        this.colName.DataPropertyName = "Name";
        this.colName.FillWeight = 34F;
        this.colName.HeaderText = "Tên sản phẩm";

        this.colCategory.Name = "colCategory";
        this.colCategory.DataPropertyName = "Category";
        this.colCategory.FillWeight = 20F;
        this.colCategory.HeaderText = "Loại sản phẩm";

        this.colPrice.Name = "colPrice";
        this.colPrice.DataPropertyName = "Price";
        this.colPrice.FillWeight = 16F;
        this.colPrice.HeaderText = "Đơn giá";
        this.colPrice.DefaultCellStyle = numberCellStyle;

        this.colQuantity.Name = "colQuantity";
        this.colQuantity.DataPropertyName = "Quantity";
        this.colQuantity.FillWeight = 12F;
        this.colQuantity.HeaderText = "Số lượng";
        this.colQuantity.DefaultCellStyle = numberCellStyle;

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(820, 520);
        this.MinimumSize = new Size(836, 559);
        this.Name = "FrmProduct";
        this.Text = "Quản lý sản phẩm";
        this.Controls.Add(this.grpInfo);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnRefresh);
        this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.dgvProducts);
        this.Load += new System.EventHandler(this.FrmProduct_Load);

        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
        this.grpInfo.ResumeLayout(false);
        this.grpInfo.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private GroupBox grpInfo;
    private Label lblId;
    private TextBox txtId;
    private Label lblName;
    private TextBox txtName;
    private Label lblCategory;
    private ComboBox cboCategory;
    private Label lblPrice;
    private TextBox txtPrice;
    private Label lblQuantity;
    private TextBox txtQuantity;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnRefresh;
    private TextBox txtSearch;
    private Button btnSearch;
    private DataGridView dgvProducts;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colName;
    private DataGridViewTextBoxColumn colCategory;
    private DataGridViewTextBoxColumn colPrice;
    private DataGridViewTextBoxColumn colQuantity;
}
