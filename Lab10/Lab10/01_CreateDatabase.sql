/* =====================================================================
   COMP1019 - Lab 10: EduManagerDB
   File 01: Tạo database, bảng, khóa chính, khóa ngoại, ràng buộc
   Chạy file này đầu tiên (có thể chạy lại nhiều lần).
   ===================================================================== */

USE master;
GO

-- Xóa database cũ (nếu có). Ngắt các kết nối đang mở để DROP không bị lỗi.
IF DB_ID('EduManagerDB') IS NOT NULL
BEGIN
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE EduManagerDB;
END
GO

CREATE DATABASE EduManagerDB;
GO
USE EduManagerDB;
GO

-- ---------------------------------------------------------------------
-- 1. KHOA
-- ---------------------------------------------------------------------
CREATE TABLE KHOA (
    MaKhoa     VARCHAR(20)   NOT NULL PRIMARY KEY,
    TenKhoa    NVARCHAR(100) NOT NULL,
    DienThoai  VARCHAR(15)   NULL
);
GO

-- ---------------------------------------------------------------------
-- 2. LOP (mỗi lớp thuộc một khoa)
-- ---------------------------------------------------------------------
CREATE TABLE LOP (
    MaLop   VARCHAR(20)   NOT NULL PRIMARY KEY,
    TenLop  NVARCHAR(100) NOT NULL,
    MaKhoa  VARCHAR(20)   NOT NULL,
    CONSTRAINT FK_LOP_KHOA FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
);
GO

-- ---------------------------------------------------------------------
-- 3. SINHVIEN (mỗi sinh viên thuộc một lớp; giới tính chỉ Nam/Nữ)
-- ---------------------------------------------------------------------
CREATE TABLE SINHVIEN (
    MaSV      VARCHAR(20)   NOT NULL PRIMARY KEY,
    HoTen     NVARCHAR(100) NOT NULL,
    NgaySinh  DATE          NULL,
    GioiTinh  NVARCHAR(10)  NOT NULL,
    MaLop     VARCHAR(20)   NOT NULL,
    CONSTRAINT CK_SINHVIEN_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

-- ---------------------------------------------------------------------
-- 4. MONHOC (số tín chỉ phải > 0)
-- ---------------------------------------------------------------------
CREATE TABLE MONHOC (
    MaMH      VARCHAR(20)   NOT NULL PRIMARY KEY,
    TenMH     NVARCHAR(100) NOT NULL,
    SoTinChi  INT           NOT NULL,
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

-- ---------------------------------------------------------------------
-- 5. KETQUA (khóa chính ghép: một sinh viên chỉ có 1 điểm cho 1 môn)
-- ---------------------------------------------------------------------
CREATE TABLE KETQUA (
    MaSV  VARCHAR(20)  NOT NULL,
    MaMH  VARCHAR(20)  NOT NULL,
    Diem  DECIMAL(4,2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC   FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);
GO

-- ---------------------------------------------------------------------
-- 6. TAIKHOAN (tài khoản demo, mật khẩu để dạng thường chỉ phục vụ bài lab)
-- ---------------------------------------------------------------------
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50)   NOT NULL PRIMARY KEY,
    MatKhau     VARCHAR(100)  NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL DEFAULT 'User',
    TrangThai   BIT           NOT NULL DEFAULT 1
);
GO

-- Kiểm tra: phải thấy đủ 6 bảng
SELECT name AS TenBang FROM sys.tables ORDER BY name;
GO
