using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiASP.NET.Models
{
    public class Cart
    {
        public long productID { get; set; }
        public int quantity { get; set; }
        public SanPham productDetail { get; set; }

    }
}