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
    
    public partial class CTHD
    {
        public CTHD(int idhoadon, int mathucdon, int soluong, int giamgia)
        {
            IDHOADON = idhoadon;
            MATHUCDON = mathucdon;
            SOLUONG = soluong;
            GIAMGIA = giamgia;
        }

        public int IDCTHD { get; set; }
        public Nullable<int> IDHOADON { get; set; }
        public Nullable<int> MATHUCDON { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<int> GIAMGIA { get; set; }
    
        public virtual HOADON HOADON { get; set; }
        public virtual THUCDON THUCDON { get; set; }
    }
}
