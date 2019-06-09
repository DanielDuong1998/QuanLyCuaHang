using QuanLyCuaHang.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Dal
{
    public class ThongKeDal 
    {
        WPF_DatabaseEntities db = new WPF_DatabaseEntities();
        public List<ThongKeModels> sp_thongkemontheongay(int ngay)
        {

            var query = from hd in db.HOADONs
                        join cthd in db.CTHDs on hd.IDHOADON equals cthd.IDHOADON
                        join td in db.THUCDONs on cthd.MATHUCDON equals td.MATHUCDON
                        where hd.TRANGTHAIHOADON == 1 && hd.NGAYLAP.Value.Year.ToString() == (DateTime.Now.Year.ToString()) && hd.NGAYLAP.Value.Month.ToString() == (DateTime.Now.Month.ToString()) && hd.NGAYLAP.Value.Day == ngay
                        select new {td.TENTHUCDON,cthd.SOLUONG,td.DONGIA,cthd.GIAMGIA} into x
                        group x by new { x.TENTHUCDON, x.DONGIA } into newgroup
                        orderby  newgroup.Key
                        select new { TENTHUCDON=newgroup.Key.TENTHUCDON,SOLUONG=newgroup.Sum(i=>i.SOLUONG),TongTien=newgroup.Sum((i=>i.DONGIA*((100-(double)i.GIAMGIA)/100)*i.SOLUONG)) };
            List<ThongKeModels> list = new List<ThongKeModels>();
            foreach(var i in query)
            {
                ThongKeModels t = new ThongKeModels(i.TENTHUCDON, i.SOLUONG, i.TongTien);
                list.Add(t);
            }
            return list;
                       
        }
        public List<ThongKeModels> sp_thongkemontheothang(int thang)
        {
           
            var query = from hd in db.HOADONs
                        join cthd in db.CTHDs on hd.IDHOADON equals cthd.IDHOADON
                        join td in db.THUCDONs on cthd.MATHUCDON equals td.MATHUCDON
                        where hd.TRANGTHAIHOADON == 1 && hd.NGAYLAP.Value.Year.ToString() == (DateTime.Now.Year.ToString()) && hd.NGAYLAP.Value.Month == thang
                        select new { td.TENTHUCDON, cthd.SOLUONG, td.DONGIA, cthd.GIAMGIA } into x
                        group x by new { x.TENTHUCDON, x.DONGIA } into newgroup
                        orderby newgroup.Key
                        select new { TENTHUCDON = newgroup.Key.TENTHUCDON, SOLUONG = newgroup.Sum(i => i.SOLUONG), TongTien = newgroup.Sum((i => i.DONGIA * ((100 - (double)i.GIAMGIA) / 100) * i.SOLUONG)) };
            List<ThongKeModels> list = new List<ThongKeModels>();
            foreach (var i in query)
            {
                ThongKeModels t = new ThongKeModels(i.TENTHUCDON, i.SOLUONG, i.TongTien);
                list.Add(t);
            }
            return list;
        }
        public List<ThongKeModels> sp_thongkemontheonam(object nam)
        {
            var query = from hd in db.HOADONs
                        join cthd in db.CTHDs on hd.IDHOADON equals cthd.IDHOADON
                        join td in db.THUCDONs on cthd.MATHUCDON equals td.MATHUCDON
                        where hd.TRANGTHAIHOADON == 1 && hd.NGAYLAP.Value.Equals(nam)
                        select new { td.TENTHUCDON, cthd.SOLUONG, td.DONGIA, cthd.GIAMGIA } into x
                        group x by new { x.TENTHUCDON, x.DONGIA } into newgroup
                        orderby newgroup.Key
                        select new { TENTHUCDON = newgroup.Key.TENTHUCDON, SOLUONG = newgroup.Sum(i => i.SOLUONG), TongTien = newgroup.Sum((i => i.DONGIA * ((100 - (double)i.GIAMGIA) / 100) * i.SOLUONG)) };
            List<ThongKeModels> list = new List<ThongKeModels>();
            foreach (var i in query)
            {
                ThongKeModels t = new ThongKeModels(i.TENTHUCDON, i.SOLUONG, i.TongTien);
                list.Add(t);
            }
            return list;
        }
        // Doanh thu
        public List<ThongKeModels> sp_doanhthutheongay(int ngay)
        {

            
            var query = from hd in db.HOADONs
                        join ban in db.BANs on hd.MABAN equals ban.MABAN
                        join kv in db.KHUVUCs on ban.MAKHUVUC equals kv.MAKHUVUC
                        where hd.TRANGTHAIHOADON == 1 && hd.NGAYLAP.Value.Year.Equals(DateTime.Now.Year) && hd.NGAYLAP.Value.Month.Equals(DateTime.Now.Month) && hd.NGAYLAP.Value.Day.Equals(ngay)
                        select new { kv.TENKHUVUC, ban.TENBAN, hd.TONGTIEN, hd.NGAYLAP, hd.GIOLAP, hd.IDHOADON };
            List<ThongKeModels> list = new List<ThongKeModels>();
            foreach (var i in query)
            {
                ThongKeModels t = new ThongKeModels(i.TENKHUVUC, i.TENBAN, i.TONGTIEN,i.NGAYLAP,i.GIOLAP,i.IDHOADON);
                list.Add(t);
            }
            return list;
        }
        public List<ThongKeModels> sp_danhthutheothang(int thang)
        {
            
            var query = from hd in db.HOADONs
                        join ban in db.BANs on hd.MABAN equals ban.MABAN
                        join kv in db.KHUVUCs on ban.MAKHUVUC equals kv.MAKHUVUC
                        where hd.TRANGTHAIHOADON == 1 && hd.NGAYLAP.Value.Year.Equals(DateTime.Now.Year) && hd.NGAYLAP.Value.Month.Equals(thang) 
                        select new { kv.TENKHUVUC, ban.TENBAN, hd.TONGTIEN, hd.NGAYLAP, hd.GIOLAP, hd.IDHOADON };
            List<ThongKeModels> list = new List<ThongKeModels>();
            foreach (var i in query)
            {
                ThongKeModels t = new ThongKeModels(i.TENKHUVUC, i.TENBAN, i.TONGTIEN, i.NGAYLAP, i.GIOLAP, i.IDHOADON);
                list.Add(t);
            }
            return list;
        }
        public List<ThongKeModels> sp_doanhthutheonam(object nam)
        {
            var query = from hd in db.HOADONs
                        join ban in db.BANs on hd.MABAN equals ban.MABAN
                        join kv in db.KHUVUCs on ban.MAKHUVUC equals kv.MAKHUVUC
                        where hd.TRANGTHAIHOADON == 1 && hd.NGAYLAP.Value.Equals(nam) 
                        select new { kv.TENKHUVUC, ban.TENBAN, hd.TONGTIEN, hd.NGAYLAP, hd.GIOLAP, hd.IDHOADON };
            List<ThongKeModels> list = new List<ThongKeModels>();
            foreach (var i in query)
            {
                ThongKeModels t = new ThongKeModels(i.TENKHUVUC, i.TENBAN, i.TONGTIEN, i.NGAYLAP, i.GIOLAP, i.IDHOADON);
                list.Add(t);
            }
            return list;
        }
        public List<ThongKeModels> sp_loaddanhsachthucdoncuaban_thongke(int MAHOADON)
        {
           
            var query = from hd in db.HOADONs
                        join cthd in db.CTHDs on hd.IDHOADON equals cthd.IDHOADON
                        join td in db.THUCDONs on cthd.MATHUCDON equals td.MATHUCDON
                        where hd.IDHOADON == MAHOADON
                        select new { td.TENTHUCDON, DONGIA = td.DONGIA * ((100 - (double)cthd.GIAMGIA)) / 100, cthd.SOLUONG, td.MATHUCDON, cthd.GIAMGIA };
            List<ThongKeModels> list = new List<ThongKeModels>();
            foreach (var i in query)
            {
                ThongKeModels t = new ThongKeModels(i.TENTHUCDON, i.DONGIA, i.SOLUONG, i.MATHUCDON, i.GIAMGIA);
                list.Add(t);
            }
            return list;
        }
    }
}
