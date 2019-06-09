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
        public List<KHUVUC> sp_loadkhuvuc()
        {
            List<KHUVUC> kv = new List<KHUVUC>();
            kv = db.KHUVUCs.ToList();
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
            /*int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tenkhuvuc";
            values[0] = tenkhuvuc;
            return Execute("sp_themkhuvuc", name, values, parameter);*/
            KHUVUC t = new KHUVUC();
            t.TENKHUVUC = tenkhuvuc;
            db.KHUVUCs.Add(t);
            db.SaveChanges();
            return true;
        }
        public bool sp_xoakhuvuc(int makhuvuc)
        {
            /*int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@makhuvuc";
            values[0] = makhuvuc;
            return Execute("sp_xoakhuvuc", name, values, parameter);*/
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
        //public List<KhuVucBanModels> sp_bandanhmuc(int makhuvuc)
      //  {
           /* int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@makhuvuc";
            values[0] = makhuvuc;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_bandanhmuc", name, values, parameter));
            return JsonConvert.DeserializeObject<List<KhuVucBanModels>>(json);*/

        //}
    
        public bool sp_thembandanhmuc(string tenban, int makhuvuc)
        {
            /* int parameter = 2;
             string[] name = new string[parameter];
             object[] values = new object[parameter];
             name[0] = "@tenban";
             values[0] = tenban;
             name[1] = "@makhuvuc";
             values[1] = makhuvuc;
             return Execute("sp_thembandanhmuc", name, values, parameter);*/
            try
            {
                BAN ban = new BAN(tenban, makhuvuc);
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
            /*int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@maban";
            values[0] = ban;
            return Execute("sp_xoabandanhmuc", name, values, parameter);*/
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
            /*int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@idban";
            name[1] = "@tenban";
            values[0] = idban;
            values[1] = tenban;
            return Execute("sp_suaban", name, values, parameter);*/
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
            /*int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@idhoadon";
            name[1] = "@mathucdon";
            name[2] = "@giamgia";
            values[0] = idhoadon;
            values[1] = idban;
            values[2] = giamgia;
            return Execute("sp_xoachitiethoadon", name, values, parameter);*/
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
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@idhoadon";
            name[1] = "@idban";
            values[0] = idhoadon;
            values[1] = idban;
            return Execute("sp_xoahoadonkhihetmon", name, values, parameter);
        }
        public List<KhuVucBanModels> sp_loadbantrangthaitrong(int makhuvuc)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@makhuvuc";
            values[0] = makhuvuc;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_loadbantrangthaitrong", name, values, parameter));
            return JsonConvert.DeserializeObject<List<KhuVucBanModels>>(json);
        }
        public List<KhuVucBanModels> sp_loadbantrangthaiconguoi(int makhuvuc)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@makhuvuc";
            values[0] = makhuvuc;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_loadbantrangthaiconguoi", name, values, parameter));
            return JsonConvert.DeserializeObject<List<KhuVucBanModels>>(json);
        }
        public bool sp_chuyenbantable(int mabanmoi, int mabancu)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@mabanmoi";
            name[1] = "@mabancu";
            values[0] = mabanmoi;
            values[1] = mabancu;
            return Execute("sp_chuyenbantable", name, values, parameter);
        }
        public List<KhuVucBanModels> sp_loadbancangop(int makhuvuc, int maban)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@makhuvuc";
            name[1] = "@maban";
            values[0] = makhuvuc;
            values[1] = maban;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_loadbancangop", name, values, parameter));
            return JsonConvert.DeserializeObject<List<KhuVucBanModels>>(json);
        }
        public List<HoaDonModels> sp_loadcthdbangop(int mabangop)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@mabangop";
            values[0] = mabangop;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_loadcthdbangop", name, values, parameter));
            return JsonConvert.DeserializeObject<List<HoaDonModels>>(json);
        }
        public bool sp_xoahoadongopban(int maban)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@maban";
            values[0] = maban;
            return Execute("sp_xoahoadongopban", name, values, parameter);
        }
        public List<KhuVucBanModels> sp_danhsachkhuvuccobantrong()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_danhsachkhuvuccobantrong"));
            return JsonConvert.DeserializeObject<List<KhuVucBanModels>>(json);
        }
    }
}
