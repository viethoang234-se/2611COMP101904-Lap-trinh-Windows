using System;
using System.Collections.Generic;
using System.Linq;

namespace BTLOP_QuanLyNhanVien
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }

        private double luongCoBan;
        public double LuongCoBan
        {
            get => luongCoBan;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Lương cơ bản phải lớn hơn 0.");
                luongCoBan = value;
            }
        }

        public NhanVien(string maNhanVien, string hoTen, double luongCoBan)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"{MaNhanVien,-8}{HoTen,-25}{GetType().Name,-20}{TinhLuong(),15:N0}");
        }
    }

    public class NhanVienVanPhong : NhanVien
    {
        private int soNgayLamViec;
        public int SoNgayLamViec
        {
            get => soNgayLamViec;
            set
            {
                if (value < 0 || value > 31)
                    throw new ArgumentException("Số ngày làm việc phải trong khoảng 0 đến 31.");
                soNgayLamViec = value;
            }
        }

        public NhanVienVanPhong(string maNhanVien, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNhanVien, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + SoNgayLamViec * 200000;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"{MaNhanVien,-8}{HoTen,-25}{"NV Van Phong",-20}{TinhLuong(),15:N0}");
        }
    }

    public class NhanVienKinhDoanh : NhanVien
    {
        private double doanhSo;
        public double DoanhSo
        {
            get => doanhSo;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Doanh số phải lớn hơn hoặc bằng 0.");
                doanhSo = value;
            }
        }

        public NhanVienKinhDoanh(string maNhanVien, string hoTen, double luongCoBan, double doanhSo)
            : base(maNhanVien, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + 0.05 * DoanhSo;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"{MaNhanVien,-8}{HoTen,-25}{"NV Kinh Doanh",-20}{TinhLuong(),15:N0}");
        }
    }

    public class NhanVienThoiVu : NhanVien
    {
        private int soGioLam;
        public int SoGioLam
        {
            get => soGioLam;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số giờ làm phải lớn hơn hoặc bằng 0.");
                soGioLam = value;
            }
        }

        private double luongTheoGio;
        public double LuongTheoGio
        {
            get => luongTheoGio;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Lương theo giờ phải lớn hơn hoặc bằng 0.");
                luongTheoGio = value;
            }
        }

        public NhanVienThoiVu(string maNhanVien, string hoTen, double luongCoBan, int soGioLam, double luongTheoGio)
            : base(maNhanVien, hoTen, luongCoBan)
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"{MaNhanVien,-8}{HoTen,-25}{"NV Thoi Vu",-20}{TinhLuong(),15:N0}");
        }
    }

    public class Program
    {
        private static List<NhanVien> danhSach = new List<NhanVien>();

        public static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Nhập thông tin nhân viên (ít nhất 5 người, chọn loại 1-3):");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"\n--- Nhân viên thứ {i} ---");
                NhapNhanVien();
            }

            bool tiepTuc = true;
            while (tiepTuc)
            {
                HienThiMenu();
                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1": XuatDanhSach(); break;
                    case "2": TimTheoMa(); break;
                    case "3": TimLuongCaoNhat(); break;
                    case "4": TinhTongLuong(); break;
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
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("1. Xuat danh sach nhan vien");
            Console.WriteLine("2. Tim nhan vien theo ma");
            Console.WriteLine("3. Tim nhan vien co luong cao nhat");
            Console.WriteLine("4. Tinh tong luong cong ty phai tra");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon chuc nang: ");
        }

        private static void NhapNhanVien()
        {
            Console.Write("Nhập mã nhân viên: ");
            string ma = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            string hoTen = Console.ReadLine();

            double luongCoBan = NhapSoThuc("Nhập lương cơ bản (> 0): ", v => v > 0);

            Console.WriteLine("Loại nhân viên: 1. Văn phòng | 2. Kinh doanh | 3. Thời vụ");
            string loai = Console.ReadLine();

            try
            {
                NhanVien nv;
                switch (loai)
                {
                    case "1":
                        int soNgay = NhapSoNguyen("Nhập số ngày làm việc (0-31): ", v => v >= 0 && v <= 31);
                        nv = new NhanVienVanPhong(ma, hoTen, luongCoBan, soNgay);
                        break;
                    case "2":
                        double doanhSo = NhapSoThuc("Nhập doanh số (>= 0): ", v => v >= 0);
                        nv = new NhanVienKinhDoanh(ma, hoTen, luongCoBan, doanhSo);
                        break;
                    case "3":
                        int soGio = NhapSoNguyen("Nhập số giờ làm (>= 0): ", v => v >= 0);
                        double luongTheoGio = NhapSoThuc("Nhập lương theo giờ (>= 0): ", v => v >= 0);
                        nv = new NhanVienThoiVu(ma, hoTen, luongCoBan, soGio, luongTheoGio);
                        break;
                    default:
                        Console.WriteLine("Loại nhân viên không hợp lệ, mặc định là Văn phòng với 0 ngày làm.");
                        nv = new NhanVienVanPhong(ma, hoTen, luongCoBan, 0);
                        break;
                }

                danhSach.Add(nv);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message + " Nhân viên không được thêm.");
            }
        }

        private static void XuatDanhSach()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            Console.WriteLine($"{"Mã NV",-8}{"Họ tên",-25}{"Loại",-20}{"Lương",15}");
            Console.WriteLine(new string('-', 68));
            foreach (var nv in danhSach)
                nv.HienThiThongTin();
        }

        private static void TimTheoMa()
        {
            Console.Write("Nhập mã nhân viên cần tìm: ");
            string ma = Console.ReadLine();

            var nv = danhSach.FirstOrDefault(x => x.MaNhanVien.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (nv == null)
                Console.WriteLine("Không tìm thấy nhân viên.");
            else
                nv.HienThiThongTin();
        }

        private static void TimLuongCaoNhat()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            var nv = danhSach.OrderByDescending(x => x.TinhLuong()).First();
            Console.WriteLine("Nhân viên có lương cao nhất:");
            nv.HienThiThongTin();
        }

        private static void TinhTongLuong()
        {
            double tong = danhSach.Sum(x => x.TinhLuong());
            Console.WriteLine($"Tổng lương công ty phải trả: {tong:N0}");
        }

        private static double NhapSoThuc(string thongBao, Func<double, bool> hopLe)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double kq) && hopLe(kq))
                    return kq;

                Console.WriteLine("Giá trị không hợp lệ, vui lòng nhập lại.");
            }
        }

        private static int NhapSoNguyen(string thongBao, Func<int, bool> hopLe)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int kq) && hopLe(kq))
                    return kq;

                Console.WriteLine("Giá trị không hợp lệ, vui lòng nhập lại.");
            }
        }
    }
}