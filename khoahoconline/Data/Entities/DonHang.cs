using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class DonHang
{
    public int Id { get; set; }

    public int? IdHocVien { get; set; }

    public int? IdVoucher { get; set; }

    public decimal? TongTienGoc { get; set; }

    public decimal? TienGiam { get; set; }

    public decimal? TongTienThanhToan { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public string? TrangThaiThanhToan { get; set; }

    public DateTime? NgayThanhToan { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ICollection<ChiaSeLuanNhuan> ChiaSeLuanNhuans { get; set; } = new List<ChiaSeLuanNhuan>();

    public virtual ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; } = new List<DangKyKhoaHoc>();

    public virtual NguoiDung? IdHocVienNavigation { get; set; }

    public virtual Voucher? IdVoucherNavigation { get; set; }
}
