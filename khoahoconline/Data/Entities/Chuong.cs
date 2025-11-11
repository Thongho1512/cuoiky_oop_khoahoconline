using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class Chuong
{
    public int Id { get; set; }

    public int? IdKhoaHoc { get; set; }

    public string? TenChuong { get; set; }

    public string? MoTa { get; set; }

    public int? ThuTu { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<BaiGiang> BaiGiangs { get; set; } = new List<BaiGiang>();

    public virtual KhoaHoc? IdKhoaHocNavigation { get; set; }
}
