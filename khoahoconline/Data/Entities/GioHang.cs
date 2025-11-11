using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class GioHang
{
    public int Id { get; set; }

    public int? IdHocVien { get; set; }

    public decimal? TongTienGoc { get; set; }

    public decimal? PhanTramGiam { get; set; }

    public decimal? TienGiamVoucher { get; set; }

    public decimal? TongTienThanhToan { get; set; }

    public int? SoLuongKhoaHoc { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();

    public virtual NguoiDung? IdHocVienNavigation { get; set; }
}
