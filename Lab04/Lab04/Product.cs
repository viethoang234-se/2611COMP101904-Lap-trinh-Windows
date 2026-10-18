using System;
using System.Globalization;

namespace Lab04_QuanLySanPham
{
    public class Product : IEntity
    {
        private string _maSP;
        private string _tenSP;
        private double _price;
        private int _quantity;

        public Product(string maSP, string tenSP, double price, int quantity)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Price = price;
            Quantity = quantity;
        }

        public string Id => MaSP;

        public string MaSP
        {
            get => _maSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã sản phẩm không được để trống.");
                _maSP = value.Trim();
            }
        }

        public string TenSP
        {
            get => _tenSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên sản phẩm không được để trống.");
                _tenSP = value.Trim();
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value) || value < 0)
                    throw new ArgumentException("Đơn giá không được âm.");
                _price = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số lượng không được âm.");
                _quantity = value;
            }
        }

        public override string ToString()
        {
            return $"{MaSP,-8}{TenSP,-25}{Price.ToString("N0", CultureInfo.InvariantCulture),-15}{Quantity,-10}";
        }
    }
}
