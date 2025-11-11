using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class RefreshToken
{
    public int Id { get; set; }

    public int? IdNguoiDung { get; set; }

    public string? Token { get; set; }

    public DateTime? NgayHetHan { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayThuHoi { get; set; }

    public virtual NguoiDung? IdNguoiDungNavigation { get; set; }
}
