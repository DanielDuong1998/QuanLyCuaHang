//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyCuaHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            this.HOADONs = new HashSet<HOADON>();
        }

        public TAIKHOAN(string tENDANGNHAP, string mATKHAU, string qUYEN, string hOTEN)
        {
            TENDANGNHAP = tENDANGNHAP;
            MATKHAU = mATKHAU;
            QUYEN = qUYEN;
            HOTEN = hOTEN;
        }

        public string TENDANGNHAP { get; set; }
        public string HOTEN { get; set; }
        public string MATKHAU { get; set; }
        public string QUYEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
