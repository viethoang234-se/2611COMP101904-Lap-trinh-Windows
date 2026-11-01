# Lab 06 - ProductManager (Windows Forms + DataGridView)

Học phần: COMP1019 - Lập trình trên Windows

## Cách chạy
1. Mở `Lab06.slnx` bằng Visual Studio 2022 trở lên (workload ".NET desktop development").
2. Nhấn F5 để chạy. Mở Designer: double-click `FrmProduct.cs` trong Solution Explorer.

## Chức năng
- Thêm / Sửa / Xóa / Tìm kiếm / Làm mới sản phẩm (dữ liệu trong bộ nhớ, `BindingList<Product>` + `BindingSource`)
- Validation bằng `ErrorProvider` (rỗng, trùng mã, đơn giá > 0, ngày nhập <= hôm nay)
- `MenuStrip`, `ToolStrip`, `StatusStrip`, `ContextMenuStrip` (chuột phải trên lưới)
- Chọn ảnh bằng `OpenFileDialog`, hiển thị trong `PictureBox`
- Phím tắt: Ctrl+N (thêm), Ctrl+E (sửa), Ctrl+D hoặc Delete (xóa), F5 (làm mới)

## Ảnh minh chứng
(Thêm ảnh chụp màn hình vào thư mục `images/` rồi chèn vào đây)

![Form chính](images/form.png)
