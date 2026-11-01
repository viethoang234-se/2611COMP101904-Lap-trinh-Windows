/* =====================================================================
   COMP1019 - Lab 12: Data Binding, Stored Procedure va Transaction
   Script tao database QLSinhVienLab12, bang, du lieu mau, stored procedure.
   Chay toan bo script trong SSMS (Execute / F5).
   ===================================================================== */

USE master;
GO

-- Xoa database cu (neu co) de co the chay lai tu dau
IF DB_ID('QLSinhVienLab12') IS NOT NULL
BEGIN
    ALTER DATABASE QLSinhVienLab12 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSinhVienLab12;
END
GO

CREATE DATABASE QLSinhVienLab12;
GO
USE QLSinhVienLab12;
GO

/* ------------------------------ BANG ------------------------------ */

CREATE TABLE LOP (
    MaLop  NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);

CREATE TABLE SINHVIEN (
    MaSV     NVARCHAR(20)  NOT NULL PRIMARY KEY,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    MaLop    NVARCHAR(20)  NOT NULL,
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);

CREATE TABLE MONHOC (
    MaMon    NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenMon   NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL,
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);

CREATE TABLE KETQUA (
    MaSV   NVARCHAR(20)  NOT NULL,
    MaMon  NVARCHAR(20)  NOT NULL,
    Diem   DECIMAL(4,2)  NOT NULL,
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMon),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem >= 0 AND Diem <= 10),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV)  REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC   FOREIGN KEY (MaMon) REFERENCES MONHOC(MaMon)
);
GO

/* --------------------------- DU LIEU MAU --------------------------- */

INSERT INTO LOP (MaLop, TenLop) VALUES
(N'CTK47A', N'Công nghệ thông tin K47A'),
(N'CTK47B', N'Công nghệ thông tin K47B'),
(N'CTK48A', N'Công nghệ thông tin K48A');

INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, MaLop) VALUES
(N'SV001', N'Nguyễn Văn An',    '2005-01-15', N'CTK47A'),
(N'SV002', N'Trần Thị Bình',    '2005-05-20', N'CTK47A'),
(N'SV003', N'Lê Minh Cường',    '2005-03-11', N'CTK47A'),
(N'SV004', N'Phạm Thanh Dung',  '2005-07-09', N'CTK47A'),
(N'SV005', N'Hoàng Quốc Huy',   '2005-09-02', N'CTK47B'),
(N'SV006', N'Võ Gia Khang',     '2005-11-23', N'CTK47B'),
(N'SV007', N'Đặng Minh Khôi',   '2005-02-14', N'CTK47B'),
(N'SV008', N'Bùi Thảo Linh',    '2006-04-30', N'CTK48A'),
(N'SV009', N'Ngô Tuấn Minh',    '2006-06-18', N'CTK48A'),
(N'SV010', N'Đỗ Bảo Ngọc',      '2006-08-07', N'CTK48A');

INSERT INTO MONHOC (MaMon, TenMon, SoTinChi) VALUES
(N'COMP1019', N'Lập trình trên Windows', 3),
(N'COMP1017', N'Cơ sở lập trình',        3),
(N'COMP1020', N'Cơ sở dữ liệu',          3);

-- Mot vai diem co san de thay ro viec "cap nhat neu da co, them moi neu chua co"
INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) VALUES
(N'SV001', N'COMP1019', 8.5, N'Làm bài tốt'),
(N'SV002', N'COMP1019', 7.0, N''),
(N'SV005', N'COMP1019', 6.5, N'');
GO

/* ------------------------ STORED PROCEDURE ------------------------ */

-- 1. Lay danh sach lop
CREATE OR ALTER PROCEDURE sp_Lop_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLop, TenLop
    FROM LOP
    ORDER BY TenLop;
END;
GO

-- 2. Lay danh sach mon hoc
CREATE OR ALTER PROCEDURE sp_MonHoc_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaMon, TenMon, SoTinChi
    FROM MONHOC
    ORDER BY TenMon;
END;
GO

-- 3. Lay sinh vien theo lop va mon hoc, kem diem neu da co (chua co diem thi Diem = NULL)
CREATE OR ALTER PROCEDURE sp_KetQua_GetByLopMon
    @MaLop NVARCHAR(20),
    @MaMon NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV,
           sv.HoTen,
           kq.Diem,
           ISNULL(kq.GhiChu, N'') AS GhiChu
    FROM SINHVIEN sv
    LEFT JOIN KETQUA kq
           ON kq.MaSV = sv.MaSV AND kq.MaMon = @MaMon
    WHERE sv.MaLop = @MaLop
    ORDER BY sv.MaSV;
END;
GO

-- 4. Luu diem: da co thi UPDATE, chua co thi INSERT
CREATE OR ALTER PROCEDURE sp_KetQua_Save
    @MaSV   NVARCHAR(20),
    @MaMon  NVARCHAR(20),
    @Diem   DECIMAL(4,2),
    @GhiChu NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiem tra them o phia server (ngoai CHECK constraint)
    IF @Diem IS NULL OR @Diem < 0 OR @Diem > 10
        THROW 50001, N'Điểm phải nằm trong khoảng từ 0 đến 10.', 1;

    IF EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = @MaSV AND MaMon = @MaMon)
    BEGIN
        UPDATE KETQUA
        SET Diem = @Diem, GhiChu = @GhiChu
        WHERE MaSV = @MaSV AND MaMon = @MaMon;
    END
    ELSE
    BEGIN
        INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu)
        VALUES (@MaSV, @MaMon, @Diem, @GhiChu);
    END
END;
GO

/* ---------------- CAU LENH KIEM TRA (chay rieng khi can) ----------------
-- Xem diem hien co (dung de chup anh TRUOC / SAU khi luu)
SELECT kq.MaSV, sv.HoTen, kq.MaMon, kq.Diem, kq.GhiChu
FROM KETQUA kq
JOIN SINHVIEN sv ON sv.MaSV = kq.MaSV
ORDER BY kq.MaMon, kq.MaSV;

-- Thu proc luu diem hop le
EXEC sp_KetQua_GetByLopMon @MaLop = N'CTK47A', @MaMon = N'COMP1019';

-- Thu diem sai: phai bao loi 50001
EXEC sp_KetQua_Save @MaSV = N'SV003', @MaMon = N'COMP1019', @Diem = 15, @GhiChu = N'';
--------------------------------------------------------------------- */
