using QuanLyCuaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace QuanLyCuaHang.Dal
{
    public class KhuVucBanDal
    {
        WPF_DatabaseEntities db = new WPF_DatabaseEntities();
        public List<KhuVucBanModels> sp_loadkhuvuc()
        {
            List<KhuVucBanModels> kv = new List<KhuVucBanModels>();
            foreach(var i in db.KHUVUCs.ToList())
            {
                KhuVucBanModels t = new KhuVucBanModels(i.MAKHUVUC, i.TENKHUVUC);
                kv.Add(t);
            }
            

            return kv;
        }
        public List<BAN> sp_loadbantheokhuvuc(int makhuvuc)
        {
            List<BAN> kv = new List<BAN>();
            kv = db.BANs.Where(x => x.MAKHUVUC == makhuvuc).ToList();
            return kv;
        }
        public List<KhuVucBanModels> sp_loadkhuvuc_danhmuc()
        {
            List<KhuVucBanModels> kv = new List<KhuVucBanModels>();
            var query = from b in db.BANs
                        group b by b.MAKHUVUC into g
                        select new
                        {
                            MAKHUVUC = g.Key,
                            SLBAN = g.Count()
                        };



            var t = from p in query
                    join kvs in db.KHUVUCs on p.MAKHUVUC equals kvs.MAKHUVUC
                    select new {p.MAKHUVUC,kvs.TENKHUVUC,p.SLBAN};
            var ds = t.ToList();
            foreach(var i in ds){
                KhuVucBanModels k = new KhuVucBanModels(i.MAKHUVUC,i.TENKHUVUC,i.SLBAN);
                kv.Add(k);
            }
            
            return kv;
        }
        public bool sp_themkhuvuc(string tenkhuvuc)
        {
          
            KHUVUC t = new KHUVUC();
            t.TENKHUVUC = tenkhuvuc;
            db.KHUVUCs.Add(t);
            db.SaveChanges();
            return true;
        }
        public bool sp_xoakhuvuc(int makhuvuc)
        {
           
            try
            {
                var query = db.BANs.Where(x => x.MAKHUVUC == makhuvuc);
                foreach (var i in query)
                {
                    db.BANs.Remove(i);
                }
                var kv = db.KHUVUCs.Find(makhuvuc);
                db.KHUVUCs.Remove(kv);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public List<KhuVucBanModels> sp_bandanhmuc(int makhuvuc)
        {
            
            List<KhuVucBanModels> list = new List<KhuVucBanModels>();
            var query = from ban in db.BANs
                        where ban.MAKHUVUC == makhuvuc
                        orderby ban.MABAN
                        select new { ban.MABAN, ban.TENBAN };
            foreach(var i in query)
            {
                KhuVucBanModels t = new KhuVucBanModels(i.MABAN, i.TENBAN,true);
                list.Add(t);
            }
            return list;
        }

        public bool sp_thembandanhmuc(string tenban, int makhuvuc)
        {
            
            try
            {
                BAN ban = new BAN(tenban, makhuvuc,"Trống");
                db.BANs.Add(ban);
                db.SaveChanges();
            }catch(Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_xoabandanhmuc(int ban)
        {
            
            var query = db.BANs.Where(x => x.MABAN == ban).FirstOrDefault();
            try
            {
                db.BANs.Remove(query);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_suaban(int idban, string tenban)
        {
            
            try
            {
                var banUpdate = db.BANs.Find(idban);
                banUpdate.TENBAN = tenban;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_xoachitiethoadon(int idhoadon, int idban, int giamgia)
        {
          
            try
            {
                var query = db.CTHDs.Where(x => x.IDHOADON == idhoadon && x.MATHUCDON == idban && x.GIAMGIA == giamgia).FirstOrDefault();
                db.CTHDs.Remove(query);
            }
            catch (Exception) { return false;
            }
            return true;
        }
        public bool sp_xoahoadonkhihetmon(int idhoadon, int idban)
        {
            
            try
            {
                var cthd=db.CTHDs.Find(idhoadon);
                db.CTHDs.Remove(cthd);
                var hd = db.HOADONs.Find(idhoadon);
                db.HOADONs.Remove(hd);
                var ban = db.BANs.Find(idban);
                ban.TRANGTHAI = "Trống";
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public List<KhuVucBanModels> sp_loadbantrangthaitrong(int makhuvuc)
        {
            
            var query= db.BANs.Where(x => x.TRANGTHAI == "Trống" && x.MAKHUVUC == makhuvuc).ToList();
            List<KhuVucBanModels> list = new List<KhuVucBanModels>();
            foreach(var i in query)
            {
                KhuVucBanModels t = new KhuVucBanModels(i.MABAN,i.TENBAN,i.TRANGTHAI,i.MAKHUVUC);
                list.Add(t);
            }
            return list;

        }
        public List<KhuVucBanModels> sp_loadbantrangthaiconguoi(int makhuvuc)
        {
            List<KhuVucBanModels> list = new List<KhuVucBanModels>();

            var query= db.BANs.Where(x => x.TRANGTHAI == "Có người" && x.MAKHUVUC == makhuvuc).ToList();
            foreach(var i in query)
            {
                KhuVucBanModels t = new KhuVucBanModels(i.MABAN, i.TENBAN, i.TRANGTHAI, i.MAKHUVUC);
                list.Add(t);
            }
            return list;
        }
        public bool sp_chuyenbantable(int mabanmoi, int mabancu)
        {
           
            try
            {
                var hd = db.HOADONs.Where(x => x.MABAN == mabancu && x.TRANGTHAIHOADON == 0).FirstOrDefault();
                hd.MABAN = mabanmoi;
                var bancu = db.BANs.Where(x => x.MABAN == mabancu).FirstOrDefault();
                bancu.TRANGTHAI = "Trống";
                var banmoi = db.BANs.Where(x => x.MABAN == mabanmoi).FirstOrDefault();
                bancu.TRANGTHAI = "Có người";
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public List<KhuVucBanModels> sp_loadbancangop(int makhuvuc, int maban)
        {
            
            List<KhuVucBanModels> list = new List<KhuVucBanModels>();
            var query = from b in db.BANs
                        join hd in db.HOADONs on b.MABAN equals hd.MABAN
                        where b.TRANGTHAI == "Có người" && b.MAKHUVUC == makhuvuc && b.MABAN != maban && hd.TRANGTHAIHOADON == 0
                        select new { b,hd.IDHOADON};
            foreach(var i in query)
            {
                KhuVucBanModels t = new KhuVucBanModels(i.b,i.IDHOADON);
                list.Add(t);
            }
            return list;
        }
        public List<HoaDonModels> sp_loadcthdbangop(int mabangop)
        {
            
            List<HoaDonModels> list = new List<HoaDonModels>();
            var query = db.HOADONs.Where(x => x.MABAN == mabangop && x.TRANGTHAIHOADON == 0).FirstOrDefault();
            var cthdbangop = db.CTHDs.Where(y => y.IDHOADON == query.IDHOADON);
            foreach(var i in cthdbangop)
            {
                HoaDonModels t = new HoaDonModels(i.IDHOADON,i.MATHUCDON,i.SOLUONG,i.GIAMGIA);
                list.Add(t);
            }
            return list;

        }
        public bool sp_xoahoadongopban(int maban)
        {
            
            try
            {
                var query = db.HOADONs.Where(x => x.MABAN == maban && x.TRANGTHAIHOADON == 0).Select(x => x.IDHOADON);
                var cthd = db.CTHDs.Where(x => x.IDHOADON == query.FirstOrDefault()).FirstOrDefault();
                db.CTHDs.Remove(cthd);
                var hd = db.HOADONs.Where(x => x.IDHOADON == query.FirstOrDefault()).FirstOrDefault();
                db.HOADONs.Remove(hd);
                var ban = db.BANs.Find(maban);
                ban.TRANGTHAI = "Trống";
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


       

        public List<KhuVucBanModels> sp_danhsachkhuvuccobantrong()
        {
           
            var query = from b in db.BANs
                        join kv in db.KHUVUCs on b.MAKHUVUC equals kv.MAKHUVUC
                        where b.TRANGTHAI == "Trống"
                        orderby kv.TENKHUVUC
                        select new{ b.TENBAN,kv.TENKHUVUC,b.TRANGTHAI};
            List<KhuVucBanModels> list = new List<KhuVucBanModels>();
            foreach(var i in query)
            {
                KhuVucBanModels t = new KhuVucBanModels(i.TENBAN, i.TENKHUVUC, i.TRANGTHAI);
                list.Add(t);
            }
            return list;       
        }
    }
}
