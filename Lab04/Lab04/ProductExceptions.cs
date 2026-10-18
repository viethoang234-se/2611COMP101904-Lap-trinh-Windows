using System;

namespace Lab04_QuanLySanPham
{
    public class DuplicateProductException : Exception
    {
        public string MaSP { get; }

        public DuplicateProductException(string maSP)
            : base($"Mã sản phẩm \"{maSP}\" đã tồn tại.")
        {
            MaSP = maSP;
        }
    }

    public class ProductNotFoundException : Exception
    {
        public string MaSP { get; }

        public ProductNotFoundException(string maSP)
            : base($"Không tìm thấy sản phẩm có mã \"{maSP}\".")
        {
            MaSP = maSP;
        }
    }
}
