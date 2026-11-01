# Lab 11 - ADO.NET và CRUD với SQL Server

## Công nghệ
- C# / Windows Forms
- .NET 10 (`net10.0-windows`)
- SQL Server
- `Microsoft.Data.SqlClient` 6.1.6

## Cấu trúc
- `Lab11.slnx`: solution chính.
- `Lab11/`: mã nguồn project Windows Forms.
- `Images/`: hình ảnh minh họa giao diện và kết quả.
- `Lab11_Script.sql`: script tạo database và dữ liệu mẫu.

## Cách chạy
1. Cài đặt Visual Studio 2022 phiên bản hỗ trợ .NET 10 SDK và workload **.NET desktop development**.
2. Mở SQL Server Management Studio (SSMS), kết nối SQL Server.
3. Chạy toàn bộ file `Lab11_Script.sql` để tạo database `EduManagerDB` và dữ liệu mẫu.
4. Mở `Lab11.slnx` bằng Visual Studio.
5. Kiểm tra connection string trong `Lab11/Data/DbConfig.cs` cho khớp với máy đang chạy SQL Server.
6. Nhấn `F5` để chạy ứng dụng. Visual Studio sẽ tự khôi phục NuGet package.

## Cấu hình kết nối SQL Server
Mặc định trong `Lab11/Data/DbConfig.cs`:

```csharp
Server=localhost\\SQLEXPRESS;Database=EduManagerDB;Trusted_Connection=True;TrustServerCertificate=True;
```

- Nếu dùng SQL Server instance mặc định, thay `localhost\\SQLEXPRESS` bằng `localhost`.
- Nếu dùng SQL Server Authentication, thay `Trusted_Connection=True` bằng `User Id=...;Password=...`.
- Không đưa mật khẩu hoặc thông tin đăng nhập cá nhân lên GitHub.

## Đẩy project lên GitHub

Repository: https://github.com/viethoang234-se/2611COMP101904-Lap-trinh-Windows

Mở Terminal/PowerShell tại thư mục chứa `Lab11.slnx`, sau đó chạy:

```bash
git init
git add .
git commit -m "Add Lab 11 - .NET 10"
git branch -M main
git remote add origin https://github.com/viethoang234-se/2611COMP101904-Lap-trinh-Windows.git
git push -u origin main
```

Nếu Git báo `remote origin already exists`, dùng lệnh sau thay cho `git remote add origin`:

```bash
git remote set-url origin https://github.com/viethoang234-se/2611COMP101904-Lap-trinh-Windows.git
```

Nếu repository GitHub đã có commit/file và push bị từ chối do lịch sử khác nhau, không dùng `--force` ngay. Hãy kiểm tra nội dung repository và đồng bộ trước để tránh ghi đè dữ liệu.

## Lưu ý
- Chỉ commit source code, file solution, SQL, README và hình ảnh cần thiết.
- Không commit `.vs/`, `bin/`, `obj/` hoặc file build.
- Máy giảng viên cần có .NET 10 runtime/SDK phù hợp và SQL Server đã tạo database theo script.
