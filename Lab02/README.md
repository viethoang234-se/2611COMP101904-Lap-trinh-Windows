# Bài Lab 02 - Quản lý mảng số nguyên bằng Console

## 1. Mô tả bài toán
Viết chương trình Console C# quản lý một mảng số nguyên. Chương trình hiển thị menu để người dùng lựa chọn chức năng, thực hiện xong một chức năng thì quay lại menu, cho đến khi người dùng chọn thoát.

## 2. Chức năng chương trình
1. Nhập mảng (nhập số lượng phần tử n nguyên dương, sau đó nhập n phần tử)
2. Xuất mảng (in toàn bộ phần tử ra màn hình)
3. Tính tổng các phần tử trong mảng
4. Tìm giá trị lớn nhất và nhỏ nhất
5. Đếm số phần tử chẵn / lẻ
6. Sắp xếp mảng tăng dần
7. Tìm kiếm một giá trị x trong mảng, in vị trí xuất hiện đầu tiên nếu có
0. Thoát chương trình

## 3. Kết quả đạt được
- Xây dựng menu điều khiển chương trình dạng vòng lặp, chạy đến khi chọn Thoát.
- Tách chương trình thành các phương thức riêng biệt: `NhapSoNguyen`, `NhapSoNguyenDuong`, `NhapMang`, `XuatMang`, `TinhTong`, `TimMax`, `TimMin`, `DemChan`, `DemLe`, `SapXepTangDan`, `TimKiem`.
- Kiểm tra dữ liệu nhập: số lượng phần tử n phải là số nguyên dương, lựa chọn menu không hợp lệ được yêu cầu nhập lại.
- Không cho thực hiện các chức năng (xuất, tính tổng, sắp xếp...) khi chưa nhập mảng.
- Chương trình không bị dừng bất thường khi nhập sai dữ liệu.

## 4. Hình ảnh demo
![Menu chương trình](menu.png)
![Nhập và xuất mảng](nhap_xuat.png)
![Tính tổng, tìm max/min, đếm chẵn lẻ](tinh_toan.png)
![Sắp xếp tăng dần](sap_xep.png)
![Tìm kiếm phần tử](tim_kiem.png)
