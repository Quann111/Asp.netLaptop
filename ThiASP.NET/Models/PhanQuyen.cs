//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThiASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhanQuyen
    {
        public int idNhanvien { get; set; }
        public int idChucnang { get; set; }
        public string ghichu { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Chucnang Chucnang { get; set; }
    }
}
