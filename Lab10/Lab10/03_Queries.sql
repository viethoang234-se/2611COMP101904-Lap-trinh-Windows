/* =====================================================================
   COMP1019 - Lab 10: EduManagerDB
   File 03: Truy vấn SELECT / JOIN / GROUP BY / UPDATE / DELETE và test ràng buộc
   Chạy sau file 01 và 02. Nên bôi đen từng câu rồi nhấn F5 để chụp kết quả.
   ===================================================================== */

USE EduManagerDB;
GO

-- =====================================================================
-- PHẦN A. TRUY VẤN CƠ BẢN
-- =====================================================================

-- 1. Liệt kê toàn bộ sinh viên
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;

-- 2. Sinh viên kèm tên lớp và tên khoa
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP  l ON sv.MaLop  = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa  = k.MaKhoa
ORDER BY sv.MaSV;

-- 3. Tìm sinh viên theo một phần họ tên (LIKE)
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%An%'
ORDER BY HoTen ASC;

-- 4. Liệt kê sinh viên theo mã lớp
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';

-- =====================================================================
-- PHẦN B. CẬP NHẬT VÀ XÓA
-- =====================================================================

-- 5. Cập nhật họ tên (hoặc lớp) của một sinh viên
--    Luôn kiểm tra điều kiện WHERE trước khi chạy UPDATE.
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An (đã cập nhật)'
WHERE MaSV = 'SV001';

-- Ví dụ đổi lớp: UPDATE SINHVIEN SET MaLop = 'CNTT02' WHERE MaSV = 'SV002';

SELECT MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV001';

-- 6. Xóa một sinh viên chưa có dữ liệu điểm (SV007)
--    Điều kiện NOT EXISTS đảm bảo không xóa sinh viên đã có điểm.
DELETE FROM SINHVIEN
WHERE MaSV = 'SV007'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV007');

SELECT MaSV, HoTen FROM SINHVIEN;   -- SV007 không còn

-- =====================================================================
-- PHẦN C. JOIN VÀ THỐNG KÊ
-- =====================================================================

-- 7. Điểm của từng sinh viên theo từng môn
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC   mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;

-- 8. Điểm trung bình của từng sinh viên
SELECT sv.MaSV, sv.HoTen, ROUND(AVG(kq.Diem), 2) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen
ORDER BY sv.MaSV;

-- 9. Thống kê số sinh viên theo từng lớp
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
ORDER BY l.MaLop;

-- 10. Các lớp có từ 2 sinh viên trở lên (HAVING lọc sau khi gom nhóm)
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2;
GO

-- =====================================================================
-- PHẦN D. KIỂM THỬ RÀNG BUỘC (các câu dưới đây PHẢI báo lỗi)
-- Mỗi test bọc trong TRY...CATCH để in thông báo lỗi mà không dừng script.
-- =====================================================================

-- 11. Thêm sinh viên vào lớp không tồn tại -> lỗi khóa ngoại (FK_SINHVIEN_LOP)
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
    PRINT N'TEST 11: KHÔNG có lỗi (sai!)';
END TRY
BEGIN CATCH
    SELECT N'Test 11 - lớp không tồn tại' AS TestCase,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBao;
END CATCH
GO

-- 12. Nhập điểm ngoài khoảng 0..10 -> lỗi CHECK (CK_KETQUA_Diem)
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES ('SV003', 'COMP1017', 12);
    PRINT N'TEST 12: KHÔNG có lỗi (sai!)';
END TRY
BEGIN CATCH
    SELECT N'Test 12 - điểm = 12' AS TestCase,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBao;
END CATCH
GO

-- 13. Giới tính ngoài Nam/Nữ -> lỗi CHECK (CK_SINHVIEN_GioiTinh)
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV998', N'Giới tính lỗi', '2005-01-01', N'Khác', 'CNTT01');
    PRINT N'TEST 13: KHÔNG có lỗi (sai!)';
END TRY
BEGIN CATCH
    SELECT N'Test 13 - giới tính = Khác' AS TestCase,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBao;
END CATCH
GO

-- 14. Trùng khóa chính MaSV -> lỗi PRIMARY KEY
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV001', N'Trùng mã', '2005-01-01', N'Nam', 'CNTT01');
    PRINT N'TEST 14: KHÔNG có lỗi (sai!)';
END TRY
BEGIN CATCH
    SELECT N'Test 14 - trùng MaSV' AS TestCase,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBao;
END CATCH
GO

-- 15. Số tín chỉ = 0 -> lỗi CHECK (CK_MONHOC_SoTinChi)
BEGIN TRY
    INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES ('COMP9999', N'Môn lỗi', 0);
    PRINT N'TEST 15: KHÔNG có lỗi (sai!)';
END TRY
BEGIN CATCH
    SELECT N'Test 15 - số tín chỉ = 0' AS TestCase,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBao;
END CATCH
GO
