using System.Data;
using Microsoft.Data.SqlClient;

namespace Lab12.DAL
{
    /// <summary>
    /// Truy cập database cho chức năng nhập điểm. Mọi thao tác đều gọi stored procedure
    /// và truyền dữ liệu bằng parameter, không nối chuỗi SQL.
    /// </summary>
    public class KetQuaDAL
    {
        /// <summary>Lấy danh sách lớp (MaLop, TenLop).</summary>
        public DataTable GetLop()
        {
            return ExecuteTable("sp_Lop_GetAll", null);
        }

        /// <summary>Lấy danh sách môn học (MaMon, TenMon, SoTinChi).</summary>
        public DataTable GetMonHoc()
        {
            return ExecuteTable("sp_MonHoc_GetAll", null);
        }

        /// <summary>Lấy sinh viên của một lớp kèm điểm môn học (nếu đã có).</summary>
        public DataTable GetKetQuaByLopMon(string maLop, string maMon)
        {
            return ExecuteTable("sp_KetQua_GetByLopMon", cmd =>
            {
                cmd.Parameters.Add("@MaLop", SqlDbType.NVarChar, 20).Value = maLop;
                cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;
            });
        }

        /// <summary>
        /// Lưu điểm của tất cả dòng trong một transaction.
        /// Có lỗi ở bất kỳ dòng nào thì Rollback toàn bộ và ném lại exception.
        /// </summary>
        /// <returns>Số dòng đã lưu.</returns>
        public int SaveAll(string maMon, DataTable table)
        {
            using SqlConnection conn = new SqlConnection(Database.ConnectionString);
            conn.Open();
            using SqlTransaction trans = conn.BeginTransaction();

            try
            {
                // Dùng chung một command, mỗi vòng lặp chỉ gán lại giá trị parameter
                using SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, trans);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pMaSV = cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 20);
                SqlParameter pMaMon = cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20);
                SqlParameter pDiem = cmd.Parameters.Add("@Diem", SqlDbType.Decimal);
                pDiem.Precision = 4;
                pDiem.Scale = 2;
                SqlParameter pGhiChu = cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255);

                int count = 0;
                foreach (DataRow row in table.Rows)
                {
                    pMaSV.Value = Convert.ToString(row["MaSV"]);
                    pMaMon.Value = maMon;
                    pDiem.Value = Math.Round(Convert.ToDecimal(row["Diem"]), 2);
                    pGhiChu.Value = Convert.ToString(row["GhiChu"]) ?? string.Empty;

                    cmd.ExecuteNonQuery();
                    count++;
                }

                trans.Commit(); // chỉ commit khi TẤT CẢ dòng đã lưu thành công
                return count;
            }
            catch
            {
                try { trans.Rollback(); } catch { /* kết nối đã mất thì SQL Server tự hủy transaction */ }
                throw;
            }
        }

        /// <summary>Gọi stored procedure trả về DataTable.</summary>
        private static DataTable ExecuteTable(string procedureName, Action<SqlCommand> addParameters)
        {
            using SqlConnection conn = new SqlConnection(Database.ConnectionString);
            using SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            addParameters?.Invoke(cmd);

            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
