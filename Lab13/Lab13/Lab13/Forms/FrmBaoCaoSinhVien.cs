using StudentReportDemo.Models;
using System.Text;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoSinhVien_Load(object? sender, EventArgs e)
        {
            TaoDuLieuMau();
            LoadComboBox();

            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.MultiSelect = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            XemBaoCao(hienThongBao: false);
        }

        // ===== Dữ liệu mẫu: 12 sinh viên, 3 lớp =====
        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2 },
                new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5 },
                new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8 },
                new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung",  MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1 },
                new SinhVien { MaSV = "SV005", HoTen = "Hoàng Quốc Huy",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },
                new SinhVien { MaSV = "SV006", HoTen = "Võ Gia Khang",     MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9 },
                new SinhVien { MaSV = "SV007", HoTen = "Đặng Minh Khôi",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5 },
                new SinhVien { MaSV = "SV008", HoTen = "Bùi Thảo Linh",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0 },
                new SinhVien { MaSV = "SV009", HoTen = "Ngô Tuấn Minh",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
                new SinhVien { MaSV = "SV010", HoTen = "Đỗ Bảo Ngọc",      MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3 },
                new SinhVien { MaSV = "SV011", HoTen = "Huỳnh Gia Phúc",   MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2 },
                new SinhVien { MaSV = "SV012", HoTen = "Mai Anh Thư",     MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8 }
            };
        }

        // ===== ComboBox =====
        private void LoadComboBox()
        {
            List<LopItem> dsLop = danhSachSinhVien
                .Select(sv => new LopItem(sv.MaLop, sv.TenLop))
                .Distinct()
                .OrderBy(lop => lop.MaLop)
                .ToList();

            dsLop.Insert(0, new LopItem(string.Empty, "Tất cả các lớp"));

            cboLop.DataSource = dsLop;
            cboLop.DisplayMember = nameof(LopItem.TenLop);
            cboLop.ValueMember = nameof(LopItem.MaLop);

            cboKetQua.Items.Clear();
            cboKetQua.Items.AddRange(new object[] { "Tất cả", "Đạt", "Không đạt" });
            cboKetQua.SelectedIndex = 0;
        }

        // ===== Xem báo cáo (lọc + sắp xếp bằng LINQ) =====
        private void XemBaoCao(bool hienThongBao = true)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? string.Empty;
            string ketQua = cboKetQua.SelectedItem?.ToString() ?? "Tất cả";
            string tuKhoa = txtTuKhoa.Text.Trim();

            IEnumerable<SinhVien> query = danhSachSinhVien;

            if (maLop.Length > 0)
                query = query.Where(sv => sv.MaLop == maLop);

            if (ketQua == "Đạt")
                query = query.Where(sv => sv.Diem >= 5);
            else if (ketQua == "Không đạt")
                query = query.Where(sv => sv.Diem < 5);

            if (tuKhoa.Length > 0)
            {
                query = query.Where(sv =>
                    sv.MaSV.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) ||
                    sv.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase));
            }

            List<SinhVien> ketQuaLoc = query
                .OrderByDescending(sv => sv.Diem)
                .ThenBy(sv => sv.HoTen)
                .ToList();

            dgvBaoCao.DataSource = ketQuaLoc
                .Select(sv => new { sv.MaSV, sv.HoTen, sv.TenLop, sv.Diem, sv.KetQua })
                .ToList();

            DatTieuDeCot("MaSV", "Mã SV", "HoTen", "Họ tên", "TenLop", "Lớp", "Diem", "Điểm", "KetQua", "Kết quả");
            DatDinhDang("Diem", "0.0");

            CapNhatThongKe(ketQuaLoc);

            if (ketQuaLoc.Count == 0 && hienThongBao)
            {
                MessageBox.Show("Không có dữ liệu phù hợp với điều kiện đã chọn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ===== Thống kê hiển thị trên StatusStrip =====
        private void CapNhatThongKe(List<SinhVien> ds)
        {
            int tong = ds.Count;
            int soDat = ds.Count(sv => sv.Diem >= 5);
            int soKhongDat = ds.Count(sv => sv.Diem < 5);
            double diemTB = tong > 0 ? ds.Average(sv => sv.Diem) : 0; // tránh lỗi Average trên danh sách rỗng

            lblThongKe.Text = $"Tổng: {tong} | Đạt: {soDat} | Không đạt: {soKhongDat} | ĐTB: {diemTB:0.00}";
        }

        // ===== Thống kê theo lớp (GroupBy) =====
        private void btnThongKe_Click(object? sender, EventArgs e)
        {
            var thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new
                {
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat = g.Count(sv => sv.Diem >= 5),
                    SoKhongDat = g.Count(sv => sv.Diem < 5),
                    DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2)
                })
                .OrderBy(x => x.MaLop)
                .ToList();

            dgvBaoCao.DataSource = thongKe;

            DatTieuDeCot("MaLop", "Mã lớp", "TenLop", "Tên lớp", "SoLuong", "Số lượng",
                         "SoDat", "Số đạt", "SoKhongDat", "Số không đạt", "DiemTrungBinh", "Điểm TB");
            DatDinhDang("DiemTrungBinh", "0.00");

            CapNhatThongKe(danhSachSinhVien);
            lblThongKe.Text = "Thống kê theo lớp | " + lblThongKe.Text;
        }

        // ===== Xuất file CSV / TXT =====
        private void XuatFile()
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt";
            sfd.FileName = "BaoCaoSinhVien.csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                bool laCsv = Path.GetExtension(sfd.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase);
                string phanCach = laCsv ? "," : "\t";

                List<DataGridViewColumn> cot = dgvBaoCao.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .ToList();

                List<string> dong = new List<string>();
                dong.Add(string.Join(phanCach, cot.Select(c => LamSachO(c.HeaderText, laCsv))));

                dong.AddRange(dgvBaoCao.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => string.Join(phanCach,
                        cot.Select(c => LamSachO(Convert.ToString(r.Cells[c.Index].FormattedValue) ?? "", laCsv)))));

                // UTF-8 có BOM để Excel đọc đúng tiếng Việt
                File.WriteAllLines(sfd.FileName, dong, new UTF8Encoding(true));

                MessageBox.Show("Xuất file thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CSV: ô chứa dấu phẩy, dấu nháy hoặc xuống dòng phải đặt trong dấu "..."
        private static string LamSachO(string giaTri, bool laCsv)
        {
            if (!laCsv) return giaTri.Replace('\t', ' ');

            if (giaTri.Contains(',') || giaTri.Contains('"') || giaTri.Contains('\n'))
                return "\"" + giaTri.Replace("\"", "\"\"") + "\"";

            return giaTri;
        }

        // ===== Hàm phụ cho DataGridView =====
        private void DatTieuDeCot(params string[] capTenVaTieuDe)
        {
            for (int i = 0; i + 1 < capTenVaTieuDe.Length; i += 2)
            {
                DataGridViewColumn? cot = dgvBaoCao.Columns[capTenVaTieuDe[i]];
                if (cot != null) cot.HeaderText = capTenVaTieuDe[i + 1];
            }
        }

        private void DatDinhDang(string tenCot, string dinhDang)
        {
            DataGridViewColumn? cot = dgvBaoCao.Columns[tenCot];
            if (cot != null) cot.DefaultCellStyle.Format = dinhDang;
        }

        // ===== Sự kiện nút =====
        private void btnXemBaoCao_Click(object? sender, EventArgs e) => XemBaoCao();
        private void btnXuatFile_Click(object? sender, EventArgs e) => XuatFile();
    }
}
