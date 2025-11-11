using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class DanhGiaKhoaHoc
{
    public int Id { get; set; }

    public int? IdHocVien { get; set; }

    public int? IdKhoaHoc { get; set; }

    public int? DiemDanhGia { get; set; }

    public string? BinhLuan { get; set; }

    public DateTime? NgayDanhGia { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public bool? TrangThai { get; set; }

    public virtual NguoiDung? IdHocVienNavigation { get; set; }

    public virtual KhoaHoc? IdKhoaHocNavigation { get; set; }
}
