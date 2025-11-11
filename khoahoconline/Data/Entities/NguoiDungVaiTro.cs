using System;
using System.Collections.Generic;

namespace khoahoconline.Data.Entities;

public partial class NguoiDungVaiTro
{
    public int Id { get; set; }

    public int? IdNguoiDung { get; set; }

    public int? IdVaiTro { get; set; }

    public virtual NguoiDung? IdNguoiDungNavigation { get; set; }

    public virtual VaiTro? IdVaiTroNavigation { get; set; }
}
