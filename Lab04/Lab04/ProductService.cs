using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04_QuanLySanPham
{
    public class ProductService
    {
        private readonly Repository<Product> _repository;

        public event Action<Product> ProductAdded;
        public event Action<Product> ProductRemoved;

        public ProductService(Repository<Product> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (_repository.FindById(product.MaSP) != null)
                throw new DuplicateProductException(product.MaSP);

            _repository.Add(product);
            ProductAdded?.Invoke(product);
        }

        public void RemoveProduct(string maSP)
        {
            Product product = _repository.FindById(maSP);
            if (product == null)
                throw new ProductNotFoundException(maSP);

            _repository.Remove(product.MaSP);
            ProductRemoved?.Invoke(product);
        }

        public List<Product> GetAll() => _repository.GetAll();

        public Product TimTheoMa(string maSP) => _repository.FindById(maSP);

        public List<Product> Search(Func<Product, bool> dieuKien) => _repository.Find(dieuKien);

        public List<Product> Filter(double giaMin, double giaMax)
        {
            Func<Product, bool> dieuKien = p => p.Price >= giaMin && p.Price <= giaMax;
            return _repository.Find(dieuKien);
        }

        public double TinhTongGiaTriKho()
        {
            return _repository.GetAll().Sum(p => p.Price * p.Quantity);
        }
    }
}
