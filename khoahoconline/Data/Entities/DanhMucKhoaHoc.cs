using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class DanhMucKhoaHoc
{
    public int Id { get; set; }

    public string? TenDanhMuc { get; set; }

    public string? MoTa { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<KhoaHoc> KhoaHocs { get; set; } = new List<KhoaHoc>();
}
