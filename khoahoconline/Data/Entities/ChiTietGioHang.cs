using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class ChiTietGioHang
{
    public int Id { get; set; }

    public int? IdGioHang { get; set; }

    public int? IdKhoaHoc { get; set; }

    public virtual GioHang? IdGioHangNavigation { get; set; }

    public virtual KhoaHoc? IdKhoaHocNavigation { get; set; }
}
