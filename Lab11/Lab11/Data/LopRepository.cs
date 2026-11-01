using System.Data;
using Lab11.Models;
using Microsoft.Data.SqlClient;

namespace Lab11.Data;

public class LopRepository
{
    private readonly string _connectionString;

    public LopRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Lop> GetAll() =>
        Query("SELECT MaLop, TenLop FROM LOP ORDER BY MaLop");

    public List<Lop> Search(string keyword) =>
        Query(
            "SELECT MaLop, TenLop FROM LOP WHERE MaLop LIKE @Keyword OR TenLop LIKE @Keyword ORDER BY MaLop",
            new SqlParameter("@Keyword", SqlDbType.NVarChar, 210) { Value = $"%{EscapeLike(keyword)}%" });

    public bool Exists(string maLop) =>
        Scalar("SELECT COUNT(1) FROM LOP WHERE MaLop = @MaLop", MaLopParam(maLop)) > 0;

    public bool HasStudents(string maLop) =>
        Scalar("SELECT COUNT(1) FROM SINHVIEN WHERE MaLop = @MaLop", MaLopParam(maLop)) > 0;

    public void Insert(Lop lop) =>
        Execute(
            "INSERT INTO LOP (MaLop, TenLop) VALUES (@MaLop, @TenLop)",
            MaLopParam(lop.MaLop), TenLopParam(lop.TenLop));

    public bool Update(Lop lop) =>
        Execute(
            "UPDATE LOP SET TenLop = @TenLop WHERE MaLop = @MaLop",
            MaLopParam(lop.MaLop), TenLopParam(lop.TenLop)) > 0;

    public bool Delete(string maLop) =>
        Execute("DELETE FROM LOP WHERE MaLop = @MaLop", MaLopParam(maLop)) > 0;

    private static SqlParameter MaLopParam(string value) =>
        new("@MaLop", SqlDbType.VarChar, 20) { Value = value };

    private static SqlParameter TenLopParam(string value) =>
        new("@TenLop", SqlDbType.NVarChar, 100) { Value = value };

    private static string EscapeLike(string value) =>
        value.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");

    private T Run<T>(string sql, SqlParameter[] parameters, Func<SqlCommand, T> execute)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters);
        connection.Open();
        return execute(command);
    }

    private List<Lop> Query(string sql, params SqlParameter[] parameters) =>
        Run(sql, parameters, command =>
        {
            using var reader = command.ExecuteReader();
            var result = new List<Lop>();
            while (reader.Read())
            {
                result.Add(new Lop { MaLop = reader.GetString(0), TenLop = reader.GetString(1) });
            }
            return result;
        });

    private int Execute(string sql, params SqlParameter[] parameters) =>
        Run(sql, parameters, command => command.ExecuteNonQuery());

    private int Scalar(string sql, params SqlParameter[] parameters) =>
        Run(sql, parameters, command => (int)command.ExecuteScalar());
}
