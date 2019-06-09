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
            /* int parameter = 4;
             string[] name = new string[parameter];
             object[] values = new object[parameter];
             name[0] = "@tentaikhoan";
             name[1] = "@matkhau";
             name[2] = "@quyen";
             name[3] = "@hoten";
             values[0] = tk_md.TENDANGNHAP;
             values[1] = tk_md.MATKHAU;
             values[2] = tk_md.QUYEN;
             values[3] = tk_md.HOTEN;
             return Execute("sp_themtaikhoan", name, values, parameter);*/
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
            /*(int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tentaikhoan";
            values[0] = tk_md.TENDANGNHAP;
            return Execute("sp_xoataikhoan", name, values, parameter);*/
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
            /*int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tentaikhoan";
            values[0] = tk_md.TENDANGNHAP;
            return Execute("sp_resetmatkhau", name, values, parameter);*/
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
            /*int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tendangnhap";
            values[0] = tk_md.TENDANGNHAP;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_kiemtradangnhap", name, values, parameter));
            return JsonConvert.DeserializeObject<List<TaiKhoanModels>>(json);*/
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
