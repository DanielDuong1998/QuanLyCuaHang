using QuanLyCuaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVVM.Dal
{
    public class TaiKhoanDal 
    {
        WPF_DatabaseEntities db = new WPF_DatabaseEntities();
        public List<TAIKHOAN> sp_loadtaikhoan()
        {
            /*string json = JsonConvert.SerializeObject(LoadData("sp_loadtaikhoan"));
            return JsonConvert.DeserializeObject<List<TaiKhoanModels>>(json);*/
            return db.TAIKHOANs.ToList();
        }
        public bool sp_themtaikhoan(TAIKHOAN tk_md)
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
                db.TAIKHOANs.Add(tk_md);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_xoataikhoan(TAIKHOAN tk_md)
        {
            /*(int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tentaikhoan";
            values[0] = tk_md.TENDANGNHAP;
            return Execute("sp_xoataikhoan", name, values, parameter);*/
            try
            {

                db.TAIKHOANs.Remove(tk_md);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_resetmatkhau(TAIKHOAN tk_md)
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
        public List<TAIKHOAN> sp_kiemtradangnhap(TAIKHOAN tk_md)
        {
            /*int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tendangnhap";
            values[0] = tk_md.TENDANGNHAP;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_kiemtradangnhap", name, values, parameter));
            return JsonConvert.DeserializeObject<List<TaiKhoanModels>>(json);*/
            return db.TAIKHOANs.Where(x => x.TENDANGNHAP == tk_md.TENDANGNHAP).ToList();
        }
    }
}
