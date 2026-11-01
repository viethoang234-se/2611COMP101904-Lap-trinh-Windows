using System.Data;
using System.Globalization;
using System.Text;
using Lab12.DAL;

namespace Lab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        // Tên các cột trong DataGridView
        private const string ColMaSV = "colMaSV";
        private const string ColHoTen = "colHoTen";
        private const string ColDiem = "colDiem";
        private const string ColGhiChu = "colGhiChu";

        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
        private readonly BindingSource ketQuaSource = new BindingSource();

        // Môn học của danh sách đang hiển thị (không lấy từ ComboBox vì người dùng có thể đổi sau khi tải)
        private string maMonDangTai = string.Empty;

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
            CauHinhLuoi();
        }

        // ================= Load Form =================

        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBox();
                CapNhatTrangThai("Sẵn sàng. Chọn lớp, môn học rồi bấm Tải danh sách.");
            }
            catch (Exception ex)
            {
                btnTaiDanhSach.Enabled = false;
                CapNhatTrangThai("Không kết nối được database.");
                MessageBox.Show("Không thể kết nối database QLSinhVienLab12:\n" + ex.Message +
                                "\n\nKiểm tra SQL Server đã chạy, đã chạy script SQL và chuỗi kết nối trong Database.cs.",
                                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Binding danh sách lớp và môn học vào hai ComboBox.</summary>
        private void LoadComboBox()
        {
            // Đặt DisplayMember/ValueMember TRƯỚC khi gán DataSource để tránh hiện "System.Data.DataRowView"
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = ketQuaDAL.GetLop();

            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "MaMon";
            cboMonHoc.DataSource = ketQuaDAL.GetMonHoc();
        }

        /// <summary>Tạo các cột của DataGridView và gắn BindingSource.</summary>
        private void CauHinhLuoi()
        {
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.RowHeadersWidth = 30;

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColMaSV, DataPropertyName = "MaSV", HeaderText = "Mã SV",
                ReadOnly = true, Width = 120, SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColHoTen, DataPropertyName = "HoTen", HeaderText = "Họ tên",
                ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 40,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColDiem, DataPropertyName = "Diem", HeaderText = "Điểm",
                Width = 110, SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "0.0#",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColGhiChu, DataPropertyName = "GhiChu", HeaderText = "Ghi chú",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 40,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });

            dgvKetQua.DataSource = ketQuaSource;
        }

        // ================= Tải danh sách =================

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null || cboMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLop = cboLop.SelectedValue.ToString();
            string maMon = cboMonHoc.SelectedValue.ToString();

            try
            {
                DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);
                ketQuaSource.DataSource = table;
                maMonDangTai = maMon;

                btnLuuTatCa.Enabled = table.Rows.Count > 0;
                CapNhatThongKe();

                if (table.Rows.Count == 0)
                    CapNhatTrangThai("Lớp này chưa có sinh viên nào.");
                else
                    CapNhatTrangThai($"Đã tải {table.Rows.Count} sinh viên của lớp {cboLop.Text} - môn {cboMonHoc.Text}.");
            }
            catch (Exception ex)
            {
                CapNhatTrangThai("Tải danh sách thất bại.");
                MessageBox.Show("Không thể tải danh sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= Lưu tất cả =================

        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            // Đẩy giá trị đang gõ dở trong ô về DataTable; false nghĩa là ô đang nhập sai
            if (!dgvKetQua.EndEdit()) return;
            ketQuaSource.EndEdit();

            if (ketQuaSource.DataSource is not DataTable table || table.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có danh sách để lưu. Hãy tải danh sách trước.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<string> errors = KiemTraDuLieu();
            if (errors.Count > 0)
            {
                CapNhatTrangThai("Lưu thất bại: dữ liệu không hợp lệ.");
                MessageBox.Show(TaoThongBaoLoi(errors), "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int count = ketQuaDAL.SaveAll(maMonDangTai, table);
                table.AcceptChanges();
                CapNhatThongKe();
                CapNhatTrangThai($"Đã lưu thành công {count} dòng.");
                MessageBox.Show($"Đã lưu thành công {count} dòng.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                CapNhatTrangThai("Lưu thất bại, đã hoàn tác (rollback) toàn bộ.");
                MessageBox.Show("Lưu thất bại, toàn bộ thao tác đã được hoàn tác (rollback).\n\nChi tiết: " + ex.Message,
                    "Lỗi khi lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= Validation =================

        /// <summary>
        /// Kiểm tra từng dòng trên lưới: điểm không rỗng, là số, nằm trong 0..10; ghi chú không quá 255 ký tự.
        /// Dòng lỗi được đánh dấu bằng biểu tượng lỗi ở đầu dòng.
        /// </summary>
        private List<string> KiemTraDuLieu()
        {
            List<string> errors = new List<string>();

            foreach (DataGridViewRow row in dgvKetQua.Rows)
            {
                row.ErrorText = string.Empty;

                string maSV = Convert.ToString(row.Cells[ColMaSV].Value);
                string loi = KiemTraDiem(row.Cells[ColDiem].Value);

                if (loi == null && Convert.ToString(row.Cells[ColGhiChu].Value)?.Length > 255)
                    loi = "ghi chú không được quá 255 ký tự";

                if (loi != null)
                {
                    row.ErrorText = loi;
                    errors.Add($"Sinh viên {maSV}: {loi}.");
                }
            }

            return errors;
        }

        /// <summary>Trả về mô tả lỗi, hoặc null nếu điểm hợp lệ.</summary>
        private static string KiemTraDiem(object value)
        {
            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(Convert.ToString(value)))
                return "chưa nhập điểm";

            if (!TryLayDiem(value, out decimal diem))
                return "điểm phải là số";

            if (diem < 0 || diem > 10)
                return "điểm phải nằm trong khoảng 0 đến 10";

            return null;
        }

        private static bool TryLayDiem(object value, out decimal diem)
        {
            diem = 0;
            if (value == null || value == DBNull.Value) return false;
            if (value is decimal d) { diem = d; return true; }

            return decimal.TryParse(Convert.ToString(value), NumberStyles.Number,
                CultureInfo.CurrentCulture, out diem);
        }

        private static string TaoThongBaoLoi(List<string> errors)
        {
            const int toiDa = 6;
            StringBuilder sb = new StringBuilder("Không thể lưu vì có dữ liệu chưa hợp lệ:\n\n");

            foreach (string loi in errors.Take(toiDa))
                sb.AppendLine("- " + loi);

            if (errors.Count > toiDa)
                sb.AppendLine($"... và {errors.Count - toiDa} lỗi khác.");

            return sb.ToString();
        }

        // ================= Sự kiện DataGridView =================

        /// <summary>Gõ chữ vào ô điểm (không phải số) sẽ phát sinh DataError; báo lỗi thân thiện thay vì crash.</summary>
        private void dgvKetQua_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true; // giữ con trỏ ở ô lỗi, nhấn Esc để hoàn tác

            string thongBao = dgvKetQua.Columns[e.ColumnIndex].Name == ColDiem
                ? "Điểm phải là số trong khoảng 0 đến 10 (nhấn Esc để hoàn tác)."
                : "Dữ liệu nhập không hợp lệ (nhấn Esc để hoàn tác).";

            MessageBox.Show(thongBao, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvKetQua_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvKetQua.Rows[e.RowIndex].ErrorText = string.Empty;
            CapNhatThongKe();
        }

        // ================= Trạng thái & thống kê =================

        private void CapNhatTrangThai(string noiDung)
        {
            lblStatus.Text = noiDung;
        }

        /// <summary>Thống kê nhanh trên lưới: số sinh viên, số đã nhập điểm, số đạt (>= 5), điểm trung bình.</summary>
        private void CapNhatThongKe()
        {
            int tong = 0, daNhap = 0, dat = 0;
            decimal tongDiem = 0;

            foreach (DataGridViewRow row in dgvKetQua.Rows)
            {
                tong++;
                if (TryLayDiem(row.Cells[ColDiem].Value, out decimal diem))
                {
                    daNhap++;
                    tongDiem += diem;
                    if (diem >= 5) dat++;
                }
            }

            decimal diemTB = daNhap > 0 ? tongDiem / daNhap : 0;
            lblThongKe.Text = $"Sinh viên: {tong} | Đã nhập: {daNhap} | Đạt: {dat} | ĐTB: {diemTB:0.00}";
        }
    }
}
