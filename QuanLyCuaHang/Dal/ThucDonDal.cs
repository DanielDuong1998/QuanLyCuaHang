using QuanLyCuaHang.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang.Dal
{
    public class ThucDonDal 
    {
        WPF_DatabaseEntities db = new WPF_DatabaseEntities();
        public List<ThucDonModels> sp_danhmucloadthucdon()
        {
            List<ThucDonModels> list = new List<ThucDonModels>();
            foreach(var i in db.DANHMUCTHUCDONs.ToList())
            {
                ThucDonModels t = new ThucDonModels(i.MADM,i.TENDM);
                list.Add(t);
            }
            return list;
        }
        public List<ThucDonModels> sp_loadthucdon(int madm)
        {
           
                var query = from td in db.THUCDONs
                            where td.MADM == madm
                            select new { td.MATHUCDON, td.TENTHUCDON,td.DONGIA,td.GIAMGIA };
            List<ThucDonModels> list = new List<ThucDonModels>();
            foreach (var i in query)
            {
                ThucDonModels t = new ThucDonModels(i.MATHUCDON, i.TENTHUCDON,i.DONGIA,i.GIAMGIA);
                list.Add(t);
            }
            return list;
        }
        public bool sp_themdanhmucthucdon(string tendanhmuc)
        {
            try
            {
                DANHMUCTHUCDON t = new DANHMUCTHUCDON(tendanhmuc);
                db.DANHMUCTHUCDONs.Add(t);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_xoadanhmucthucdon(int madanhmuc)
        {
            try
            {

                var dm = db.DANHMUCTHUCDONs.Find(madanhmuc);
                db.DANHMUCTHUCDONs.Remove(dm);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;

            }
            return true;
        }
        public bool sp_themthucdon(string tenthucdon, double dongia, int madanhmuc)
        {
            try
            {
                THUCDON t = new THUCDON(tenthucdon, dongia, madanhmuc);
                db.THUCDONs.Add(t);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_xoathucdon(int mathucdon)
        {
            try
            {
                var td = db.THUCDONs.Find(mathucdon);
                db.THUCDONs.Remove(td);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_themgiamgia(int mathucdon, int giamgia)
        {
            try
            {
                var gg = db.THUCDONs.Find(mathucdon);
                gg.GIAMGIA = giamgia;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_xoagiamgia(int mathucdon)
        {
            try
            {
                var gg = db.THUCDONs.Find(mathucdon);
                gg.GIAMGIA = 0;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_suagiathucdon(int mathucdon, double dongia)
        {
            try
            {
                var gtd = db.THUCDONs.Find(mathucdon);
                gtd.DONGIA = dongia;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
