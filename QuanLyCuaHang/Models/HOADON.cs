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
    
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            this.CTHDs = new HashSet<CTHD>();
        }
    public HOADON(DateTime date, int maban,string time)
        {
            IDHOADON = 0;
            NGAYLAP = date;
            MABAN = maban;
            TRANGTHAIHOADON = 0;
            INHOADON = 0;
            GIOLAP=time;
        }
        public int IDHOADON { get; set; }
        public Nullable<System.DateTime> NGAYLAP { get; set; }
        public Nullable<double> TONGTIEN { get; set; }
        public Nullable<int> MABAN { get; set; }
        public Nullable<int> TRANGTHAIHOADON { get; set; }
        public Nullable<int> INHOADON { get; set; }
        public string GIOLAP { get; set; }
        public string IDNHANVIEN { get; set; }
    
        public virtual BAN BAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
