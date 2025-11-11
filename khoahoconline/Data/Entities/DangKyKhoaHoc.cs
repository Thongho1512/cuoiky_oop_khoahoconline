using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class DangKyKhoaHoc
{
    public int Id { get; set; }

    public int? IdHocVien { get; set; }

    public int? IdKhoaHoc { get; set; }

    public int? IdDonHang { get; set; }

    public DateTime? NgayDangKy { get; set; }

    public virtual DonHang? IdDonHangNavigation { get; set; }

    public virtual NguoiDung? IdHocVienNavigation { get; set; }

    public virtual KhoaHoc? IdKhoaHocNavigation { get; set; }

    public virtual ICollection<TienDoHocTap> TienDoHocTaps { get; set; } = new List<TienDoHocTap>();
}
