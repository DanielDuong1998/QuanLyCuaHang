using QuanLyCuaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVVM.Dal
{
    public class TaiKhoanDal 
    {
        WPF_DatabaseEntities db = new WPF_DatabaseEntities();
        public List<TaiKhoanModels> sp_loadtaikhoan()
        {
            /*string json = JsonConvert.SerializeObject(LoadData("sp_loadtaikhoan"));
            return JsonConvert.DeserializeObject<List<TaiKhoanModels>>(json);*/
            List<TaiKhoanModels> list = new List<TaiKhoanModels>();
            foreach(var i in db.TAIKHOANs.ToList())
            {
                TaiKhoanModels t = new TaiKhoanModels(i.TENDANGNHAP, i.MATKHAU, i.QUYEN, i.HOTEN);
                list.Add(t);
            }
            return list;
        }
        public bool sp_themtaikhoan(TaiKhoanModels tk_md)
        {
            
            try
            {
                TAIKHOAN t = new TAIKHOAN(tk_md.TENDANGNHAP, tk_md.MATKHAU, tk_md.QUYEN, tk_md.HOTEN);
                db.TAIKHOANs.Add(t);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_xoataikhoan(TaiKhoanModels tk_md)
        {
            
            try
            {
                TAIKHOAN t = new TAIKHOAN(tk_md.TENDANGNHAP, tk_md.MATKHAU, tk_md.QUYEN, tk_md.HOTEN);
                db.TAIKHOANs.Remove(t);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_resetmatkhau(TaiKhoanModels tk_md)
        {
            
            try
            {
                var temp=db.TAIKHOANs.Find(tk_md.TENDANGNHAP);
                temp.MATKHAU = "202cb962ac59075b964b07152d234b70";
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public List<TaiKhoanModels> sp_kiemtradangnhap(TaiKhoanModels tk_md)
        {
            
            var query=db.TAIKHOANs.Where(x => x.TENDANGNHAP == tk_md.TENDANGNHAP).ToList();
            List<TaiKhoanModels> list = new List<TaiKhoanModels>();
            foreach(var i in query)
            {
                TaiKhoanModels t = new TaiKhoanModels(i.TENDANGNHAP,i.MATKHAU,i.QUYEN,i.HOTEN);
                list.Add(t);

            }
            return list;
        }
    }
}
