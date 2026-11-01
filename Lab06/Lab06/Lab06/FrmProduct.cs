using System.ComponentModel;

namespace ProductManager
{
    public partial class FrmProduct : Form
    {
        private readonly BindingList<Product> products = new BindingList<Product>();
        private readonly BindingSource productSource = new BindingSource();
        private string selectedImagePath = string.Empty;

        public FrmProduct()
        {
            InitializeComponent();
        }

        // ===== Load form =====
        private void FrmProduct_Load(object? sender, EventArgs e)
        {
            cboLoaiSP.Items.AddRange(new object[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });
            cboLoaiSP.SelectedIndex = 0;

            products.Add(new Product
            {
                MaSP = "SP01", TenSP = "Chuột không dây", LoaiSP = "Điện tử",
                DonGia = 150000, SoLuong = 20, NgayNhap = DateTime.Today, ConKinhDoanh = true
            });
            products.Add(new Product
            {
                MaSP = "SP02", TenSP = "Bút bi", LoaiSP = "Văn phòng",
                DonGia = 5000, SoLuong = 100, NgayNhap = DateTime.Today, ConKinhDoanh = true
            });
            products.Add(new Product
            {
                MaSP = "SP03", TenSP = "Nồi cơm điện", LoaiSP = "Gia dụng",
                DonGia = 850000, SoLuong = 10, NgayNhap = DateTime.Today, ConKinhDoanh = true
            });

            productSource.DataSource = products;

            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            BindGrid(productSource);
            UpdateStatus("Sẵn sàng");
        }

        // ===== Grid =====
        private void BindGrid(object source)
        {
            dgvProducts.DataSource = source;

            SetColumn("MaSP", "Mã SP");
            SetColumn("TenSP", "Tên SP");
            SetColumn("LoaiSP", "Loại SP");
            SetColumn("DonGia", "Đơn giá", "N0");
            SetColumn("SoLuong", "Số lượng");
            SetColumn("NgayNhap", "Ngày nhập", "dd/MM/yyyy");
            SetColumn("ConKinhDoanh", "Còn KD");
            SetColumn("ThanhTien", "Thành tiền", "N0");

            DataGridViewColumn? imgCol = dgvProducts.Columns["DuongDanAnh"];
            if (imgCol != null) imgCol.Visible = false;
        }

        private void SetColumn(string name, string header, string? format = null)
        {
            DataGridViewColumn? col = dgvProducts.Columns[name];
            if (col == null) return;
            col.HeaderText = header;
            if (format != null) col.DefaultCellStyle.Format = format;
        }

        private void ShowAll()
        {
            if (dgvProducts.DataSource != productSource)
                BindGrid(productSource);
            else
                productSource.ResetBindings(false);
        }

        // ===== Validation =====
        private bool ValidateInput(bool isEdit = false)
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm không được rỗng");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được rỗng");
                isValid = false;
            }

            if (cboLoaiSP.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm");
                isValid = false;
            }

            if (numDonGia.Value <= 0)
            {
                errorProvider1.SetError(numDonGia, "Đơn giá phải lớn hơn 0");
                isValid = false;
            }

            if (dtpNgayNhap.Value.Date > DateTime.Today)
            {
                errorProvider1.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn hôm nay");
                isValid = false;
            }

            string ma = txtMaSP.Text.Trim();
            bool isDuplicate = products.Any(p => p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (!isEdit && isDuplicate)
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại");
                isValid = false;
            }

            return isValid;
        }

        // ===== Helpers =====
        private Product? GetSelectedProduct()
        {
            Product? p = dgvProducts.CurrentRow?.DataBoundItem as Product;
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return p;
        }

        private static Image? LoadImageCopy(string path)
        {
            try
            {
                using Image temp = Image.FromFile(path);
                return new Bitmap(temp); // copy để không khóa file gốc
            }
            catch
            {
                return null;
            }
        }

        private void SetPicture(Image? image)
        {
            picSanPham.Image?.Dispose();
            picSanPham.Image = image;
        }

        private void LoadProductToForm(Product p)
        {
            txtMaSP.Text = p.MaSP;
            txtMaSP.ReadOnly = true; // không cho sửa mã
            txtTenSP.Text = p.TenSP;
            cboLoaiSP.Text = p.LoaiSP;
            numDonGia.Value = Math.Min(p.DonGia, numDonGia.Maximum);
            numSoLuong.Value = Math.Min(p.SoLuong, numSoLuong.Maximum);
            dtpNgayNhap.Value = p.NgayNhap;
            chkConKinhDoanh.Checked = p.ConKinhDoanh;
            selectedImagePath = p.DuongDanAnh;

            if (!string.IsNullOrWhiteSpace(p.DuongDanAnh) && File.Exists(p.DuongDanAnh))
                SetPicture(LoadImageCopy(p.DuongDanAnh));
            else
                SetPicture(null);
        }

        private void ClearInput()
        {
            txtMaSP.Clear();
            txtMaSP.ReadOnly = false;
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 1;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Today;
            chkConKinhDoanh.Checked = true;
            txtTimKiem.Clear();
            SetPicture(null);
            selectedImagePath = string.Empty;
            errorProvider1.Clear();
            txtMaSP.Focus();
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = $"{message} | Số sản phẩm: {products.Count}";
        }

        // ===== CRUD =====
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Product p = new Product
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                LoaiSP = cboLoaiSP.Text,
                DonGia = numDonGia.Value,
                SoLuong = (int)numSoLuong.Value,
                NgayNhap = dtpNgayNhap.Value.Date,
                ConKinhDoanh = chkConKinhDoanh.Checked,
                DuongDanAnh = selectedImagePath
            };

            products.Add(p);
            ShowAll();
            ClearInput();
            UpdateStatus("Đã thêm sản phẩm mới");
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            Product? p = GetSelectedProduct();
            if (p == null) return;

            // Mã SP không đổi khi sửa -> lấy lại mã của sản phẩm đang chọn
            txtMaSP.Text = p.MaSP;
            if (!ValidateInput(isEdit: true)) return;

            p.TenSP = txtTenSP.Text.Trim();
            p.LoaiSP = cboLoaiSP.Text;
            p.DonGia = numDonGia.Value;
            p.SoLuong = (int)numSoLuong.Value;
            p.NgayNhap = dtpNgayNhap.Value.Date;
            p.ConKinhDoanh = chkConKinhDoanh.Checked;
            p.DuongDanAnh = selectedImagePath;

            ShowAll();
            UpdateStatus("Đã cập nhật sản phẩm");
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            Product? p = GetSelectedProduct();
            if (p == null) return;

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm {p.TenSP}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                products.Remove(p);
                ShowAll();
                ClearInput();
                UpdateStatus("Đã xóa sản phẩm");
            }
        }

        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            List<Product> result = products
                .Where(p => p.MaSP.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                         || p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            BindGrid(result);
            lblStatus.Text = $"Tìm thấy {result.Count} sản phẩm | Số sản phẩm: {products.Count}";
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearInput();
            ShowAll();
            UpdateStatus("Đã làm mới dữ liệu");
        }

        // ===== Chọn ảnh =====
        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Chọn ảnh sản phẩm";
            dialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            Image? img = LoadImageCopy(dialog.FileName);
            if (img == null)
            {
                MessageBox.Show("File được chọn không phải ảnh hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedImagePath = dialog.FileName;
            SetPicture(img);
            UpdateStatus("Đã chọn ảnh sản phẩm");
        }

        // ===== DataGridView =====
        private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProducts.Rows[e.RowIndex].DataBoundItem is Product p)
            {
                errorProvider1.Clear();
                LoadProductToForm(p);
            }
        }

        // Chuột phải: chọn dòng trước khi hiện context menu
        private void dgvProducts_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;

            dgvProducts.ClearSelection();
            dgvProducts.Rows[e.RowIndex].Selected = true;
            dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[0];

            if (dgvProducts.Rows[e.RowIndex].DataBoundItem is Product p)
                LoadProductToForm(p);
        }

        private void dgvProducts_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                btnXoa.PerformClick();
            }
        }

        // ===== Menu / Toolbar / Context menu (gọi lại nút chính) =====
        private void mnuFileExit_Click(object? sender, EventArgs e) => Close();
        private void mnuThem_Click(object? sender, EventArgs e) => btnThem.PerformClick();
        private void mnuSua_Click(object? sender, EventArgs e) => btnSua.PerformClick();
        private void mnuXoa_Click(object? sender, EventArgs e) => btnXoa.PerformClick();
        private void mnuLamMoi_Click(object? sender, EventArgs e) => btnLamMoi.PerformClick();

        private void mnuAbout_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("ProductManager - Lab 06\nCOMP1019 - Lập trình trên Windows",
                "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbThem_Click(object? sender, EventArgs e) => btnThem.PerformClick();
        private void tsbSua_Click(object? sender, EventArgs e) => btnSua.PerformClick();
        private void tsbXoa_Click(object? sender, EventArgs e) => btnXoa.PerformClick();
        private void tsbLamMoi_Click(object? sender, EventArgs e) => btnLamMoi.PerformClick();
        private void tsbTimKiem_Click(object? sender, EventArgs e) => btnTimKiem.PerformClick();

        private void cmsSua_Click(object? sender, EventArgs e) => btnSua.PerformClick();
        private void cmsXoa_Click(object? sender, EventArgs e) => btnXoa.PerformClick();

        private void cmsChiTiet_Click(object? sender, EventArgs e)
        {
            Product? p = GetSelectedProduct();
            if (p == null) return;

            MessageBox.Show(
                $"Mã: {p.MaSP}\nTên: {p.TenSP}\nLoại: {p.LoaiSP}\nĐơn giá: {p.DonGia:N0}\n" +
                $"Số lượng: {p.SoLuong}\nNgày nhập: {p.NgayNhap:dd/MM/yyyy}\n" +
                $"Còn kinh doanh: {(p.ConKinhDoanh ? "Có" : "Không")}\nThành tiền: {p.ThanhTien:N0}",
                "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
