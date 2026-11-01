using Lab14.DAL;
using Lab14.Models;

namespace Lab14.BLL;

/// <summary>
/// Xử lý nghiệp vụ và validation trước khi gọi DAL.
/// </summary>
public class MonHocBLL
{
    private readonly MonHocDAL _dal;

    public MonHocBLL(MonHocDAL dal)
    {
        _dal = dal;
    }

    public List<MonHoc> GetAll() => _dal.GetAll();

    public List<MonHoc> Search(string keyword)
    {
        return string.IsNullOrWhiteSpace(keyword)
            ? _dal.GetAll()
            : _dal.Search(keyword.Trim());
    }

    public void Add(MonHoc monHoc)
    {
        Validate(monHoc);

        monHoc.MaMonHoc = monHoc.MaMonHoc.Trim().ToUpperInvariant();
        monHoc.TenMonHoc = monHoc.TenMonHoc.Trim();

        if (_dal.Exists(monHoc.MaMonHoc))
            throw new InvalidOperationException("Mã môn học đã tồn tại.");

        _dal.Add(monHoc);
    }

    public void Update(MonHoc monHoc)
    {
        Validate(monHoc);
        monHoc.MaMonHoc = monHoc.MaMonHoc.Trim().ToUpperInvariant();
        monHoc.TenMonHoc = monHoc.TenMonHoc.Trim();

        if (!_dal.Update(monHoc))
            throw new InvalidOperationException("Không tìm thấy môn học cần cập nhật.");
    }

    public void Delete(string maMonHoc)
    {
        if (string.IsNullOrWhiteSpace(maMonHoc))
            throw new ArgumentException("Vui lòng chọn môn học cần xóa.");

        if (!_dal.Delete(maMonHoc.Trim()))
            throw new InvalidOperationException("Không tìm thấy môn học cần xóa.");
    }

    private static void Validate(MonHoc monHoc)
    {
        if (string.IsNullOrWhiteSpace(monHoc.MaMonHoc))
            throw new ArgumentException("Mã môn học không được để trống.");
        if (monHoc.MaMonHoc.Trim().Length > 10)
            throw new ArgumentException("Mã môn học tối đa 10 ký tự.");
        if (string.IsNullOrWhiteSpace(monHoc.TenMonHoc))
            throw new ArgumentException("Tên môn học không được để trống.");
        if (monHoc.TenMonHoc.Trim().Length > 100)
            throw new ArgumentException("Tên môn học tối đa 100 ký tự.");
        if (monHoc.SoTinChi < 1 || monHoc.SoTinChi > 6)
            throw new ArgumentException("Số tín chỉ phải nằm trong khoảng từ 1 đến 6.");
    }
}
