using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab03_QuanLySinhVienOOP
{
    public class Program
    {
        private static QuanLySinhVien quanLy = new QuanLySinhVien();

        public static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool tiepTuc = true;

            while (tiepTuc)
            {
                HienThiMenu();
                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1": ThemSinhVien(); break;
                    case "2": XuatDanhSach(quanLy.LayDanhSach()); break;
                    case "3": TimTheoMa(); break;
                    case "4": TimTheoTen(); break;
                    case "5": SuaDiem(); break;
                    case "6": XoaSinhVien(); break;
                    case "7": XuatDanhSach(quanLy.SapXepTheoDiem()); break;
                    case "8": XuatDanhSach(quanLy.LocSinhVienDat()); break;
                    case "0":
                        tiepTuc = false;
                        Console.WriteLine("Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }

                if (tiepTuc)
                {
                    Console.WriteLine("\nNhấn Enter để tiếp tục...");
                    Console.ReadLine();
                }
            }
        }

        private static void HienThiMenu()
        {
            Console.Clear();
            Console.WriteLine("===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim sinh vien theo ten");
            Console.WriteLine("5. Sua diem trung binh");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo diem giam dan");
            Console.WriteLine("8. Loc sinh vien dat");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon chuc nang: ");
        }

        private static void ThemSinhVien()
        {
            Console.Write("Nhập mã sinh viên: ");
            string ma = Console.ReadLine();

            if (quanLy.TimTheoMa(ma) != null)
            {
                Console.WriteLine("Mã sinh viên đã tồn tại!");
                return;
            }

            Console.Write("Nhập họ tên: ");
            string hoTen = Console.ReadLine();

            DateTime ngaySinh = NhapNgay("Nhập ngày sinh (dd/MM/yyyy): ");

            Console.Write("Nhập mã lớp: ");
            string maLop = Console.ReadLine();

            double diem = NhapDiem("Nhập điểm trung bình (0-10): ");

            try
            {
                var sv = new SinhVien(ma, hoTen, ngaySinh, maLop, diem);
                if (quanLy.Them(sv))
                    Console.WriteLine("Thêm sinh viên thành công!");
                else
                    Console.WriteLine("Mã sinh viên đã tồn tại!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        private static void XuatDanhSach(List<SinhVien> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            Console.WriteLine($"{"Mã SV",-8}{"Họ tên",-25}{"Lớp",-10}{"Điểm",-8}{"Xếp loại",-10}");
            Console.WriteLine(new string('-', 61));
            foreach (var sv in danhSach)
                Console.WriteLine(sv.LayThongTin());
        }

        private static void TimTheoMa()
        {
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string ma = Console.ReadLine();
            var sv = quanLy.TimTheoMa(ma);

            if (sv == null)
                Console.WriteLine("Không tìm thấy sinh viên.");
            else
                XuatDanhSach(new List<SinhVien> { sv });
        }

        private static void TimTheoTen()
        {
            Console.Write("Nhập từ khóa họ tên: ");
            string tuKhoa = Console.ReadLine();
            var ketQua = quanLy.TimTheoTen(tuKhoa);
            XuatDanhSach(ketQua);
        }

        private static void SuaDiem()
        {
            Console.Write("Nhập mã sinh viên cần sửa điểm: ");
            string ma = Console.ReadLine();

            if (quanLy.TimTheoMa(ma) == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }

            double diemMoi = NhapDiem("Nhập điểm trung bình mới (0-10): ");

            try
            {
                quanLy.Sua(ma, diemMoi);
                Console.WriteLine("Cập nhật điểm thành công!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        private static void XoaSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string ma = Console.ReadLine();

            if (quanLy.Xoa(ma))
                Console.WriteLine("Xóa thành công!");
            else
                Console.WriteLine("Không tìm thấy sinh viên.");
        }

        private static double NhapDiem(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double diem) && diem >= 0 && diem <= 10)
                    return diem;

                Console.WriteLine("Điểm không hợp lệ, vui lòng nhập lại (0-10).");
            }
        }

        private static DateTime NhapNgay(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngay))
                    return ngay;

                Console.WriteLine("Ngày sinh không hợp lệ, vui lòng nhập lại (dd/MM/yyyy).");
            }
        }
    }
}