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
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }
    
        public int MaSP { get; set; }
        public Nullable<int> MaDM { get; set; }
        public string TenSP { get; set; }
        public string AnhSP { get; set; }
        public int GiaSP { get; set; }
        public bool TrangThai { get; set; }
        public bool BestSeller { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime NgaySua { get; set; }
        public string MotaSP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DanhMucSP DanhMucSP { get; set; }
        public virtual DonHang DonHang { get; set; }
    }
}