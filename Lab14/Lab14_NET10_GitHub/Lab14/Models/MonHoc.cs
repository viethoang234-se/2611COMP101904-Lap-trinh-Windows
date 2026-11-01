using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab14.Models;

[Table("MONHOC")]
public class MonHoc
{
    [Key]
    [StringLength(10)]
    [Column(TypeName = "nvarchar(10)")]
    public string MaMonHoc { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string TenMonHoc { get; set; } = string.Empty;

    public int SoTinChi { get; set; }

    public bool TrangThai { get; set; } = true;
}
