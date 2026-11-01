using Lab07.Models;

namespace Lab07.Data;

public static class DataStore
{
    public static readonly List<User> Users = new()
    {
        new User { Username = "admin", Password = "123", FullName = "Quản trị viên", Role = "Admin" },
        new User { Username = "user", Password = "123", FullName = "Nhân viên bán hàng", Role = "User" }
    };

    public static readonly List<Product> Products = new()
    {
        new Product { Id = "SP001", Name = "Nước suối 500ml", Category = "Đồ uống", Price = 6000, Quantity = 100 },
        new Product { Id = "SP002", Name = "Mì gói", Category = "Thực phẩm", Price = 4500, Quantity = 200 },
        new Product { Id = "SP003", Name = "Bút bi", Category = "Văn phòng phẩm", Price = 5000, Quantity = 150 }
    };

    public static readonly List<Customer> Customers = new()
    {
        new Customer { Id = "KH001", FullName = "Nguyễn Văn An", Phone = "0901234567", Type = "Thường" },
        new Customer { Id = "KH002", FullName = "Trần Thị Bình", Phone = "0912345678", Type = "VIP" }
    };
}
