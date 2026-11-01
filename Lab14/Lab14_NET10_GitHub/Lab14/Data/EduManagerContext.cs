using Lab14.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab14.Data;

public class EduManagerContext : DbContext
{
    public EduManagerContext(DbContextOptions<EduManagerContext> options) : base(options)
    {
    }

    public DbSet<MonHoc> MonHocs => Set<MonHoc>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.ToTable("MONHOC", table =>
                table.HasCheckConstraint("CK_MONHOC_SoTinChi", "[SoTinChi] BETWEEN 1 AND 6"));

            entity.HasKey(x => x.MaMonHoc);
            entity.Property(x => x.MaMonHoc).HasMaxLength(10).IsRequired();
            entity.Property(x => x.TenMonHoc).HasMaxLength(100).IsRequired();
            entity.Property(x => x.TrangThai).HasDefaultValue(true);
        });
    }
}
