using Lab14.Data;
using Lab14.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab14.DAL;

/// <summary>
/// Lớp truy cập dữ liệu. Mọi thao tác với SQL Server đều thực hiện qua EF Core.
/// </summary>
public class MonHocDAL
{
    private readonly DbContextOptions<EduManagerContext> _options;

    public MonHocDAL(DbContextOptions<EduManagerContext> options)
    {
        _options = options;
    }

    public List<MonHoc> GetAll()
    {
        using var context = new EduManagerContext(_options);
        return context.MonHocs.AsNoTracking()
            .OrderBy(x => x.MaMonHoc)
            .ToList();
    }

    public MonHoc? GetById(string maMonHoc)
    {
        using var context = new EduManagerContext(_options);
        return context.MonHocs.AsNoTracking()
            .FirstOrDefault(x => x.MaMonHoc == maMonHoc);
    }

    public bool Exists(string maMonHoc)
    {
        using var context = new EduManagerContext(_options);
        return context.MonHocs.Any(x => x.MaMonHoc == maMonHoc);
    }

    public void Add(MonHoc monHoc)
    {
        using var context = new EduManagerContext(_options);
        context.MonHocs.Add(monHoc);
        context.SaveChanges();
    }

    public bool Update(MonHoc monHoc)
    {
        using var context = new EduManagerContext(_options);
        var existing = context.MonHocs.Find(monHoc.MaMonHoc);
        if (existing is null) return false;

        existing.TenMonHoc = monHoc.TenMonHoc;
        existing.SoTinChi = monHoc.SoTinChi;
        existing.TrangThai = monHoc.TrangThai;
        context.SaveChanges();
        return true;
    }

    public bool Delete(string maMonHoc)
    {
        using var context = new EduManagerContext(_options);
        var existing = context.MonHocs.Find(maMonHoc);
        if (existing is null) return false;

        context.MonHocs.Remove(existing);
        context.SaveChanges();
        return true;
    }

    public List<MonHoc> Search(string keyword)
    {
        using var context = new EduManagerContext(_options);
        return context.MonHocs.AsNoTracking()
            .Where(x => x.MaMonHoc.Contains(keyword) || x.TenMonHoc.Contains(keyword))
            .OrderBy(x => x.MaMonHoc)
            .ToList();
    }
}
