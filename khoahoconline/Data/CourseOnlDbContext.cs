using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using khoahoconline.Data.Entities;

namespace khoahoconline.Data;

public partial class CourseOnlDbContext : DbContext
{
    public CourseOnlDbContext()
    {
    }

    public CourseOnlDbContext(DbContextOptions<CourseOnlDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiGiang> BaiGiangs { get; set; }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

    public virtual DbSet<ChiaSeLuanNhuan> ChiaSeLuanNhuans { get; set; }

    public virtual DbSet<Chuong> Chuongs { get; set; }

    public virtual DbSet<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }

    public virtual DbSet<DanhGiaKhoaHoc> DanhGiaKhoaHocs { get; set; }

    public virtual DbSet<DanhMucKhoaHoc> DanhMucKhoaHocs { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NguoiDungVaiTro> NguoiDungVaiTros { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<TaiLieuKhoaHoc> TaiLieuKhoaHocs { get; set; }

    public virtual DbSet<TienDoHocTap> TienDoHocTaps { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-170JDGQ;Database=cuoikyoopQuanLyKhoaHocTrucTuyen;User Id=sa;Password=thaithong123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiGiang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BaiGiang__3214EC073A841DDB");

            entity.ToTable("BaiGiang");

            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TieuDe).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
            entity.Property(e => e.VideoUrl).HasMaxLength(500);
            entity.Property(e => e.XemThuMienPhi).HasDefaultValue(false);

            entity.HasOne(d => d.IdChuongNavigation).WithMany(p => p.BaiGiangs)
                .HasForeignKey(d => d.IdChuong)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__BaiGiang__IdChuo__0E6E26BF");
        });

        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiTietD__3214EC073DF51077");

            entity.ToTable("ChiTietDonHang");

            entity.HasOne(d => d.IdDonHangNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.IdDonHang)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ChiTietDo__IdDon__151B244E");

            entity.HasOne(d => d.IdKhoaHocNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.IdKhoaHoc)
                .HasConstraintName("FK__ChiTietDo__IdKho__160F4887");
        });

        modelBuilder.Entity<ChiTietGioHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiTietG__3214EC0706F5A862");

            entity.ToTable("ChiTietGioHang");

            entity.HasIndex(e => new { e.IdGioHang, e.IdKhoaHoc }, "UQ_GioHang_KhoaHoc").IsUnique();

            entity.HasOne(d => d.IdGioHangNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.IdGioHang)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ChiTietGi__IdGio__114A936A");

            entity.HasOne(d => d.IdKhoaHocNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.IdKhoaHoc)
                .HasConstraintName("FK__ChiTietGi__IdKho__123EB7A3");
        });

        modelBuilder.Entity<ChiaSeLuanNhuan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiaSeLu__3214EC0793E84648");

            entity.ToTable("ChiaSeLuanNhuan");

            entity.Property(e => e.DoanhThu).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienGiangVien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienHeThong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThaiThanhToan).HasDefaultValue(false);
            entity.Property(e => e.TyLeChiaGiangVien)
                .HasDefaultValue(70m)
                .HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdDonHangNavigation).WithMany(p => p.ChiaSeLuanNhuans)
                .HasForeignKey(d => d.IdDonHang)
                .HasConstraintName("FK__ChiaSeLua__IdDon__1DB06A4F");

            entity.HasOne(d => d.IdGiangVienNavigation).WithMany(p => p.ChiaSeLuanNhuans)
                .HasForeignKey(d => d.IdGiangVien)
                .HasConstraintName("FK__ChiaSeLua__IdGia__1EA48E88");

            entity.HasOne(d => d.IdKhoaHocNavigation).WithMany(p => p.ChiaSeLuanNhuans)
                .HasForeignKey(d => d.IdKhoaHoc)
                .HasConstraintName("FK__ChiaSeLua__IdKho__1F98B2C1");
        });

        modelBuilder.Entity<Chuong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chuong__3214EC07947CFED9");

            entity.ToTable("Chuong");

            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenChuong).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.IdKhoaHocNavigation).WithMany(p => p.Chuongs)
                .HasForeignKey(d => d.IdKhoaHoc)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Chuong__IdKhoaHo__0D7A0286");
        });

        modelBuilder.Entity<DangKyKhoaHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DangKyKh__3214EC077426BFDD");

            entity.ToTable("DangKyKhoaHoc");

            entity.HasIndex(e => new { e.IdHocVien, e.IdKhoaHoc }, "UQ_HocVien_KhoaHoc").IsUnique();

            entity.Property(e => e.NgayDangKy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdDonHangNavigation).WithMany(p => p.DangKyKhoaHocs)
                .HasForeignKey(d => d.IdDonHang)
                .HasConstraintName("FK__DangKyKho__IdDon__18EBB532");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.DangKyKhoaHocs)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK__DangKyKho__IdHoc__17036CC0");

            entity.HasOne(d => d.IdKhoaHocNavigation).WithMany(p => p.DangKyKhoaHocs)
                .HasForeignKey(d => d.IdKhoaHoc)
                .HasConstraintName("FK__DangKyKho__IdKho__17F790F9");
        });

        modelBuilder.Entity<DanhGiaKhoaHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DanhGiaK__3214EC072DF52A36");

            entity.ToTable("DanhGiaKhoaHoc");

            entity.HasIndex(e => new { e.IdHocVien, e.IdKhoaHoc }, "UQ_HocVien_DanhGia_KhoaHoc").IsUnique();

            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayDanhGia)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.DanhGiaKhoaHocs)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK__DanhGiaKh__IdHoc__1BC821DD");

            entity.HasOne(d => d.IdKhoaHocNavigation).WithMany(p => p.DanhGiaKhoaHocs)
                .HasForeignKey(d => d.IdKhoaHoc)
                .HasConstraintName("FK__DanhGiaKh__IdKho__1CBC4616");
        });

        modelBuilder.Entity<DanhMucKhoaHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DanhMucK__3214EC079993E495");

            entity.ToTable("DanhMucKhoaHoc");

            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenDanhMuc).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DonHang__3214EC071C10CB22");

            entity.ToTable("DonHang");

            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.NgayThanhToan)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.TienGiam)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongTienGoc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongTienThanhToan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(50);

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK__DonHang__IdHocVi__1332DBDC");

            entity.HasOne(d => d.IdVoucherNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.IdVoucher)
                .HasConstraintName("FK__DonHang__IdVouch__14270015");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GioHang__3214EC07E2C1B5AD");

            entity.ToTable("GioHang");

            entity.HasIndex(e => e.IdHocVien, "UQ_GioHang_HocVien").IsUnique();

            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhanTramGiam)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SoLuongKhoaHoc).HasDefaultValue(0);
            entity.Property(e => e.TienGiamVoucher)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongTienGoc)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongTienThanhToan)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdHocVienNavigation).WithOne(p => p.GioHang)
                .HasForeignKey<GioHang>(d => d.IdHocVien)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__GioHang__IdHocVi__10566F31");
        });

        modelBuilder.Entity<KhoaHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KhoaHoc__3214EC074A73C42A");

            entity.ToTable("KhoaHoc");

            entity.Property(e => e.DiemDanhGia)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)");
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HinhDaiDien).HasMaxLength(500);
            entity.Property(e => e.MoTaNgan).HasMaxLength(500);
            entity.Property(e => e.MucDo).HasMaxLength(50);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoLuongDanhGia).HasDefaultValue(0);
            entity.Property(e => e.SoLuongHocVien).HasDefaultValue(0);
            entity.Property(e => e.TenKhoaHoc).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
            entity.Property(e => e.VideoGioiThieu).HasMaxLength(500);

            entity.HasOne(d => d.IdDanhMucNavigation).WithMany(p => p.KhoaHocs)
                .HasForeignKey(d => d.IdDanhMuc)
                .HasConstraintName("FK__KhoaHoc__IdDanhM__0B91BA14");

            entity.HasOne(d => d.IdGiangVienNavigation).WithMany(p => p.KhoaHocs)
                .HasForeignKey(d => d.IdGiangVien)
                .HasConstraintName("FK__KhoaHoc__IdGiang__0C85DE4D");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NguoiDun__3214EC0754CAC50F");

            entity.ToTable("NguoiDung");

            entity.HasIndex(e => e.Email, "UQ__NguoiDun__A9D105347E3305B8").IsUnique();

            entity.Property(e => e.AnhDaiDien).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.LanDangNhapCuoi).HasColumnType("datetime");
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<NguoiDungVaiTro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NguoiDun__3214EC075BE20E53");

            entity.ToTable("NguoiDung_VaiTro");

            entity.HasIndex(e => new { e.IdNguoiDung, e.IdVaiTro }, "UQ_NguoiDung_VaiTro").IsUnique();

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.NguoiDungVaiTros)
                .HasForeignKey(d => d.IdNguoiDung)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__NguoiDung__IdNgu__08B54D69");

            entity.HasOne(d => d.IdVaiTroNavigation).WithMany(p => p.NguoiDungVaiTros)
                .HasForeignKey(d => d.IdVaiTro)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__NguoiDung__IdVai__09A971A2");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RefreshT__3214EC0728A7D8E8");

            entity.ToTable("RefreshToken");

            entity.Property(e => e.NgayHetHan).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayThuHoi).HasColumnType("datetime");
            entity.Property(e => e.Token).HasMaxLength(500);

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.IdNguoiDung)
                .HasConstraintName("FK__RefreshTo__IdNgu__0A9D95DB");
        });

        modelBuilder.Entity<TaiLieuKhoaHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiLieuK__3214EC0720F45B66");

            entity.ToTable("TaiLieuKhoaHoc");

            entity.Property(e => e.DuongDan).HasMaxLength(500);
            entity.Property(e => e.LoaiTaiLieu).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenTaiLieu).HasMaxLength(255);
            entity.Property(e => e.ThuTu).HasDefaultValue(0);

            entity.HasOne(d => d.IdKhoaHocNavigation).WithMany(p => p.TaiLieuKhoaHocs)
                .HasForeignKey(d => d.IdKhoaHoc)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TaiLieuKh__IdKho__0F624AF8");
        });

        modelBuilder.Entity<TienDoHocTap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TienDoHo__3214EC07BA4530D2");

            entity.ToTable("TienDoHocTap");

            entity.HasIndex(e => new { e.IdDangKy, e.IdKhoaHoc }, "UQ_DangKy_KhoaHoc").IsUnique();

            entity.Property(e => e.DaHoanThanh).HasDefaultValue(false);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayHoanThanh).HasColumnType("datetime");
            entity.Property(e => e.PhanTramHoanThanh)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdDangKyNavigation).WithMany(p => p.TienDoHocTaps)
                .HasForeignKey(d => d.IdDangKy)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TienDoHoc__IdDan__19DFD96B");

            entity.HasOne(d => d.IdKhoaHocNavigation).WithMany(p => p.TienDoHocTaps)
                .HasForeignKey(d => d.IdKhoaHoc)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TienDoHoc__IdKho__1AD3FDA4");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VaiTro__3214EC07B753A7CA");

            entity.ToTable("VaiTro");

            entity.HasIndex(e => e.TenVaiTro, "UQ__VaiTro__1DA55814EC4C21BC").IsUnique();

            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenVaiTro).HasMaxLength(50);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voucher__3214EC07DCA91D50");

            entity.ToTable("Voucher");

            entity.HasIndex(e => e.MaCode, "UQ__Voucher__152C7C5C4EECE760").IsUnique();

            entity.Property(e => e.MaCode).HasMaxLength(50);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayHetHan).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TiLeGiam).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
