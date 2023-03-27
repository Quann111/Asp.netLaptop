using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiASP.NET.Models
{
    public class HomeModel
    {
        public List<SanPham> ListSanpham { get; set; }
        public List<DanhMucSP> ListDM  { get; set; }
    }
}