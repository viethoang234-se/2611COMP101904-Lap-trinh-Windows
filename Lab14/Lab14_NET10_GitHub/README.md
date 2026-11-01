# Lab14 - Entity Framework Core và mô hình ba lớp

**Học phần:** COMP1019 - Lập trình trên Windows  
**Nền tảng:** .NET 10 Windows Forms  
**Database:** SQL Server - EduManagerDB  
**ORM:** Entity Framework Core 10

## 1. Chức năng

- Hiển thị danh sách môn học khi mở chương trình.
- Thêm, sửa, xóa môn học.
- Tìm kiếm theo mã hoặc tên môn học.
- Chọn một dòng trên DataGridView để đưa dữ liệu lên các ô nhập.
- Làm mới dữ liệu và biểu mẫu.
- Kiểm tra mã, tên, số tín chỉ; không cho thêm mã trùng.
- Xác nhận trước khi xóa.

## 2. Cấu trúc project

```text
Lab14/
├── Lab14.slnx
├── Lab14/
│   ├── Models/MonHoc.cs
│   ├── Data/EduManagerContext.cs
│   ├── DAL/MonHocDAL.cs
│   ├── BLL/MonHocBLL.cs
│   ├── GUI/FrmMonHoc.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── Lab14.csproj
├── EduManagerDB.sql
├── README.md
└── .gitignore
```

- **GUI:** nhận dữ liệu, gọi BLL và hiển thị kết quả.
- **BLL:** kiểm tra dữ liệu và quy tắc nghiệp vụ.
- **DAL:** truy vấn/thay đổi dữ liệu qua Entity Framework Core.
- **Models:** định nghĩa entity `MonHoc`.
- **Data:** định nghĩa `EduManagerContext`.

## 3. Yêu cầu môi trường

- Windows 10/11.
- Visual Studio 2026 hoặc phiên bản hỗ trợ .NET 10.
- .NET 10 SDK.
- SQL Server (Express hoặc Developer) và SQL Server Management Studio.

## 4. Tạo database

1. Mở SQL Server Management Studio (SSMS), kết nối đến SQL Server của bạn.
2. Mở file `EduManagerDB.sql`.
3. Nhấn **Execute** (hoặc F5).
4. Kiểm tra database `EduManagerDB` và bảng `dbo.MONHOC` đã được tạo, có dữ liệu mẫu.

## 5. Cấu hình kết nối SQL Server

Mở `Lab14/appsettings.json`, sửa `Server=.` thành đúng instance SQL Server trên máy.

Ví dụ:

```json
{
  "ConnectionStrings": {
    "EduManager": "Server=.;Database=EduManagerDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Một số instance thường gặp:
- SQL Server mặc định: `Server=.;`
- SQL Server Express: `Server=.\\SQLEXPRESS;`
- LocalDB: `Server=(localdb)\\MSSQLLocalDB;`

Nếu dùng SQL Server Authentication, thay `Trusted_Connection=True` bằng `User Id=...;Password=...;` và không commit mật khẩu thật lên GitHub.

## 6. Chạy chương trình

Mở `Lab14.slnx` bằng Visual Studio, chờ NuGet restore hoàn tất, kiểm tra `appsettings.json`, sau đó nhấn **F5**.

Hoặc mở Terminal tại thư mục chứa `Lab14.slnx`:

```bash
dotnet restore
dotnet build
dotnet run --project Lab14/Lab14.csproj
```

Lệnh chạy yêu cầu Windows vì đây là ứng dụng Windows Forms.

## 7. Hướng dẫn chụp ảnh minh chứng cho README

Chụp ảnh thật từ chương trình đang chạy. Không dùng ảnh giao diện thiết kế trong Visual Studio thay cho ảnh chạy thực tế.

| Tên ảnh | Cách chụp | Nội dung cần thấy |
|---|---|---|
| `01-giao-dien.png` | Mở ứng dụng sau khi chạy | Form, các ô nhập, nút chức năng và DataGridView có dữ liệu |
| `02-them-mon-hoc.png` | Nhập mã `TEST01`, tên `Kiểm thử phần mềm`, 3 tín chỉ; nhấn Thêm | Thông báo thêm thành công hoặc dòng mới trong bảng |
| `03-sua-mon-hoc.png` | Chọn `TEST01`, đổi tên môn học rồi nhấn Sửa | Dữ liệu đã cập nhật |
| `04-tim-kiem.png` | Nhập `COMP` vào ô tìm kiếm, nhấn Tìm kiếm | Danh sách kết quả phù hợp |
| `05-xac-nhan-xoa.png` | Chọn `TEST01`, nhấn Xóa | Hộp thoại xác nhận xóa |
| `06-validation.png` | Thử thêm với mã hoặc tên để trống, hoặc số tín chỉ ngoài khoảng (nếu sửa giới hạn control để thử) | Thông báo validation |

**Cách chụp trên Windows:**
1. Chạy ứng dụng bằng F5.
2. Đưa cửa sổ ứng dụng về trạng thái rõ ràng, không bị che.
3. Nhấn `Win + Shift + S`, chọn vùng cửa sổ cần chụp.
4. Lưu ảnh PNG vào thư mục `screenshots` ở cùng cấp với README.
5. Đặt tên ảnh đúng như bảng trên.

Tạo thư mục `screenshots` và thêm các ảnh đã chụp. Sau đó bỏ dấu `<!-- ... -->` ở phần minh chứng bên dưới để ảnh hiển thị.

## 8. Minh chứng kết quả

Sau khi chụp ảnh, thêm ảnh vào thư mục `screenshots` rồi sử dụng:

```markdown
### Ảnh 1 - Giao diện chính
![Giao diện chính](screenshots/01-giao-dien.png)

### Ảnh 2 - Thêm môn học
![Thêm môn học](screenshots/02-them-mon-hoc.png)

### Ảnh 3 - Sửa môn học
![Sửa môn học](screenshots/03-sua-mon-hoc.png)

### Ảnh 4 - Tìm kiếm
![Tìm kiếm](screenshots/04-tim-kiem.png)

### Ảnh 5 - Xác nhận xóa
![Xác nhận xóa](screenshots/05-xac-nhan-xoa.png)

### Ảnh 6 - Validation
![Validation](screenshots/06-validation.png)
```

## 9. Test case

| STT | Thao tác | Kết quả mong đợi |
|---|---|---|
| 1 | Mở Form | Danh sách môn học được tải |
| 2 | Thêm `TEST01`, tên hợp lệ, 3 tín chỉ | Thêm thành công |
| 3 | Thêm lại mã `TEST01` | Báo mã đã tồn tại |
| 4 | Để trống mã môn học | Báo mã không được để trống |
| 5 | Để trống tên môn học | Báo tên không được để trống |
| 6 | Chọn một dòng, sửa tên | Cập nhật thành công |
| 7 | Tìm từ khóa `COMP` | Hiển thị môn học có mã/tên phù hợp |
| 8 | Xóa `TEST01` và xác nhận | Xóa thành công |
| 9 | Chọn Không ở hộp thoại xác nhận xóa | Không xóa dữ liệu |

## 10. Câu hỏi lý thuyết

**1. Vì sao không nên viết toàn bộ code CRUD trong sự kiện Button Click?**  
Vì giao diện sẽ bị phụ thuộc vào xử lý nghiệp vụ và truy cập dữ liệu. Code khó bảo trì, khó kiểm thử và khó tái sử dụng. Tách GUI, BLL, DAL giúp mỗi lớp có một trách nhiệm rõ ràng.

**2. BLL và DAL khác nhau ở điểm nào?**  
BLL xử lý nghiệp vụ và validation trước khi thao tác dữ liệu. DAL chịu trách nhiệm truy cập database, truy vấn và lưu dữ liệu.

**3. Entity Framework khác ADO.NET ở điểm nào?**  
Entity Framework Core là ORM, cho phép thao tác dữ liệu thông qua entity và LINQ, giảm việc viết SQL thủ công. ADO.NET thường làm việc trực tiếp với connection, command, parameter và data reader/adapter.

**4. Trong bài lab này, validation nào nên đặt ở BLL?**  
Mã môn học không rỗng và không quá 10 ký tự; tên môn học không rỗng và không quá 100 ký tự; số tín chỉ từ 1 đến 6; mã môn học không được trùng khi thêm mới. Database vẫn có khóa chính và CHECK constraint để bảo vệ dữ liệu ở tầng lưu trữ.

## 11. Đẩy bài lên GitHub

Mở Terminal tại thư mục chứa `Lab14.slnx`:

```bash
git init
git add .
git status
git commit -m "Add Lab 14 - EF Core three-layer architecture"
git branch -M main
git remote add origin https://github.com/viethoang234-se/2611COMP101904-Lap-trinh-Windows.git
git push -u origin main
```

Nếu remote đã được cấu hình từ trước, không chạy lại `git remote add origin`. Kiểm tra bằng:

```bash
git remote -v
```

Nếu repository đã có commit trên GitHub, hãy `git pull --rebase origin main` trước khi push; không dùng `--force` khi chưa kiểm tra lịch sử.

## 12. Lưu ý trước khi nộp

- Chạy `EduManagerDB.sql` trước khi mở ứng dụng.
- Chỉnh connection string theo SQL Server trên máy.
- Đảm bảo đã chụp và thêm ảnh thật vào `screenshots/`.
- Không commit mật khẩu database hoặc thông tin nhạy cảm.
- Không đưa thư mục `bin`, `obj`, `.vs` lên GitHub.
