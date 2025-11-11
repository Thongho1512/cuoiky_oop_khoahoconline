using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class VaiTro
{
    public int Id { get; set; }

    public string? TenVaiTro { get; set; }

    public string? MoTa { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<NguoiDungVaiTro> NguoiDungVaiTros { get; set; } = new List<NguoiDungVaiTro>();
}
