using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class TienDoHocTap
{
    public int Id { get; set; }

    public int? IdDangKy { get; set; }

    public int? IdKhoaHoc { get; set; }

    public decimal? PhanTramHoanThanh { get; set; }

    public bool? DaHoanThanh { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    public virtual DangKyKhoaHoc? IdDangKyNavigation { get; set; }

    public virtual KhoaHoc? IdKhoaHocNavigation { get; set; }
}
