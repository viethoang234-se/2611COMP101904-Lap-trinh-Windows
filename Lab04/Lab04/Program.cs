using System;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_QuanLySanPham
{
    public class Program
    {
        private static ProductService service = new ProductService(new Repository<Product>());

        public static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            service.ProductAdded += p => Console.WriteLine($"[Event] Đã thêm sản phẩm \"{p.TenSP}\" (mã {p.MaSP}).");
            service.ProductRemoved += p => Console.WriteLine($"[Event] Đã xóa sản phẩm \"{p.TenSP}\" (mã {p.MaSP}).");

            bool tiepTuc = true;
            while (tiepTuc)
            {
                HienThiMenu();
                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1": ThemSanPham(); break;
                    case "2": XuatDanhSach(service.GetAll()); break;
                    case "3": TimTheoMa(); break;
                    case "4": TimTheoTen(); break;
                    case "5": LocTheoKhoangGia(); break;
                    case "6": XoaSanPham(); break;
                    case "7": TinhTongGiaTriKho(); break;
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
            Console.WriteLine("===== QUẢN LÝ SẢN PHẨM =====");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Xuất danh sách");
            Console.WriteLine("3. Tìm theo mã");
            Console.WriteLine("4. Tìm theo tên");
            Console.WriteLine("5. Lọc theo khoảng giá");
            Console.WriteLine("6. Xóa sản phẩm");
            Console.WriteLine("7. Tính tổng giá trị kho");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
        }

        private static void ThemSanPham()
        {
            Console.Write("Nhập mã sản phẩm: ");
            string ma = Console.ReadLine();

            Console.Write("Nhập tên sản phẩm: ");
            string ten = Console.ReadLine();

            double gia = NhapSoThuc("Nhập đơn giá (>= 0): ", v => v >= 0);
            int soLuong = NhapSoNguyen("Nhập số lượng (>= 0): ", v => v >= 0);

            try
            {
                service.AddProduct(new Product(ma, ten, gia, soLuong));
                Console.WriteLine("Thêm sản phẩm thành công!");
            }
            catch (DuplicateProductException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        private static void XuatDanhSach(List<Product> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách sản phẩm trống.");
                return;
            }

            Console.WriteLine($"{"Mã SP",-8}{"Tên sản phẩm",-25}{"Đơn giá",-15}{"Số lượng",-10}");
            Console.WriteLine(new string('-', 58));
            foreach (var sp in danhSach)
                Console.WriteLine(sp);
        }

        private static void TimTheoMa()
        {
            Console.Write("Nhập mã sản phẩm cần tìm: ");
            string ma = Console.ReadLine();
            var sp = service.TimTheoMa(ma);

            if (sp == null)
                Console.WriteLine("Không tìm thấy sản phẩm.");
            else
                XuatDanhSach(new List<Product> { sp });
        }

        private static void TimTheoTen()
        {
            Console.Write("Nhập từ khóa tên sản phẩm: ");
            string tuKhoa = Console.ReadLine();

            Func<Product, bool> dieuKien = p => p.TenSP.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0;
            XuatDanhSach(service.Search(dieuKien));
        }

        private static void LocTheoKhoangGia()
        {
            double giaMin = NhapSoThuc("Nhập giá nhỏ nhất: ", v => v >= 0);
            double giaMax = NhapSoThuc("Nhập giá lớn nhất: ", v => v >= giaMin);

            XuatDanhSach(service.Filter(giaMin, giaMax));
        }

        private static void XoaSanPham()
        {
            Console.Write("Nhập mã sản phẩm cần xóa: ");
            string ma = Console.ReadLine();

            try
            {
                service.RemoveProduct(ma);
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        private static void TinhTongGiaTriKho()
        {
            double tong = service.TinhTongGiaTriKho();
            Console.WriteLine($"Tổng giá trị kho: {tong:N0}");
        }

        private static double NhapSoThuc(string thongBao, Func<double, bool> hopLe)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double kq) && hopLe(kq))
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