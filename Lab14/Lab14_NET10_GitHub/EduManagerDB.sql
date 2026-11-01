IF DB_ID(N'EduManagerDB') IS NULL
    CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

IF OBJECT_ID(N'dbo.MONHOC', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MONHOC
    (
        MaMonHoc NVARCHAR(10) NOT NULL,
        TenMonHoc NVARCHAR(100) NOT NULL,
        SoTinChi INT NOT NULL,
        TrangThai BIT NOT NULL CONSTRAINT DF_MONHOC_TrangThai DEFAULT (1),
        CONSTRAINT PK_MONHOC PRIMARY KEY (MaMonHoc),
        CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi BETWEEN 1 AND 6)
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.MONHOC WHERE MaMonHoc = N'COMP1019')
    INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai)
    VALUES (N'COMP1019', N'Lập trình trên Windows', 3, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.MONHOC WHERE MaMonHoc = N'COMP1020')
    INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai)
    VALUES (N'COMP1020', N'Cơ sở dữ liệu', 3, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.MONHOC WHERE MaMonHoc = N'COMP1021')
    INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai)
    VALUES (N'COMP1021', N'Lập trình hướng đối tượng', 4, 1);
GO

SELECT * FROM dbo.MONHOC ORDER BY MaMonHoc;
