namespace CourseRegistrationApp
{
    public partial class frmDangKyKhoaHoc : Form
    {
        public frmDangKyKhoaHoc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoaHoc.Items.Clear();
            cboKhoaHoc.Items.Add("C# WinForms cơ bản");
            cboKhoaHoc.Items.Add("SQL Server cơ bản");
            cboKhoaHoc.Items.Add("Web Frontend cơ bản");
            cboKhoaHoc.Items.Add("Lập trình Python cơ bản");
            cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;

            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1;

            lblCount.Text = "0/50";
            dtpNgaySinh.MaxDate = DateTime.Today;

            chkNhanEmail.Checked = false;
            lblEmailStatus.Text = "(Chưa đăng ký nhận email!)";

            CapNhatHocPhi();
            txtHoTen.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNhanEmail.Checked)
            {
                lblEmailStatus.Text = "(Đã đăng ký nhận email!)";
            }
            else
            {
                lblEmailStatus.Text = "(Chưa đăng ký nhận email!)";
            }
        }

        private void cbKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatHocPhi();
        }

        private decimal LayHocPhiCoBan()
        {
            switch (cboKhoaHoc.SelectedItem?.ToString())
            {
                case "C# WinForms cơ bản": return 800000;
                case "SQL Server cơ bản": return 700000;
                case "Web Frontend cơ bản": return 750000;
                case "Lập trình Python cơ bản": return 650000;
                default: return 0;
            }
        }

        private decimal LayHocPhiHinhThuc()
        {
            if (radOffline.Checked)
                return 100000;
            return 0;
        }

        private void CapNhatHocPhi()
        {
            decimal hocPhiMotThang = LayHocPhiCoBan() + LayHocPhiHinhThuc();
            decimal soThang = numSoThang.Value;
            decimal tongTien = hocPhiMotThang * soThang;

            lblHienThiHocPhi.Text = hocPhiMotThang.ToString("N0") + " VNĐ";
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            lblCount.Text = txtHoTen.Text.Length + "/50";
        }

        private void rbOnline_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHocPhi();
        }

        private void rbOffline_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHocPhi();
        }

        private void numThang_ValueChanged_1(object sender, EventArgs e)
        {
            CapNhatHocPhi();
        }


        private bool SoDienThoaiHopLe(string sdt)
        {
            // 10 digits, starts with 0
            return System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^0\d{9}$");
        }

        private bool KiemTraDuLieu()
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên!",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            string soDienThoai = txtSoDienThoai.Text.Trim();
            if (!SoDienThoaiHopLe(soDienThoai))
            {
                MessageBox.Show(
                    "Vui lòng nhập số điện thoại hợp lệ!",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }

            if (cboKhoaHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return false;
            }

            return true;
        }

        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string hinhThuc = radOnline.Checked ? "Online" : "Offline";
            string email = chkNhanEmail.Checked ? "Có" : "Không";

            string thongTin = $"Họ tên: {txtHoTen.Text.Trim()}\n" +
                              $"Ngày sinh: {dtpNgaySinh.Value.ToShortDateString()}\n" +
                              $"Số điện thoại: {txtSoDienThoai.Text.Trim()}\n" +
                              $"Khóa học: {cboKhoaHoc.SelectedItem}\n" +
                              $"Hình thức: {hinhThuc}\n" +
                              $"Số tháng học: {numSoThang.Value}\n" +
                              $"Đăng ký nhận email: {email}\n" +
                              $"Tổng tiền: {lblTongTien.Text}";

            MessageBox.Show(thongTin, "Đăng ký thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            cboKhoaHoc.SelectedIndex = 0;
            radOnline.Checked = true;
            numSoThang.Value = 1;
            chkNhanEmail.Checked = false;
            lblCount.Text = "0/50";
            CapNhatHocPhi();
            txtHoTen.Focus();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show(
                "Bạn có chắc muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
                this.Close();
        }
    }
}
