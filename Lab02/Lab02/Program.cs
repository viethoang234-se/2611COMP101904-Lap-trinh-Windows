using System;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{   
    
    class Program
    {
        static int[] mang = null;
        static bool DaNhapMang = false;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            int luaChon;
            do
            {
                HienThiMenu();
                Console.Write("Chọn chức năng: ");
                luaChon = NhapSoNguyen();

                switch (luaChon)
                {
                    case 1:
                        mang = NhapMang();
                        DaNhapMang = true;
                        break;
                    case 2:
                        if (DaNhapMang)
                        {
                            XuatMang(mang);
                        }
                        else
                        {
                            Console.WriteLine("Vui lòng nhập mảng trước khi xuất.");
                        }
                        break;
                    case 3:
                        if (DaNhapMang)
                        {
                            int tong = TinhTong(mang);
                            Console.WriteLine($"Tổng các phần tử trong mảng là: {tong}");
                        }
                        else
                        {
                            Console.WriteLine("Vui lòng nhập mảng trước khi tính tổng.");
                        }
                        break;
                    case 4:
                        if (DaNhapMang)
                        {
                            int max = TimMax(mang);
                            int min = TimMin(mang);
                            Console.WriteLine($"Phần tử lớn nhất trong mảng là: {max}");
                            Console.WriteLine($"Phần tử nhỏ nhất trong mảng là: {min}");
                        }
                        else
                        {
                            Console.WriteLine("Vui lòng nhập mảng trước khi tìm phần tử lớn nhất hoặc nhỏ nhất.");
                        }
                        break;
                    case 5:
                        if (DaNhapMang)
                        {
                            int demChan = DemChan(mang);
                            int demLe = DemLe(mang);
                            Console.WriteLine($"Số lượng phần tử chẵn trong mảng là: {demChan}");
                            Console.WriteLine($"Số lượng phần tử lẻ trong mảng là: {demLe}");
                        }
                        else
                        {
                            Console.WriteLine("Vui lòng nhập mảng trước khi đếm chẵn lẻ.");
                        }
                        break;
                    case 6:
                        if (DaNhapMang)
                        {
                            SapXepTangDan(mang);
                            Console.WriteLine("Mảng sau khi sắp xếp tăng dần:");
                            XuatMang(mang);
                        }
                        else
                        {
                            Console.WriteLine("Vui lòng nhập mảng trước khi sắp xếp.");
                        }
                        break;
                    case 7:
                        if (DaNhapMang)
                        {
                            Console.Write("Nhập giá trị cần tìm kiếm: ");
                            int giaTri = NhapSoNguyen();
                            int viTri = TimKiem(mang, giaTri);
                            if (viTri != -1)
                            {
                                Console.WriteLine($"Phần tử {giaTri} được tìm thấy tại vị trí {viTri}.");
                            }
                            else
                            {
                                Console.WriteLine($"Phần tử {giaTri} không tồn tại trong mảng.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vui lòng nhập mảng trước khi tìm kiếm.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine();
            } while (luaChon != 0);
        }

        static void HienThiMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhập mảng số nguyên");
            Console.WriteLine("2. Xuất mảng số nguyên");
            Console.WriteLine("3. Tính tổng các phần tử trong mảng");
            Console.WriteLine("4. Tìm phần tử lớn nhất hoặc nhỏ nhất trong mảng");
            Console.WriteLine("5. Đếm chẵn lẻ");
            Console.WriteLine("6. Sắp xếp tăng dần");
            Console.WriteLine("7. Tìm kiếm");
            Console.WriteLine("0. Thoát");
        }

        static int NhapSoNguyen()
        {
            int SoNguyen;
            while (!int.TryParse(Console.ReadLine(), out SoNguyen))
            {
                Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ.");
            }
            return SoNguyen;
        }

        static int NhapSoNguyenDuong()
        {
            int SoNguyenDuong;
            while (!int.TryParse(Console.ReadLine(), out SoNguyenDuong) || SoNguyenDuong <= 0)
            {
                Console.WriteLine("Vui lòng nhập một số nguyên dương hợp lệ.");
            }
            return SoNguyenDuong;
        }

        static int[] NhapMang()
        {
            Console.Write("Nhập số lượng phần tử của mảng: ");
            int n = NhapSoNguyenDuong();
            int[] mang = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập phần tử thứ {i + 1}: ");
                mang[i] = NhapSoNguyen();
            }
            return mang;
        }

        static void XuatMang(int[] mang)
        {
            Console.WriteLine("Các phần tử trong mảng là:");
            foreach (int phanTu in mang)
            {
                Console.Write(phanTu + " ");
            }
            Console.WriteLine();
        }

        static int TinhTong(int[] mang)
        {
            int tong = 0;
            foreach (int phanTu in mang)
            {
                tong += phanTu;
            }
            return tong;
        }

        static int TimMax(int[] mang)
        {
            int max = mang[0];
            foreach (int phanTu in mang)
            {
                if (phanTu > max)
                {
                    max = phanTu;
                }
            }
            return max;
        }

        static int TimMin(int[] mang)
        {
            int min = mang[0];
            foreach (int phanTu in mang)
            {
                if (phanTu < min)
                {
                    min = phanTu;
                }
            }
            return min;
        }

        static int DemChan(int[] mang)
        {
            int demChan = 0;
            foreach (int phanTu in mang)
            {
                if (phanTu % 2 == 0)
                {
                    demChan++;
                }
            }
            return demChan;
        }

        static int DemLe(int[] mang)
        {
            int demLe = 0;
            foreach (int phanTu in mang)
            {
                if (phanTu % 2 != 0)
                {
                    demLe++;
                }
            }
            return demLe;
        }

        static void SapXepTangDan(int[] mang)
        {
            for (int i = 0; i < mang.Length - 1; i++)
            {
                int viTriNhoNhat = i;
                for (int j = i + 1; j < mang.Length; j++)
                {
                    if (mang[j] < mang[viTriNhoNhat])
                    {
                        viTriNhoNhat = j;
                    }
                }
                if (viTriNhoNhat != i)
                {
                    int temp = mang[i];
                    mang[i] = mang[viTriNhoNhat];
                    mang[viTriNhoNhat] = temp;
                }
            }
        }

        static int TimKiem(int[] mang, int giaTri)
        {
            for (int i = 0; i < mang.Length; i++)
            {
                if (mang[i] == giaTri)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}