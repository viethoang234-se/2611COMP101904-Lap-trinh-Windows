namespace Lab12.DAL
{
    /// <summary>
    /// Chứa cấu hình kết nối SQL Server dùng chung cho toàn bộ lớp DAL.
    /// Nếu máy dùng SQL Server Express, đổi Data Source thành .\SQLEXPRESS
    /// </summary>
    public static class Database
    {
        public const string ConnectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=QLSinhVienLab12;Integrated Security=True;TrustServerCertificate=True";
    }
}
