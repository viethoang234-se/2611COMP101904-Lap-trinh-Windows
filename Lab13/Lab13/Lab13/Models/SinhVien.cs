namespace StudentReportDemo.Models
{
    public class SinhVien
    {
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string MaLop { get; set; } = string.Empty;
        public string TenLop { get; set; } = string.Empty;
        public double Diem { get; set; }

        // Tính từ Diem nên không cần lưu riêng, tránh sai lệch dữ liệu
        public string KetQua => Diem >= 5 ? "Đạt" : "Không đạt";
    }

    /// <summary>Một mục trong ComboBox chọn lớp (MaLop rỗng = tất cả các lớp).</summary>
    public record LopItem(string MaLop, string TenLop);
}
