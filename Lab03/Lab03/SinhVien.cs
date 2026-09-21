using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        private double diemTrungBinh;
        public double DiemTrungBinh
        {
            get => diemTrungBinh;
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException(nameof(value), "Điểm trung bình phải nằm trong khoảng 0 - 10.");
                diemTrungBinh = value;
            }
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.0) return "Giỏi";
            if (DiemTrungBinh >= 6.5) return "Khá";
            if (DiemTrungBinh >= 5.0) return "Trung bình";
            return "Yếu";
        }

        public override string LayThongTin()
        {
            return $"{MaSinhVien,-8}{HoTen,-25}{MaLop,-10}{DiemTrungBinh,-8:0.0}{XepLoai(),-10}";
        }
    }
}
