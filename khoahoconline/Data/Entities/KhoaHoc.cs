using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class KhoaHoc
{
    public int Id { get; set; }

    public string? TenKhoaHoc { get; set; }

    public string? MoTaNgan { get; set; }

    public string? MoTaChiTiet { get; set; }

    public int? IdDanhMuc { get; set; }

    public int? IdGiangVien { get; set; }

    public string? YeuCauTruoc { get; set; }

    public string? HocDuoc { get; set; }

    public decimal? GiaBan { get; set; }

    public string? HinhDaiDien { get; set; }

    public string? VideoGioiThieu { get; set; }

    public string? MucDo { get; set; }

    public bool? TrangThai { get; set; }

    public int? SoLuongHocVien { get; set; }

    public decimal? DiemDanhGia { get; set; }

    public int? SoLuongDanhGia { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();

    public virtual ICollection<ChiaSeLuanNhuan> ChiaSeLuanNhuans { get; set; } = new List<ChiaSeLuanNhuan>();

    public virtual ICollection<Chuong> Chuongs { get; set; } = new List<Chuong>();

    public virtual ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; } = new List<DangKyKhoaHoc>();

    public virtual ICollection<DanhGiaKhoaHoc> DanhGiaKhoaHocs { get; set; } = new List<DanhGiaKhoaHoc>();

    public virtual DanhMucKhoaHoc? IdDanhMucNavigation { get; set; }

    public virtual NguoiDung? IdGiangVienNavigation { get; set; }

    public virtual ICollection<TaiLieuKhoaHoc> TaiLieuKhoaHocs { get; set; } = new List<TaiLieuKhoaHoc>();

    public virtual ICollection<TienDoHocTap> TienDoHocTaps { get; set; } = new List<TienDoHocTap>();
}
