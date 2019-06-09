using QuanLyCuaHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang.Dal
{
    public class HoaDonDal
    {
        WPF_DatabaseEntities db = new WPF_DatabaseEntities();
        public List<HoaDonModels> sp_loaddanhsachthucdoncuaban(int maban, int mahoadon)
        {
            //int parameter = 2;
            //string[] name = new string[parameter];
            //object[] values = new object[parameter];
            //name[0]= "@maban";
            //name[1]= "@mahoadon";
            //values[0]=maban;
            //values[1]=mahoadon;
            //string json = JsonConvert.SerializeObject(LoadDataParameter("sp_loaddanhsachthucdoncuaban", name, values, parameter));
            //return JsonConvert.DeserializeObject<List<HoaDonModels>>(json);
            List<HoaDonModels> list = new List<HoaDonModels>();


            var query = from hd in db.HOADONs
                        join cthd in db.CTHDs on hd.IDHOADON equals cthd.IDHOADON
                        join td in db.THUCDONs on cthd.MATHUCDON equals td.MATHUCDON
                        where hd.IDHOADON == mahoadon && hd.MABAN == maban
                        select new { td.TENTHUCDON, DONGIA = (double)td.DONGIA * ((100 - (double)cthd.GIAMGIA)) / 100, cthd.SOLUONG,td.MATHUCDON,cthd.GIAMGIA,GiaMD=td.DONGIA,TTien= (td.DONGIA * ((100 - (double)cthd.GIAMGIA) / 100)) * cthd.SOLUONG };

            foreach (var i in query)
            {
                HoaDonModels h = new HoaDonModels(i.TENTHUCDON,i.DONGIA,i.SOLUONG,i.MATHUCDON,i.GIAMGIA,i.GiaMD,i.TTien);
                list.Add(h);
            }
            return list;
        }

        

        public List<HoaDonModels> sp_layidhoadontheo_khuvucban(int maban, int makhuvuc)
        {
         
            var query = from hoadon in db.HOADONs
                        join ban in db.BANs on hoadon.MABAN equals ban.MABAN
                        where hoadon.MABAN == maban && ban.MAKHUVUC == makhuvuc && hoadon.TRANGTHAIHOADON==0
                        select hoadon.IDHOADON;
            List<HoaDonModels> list = new List<HoaDonModels>();
            foreach(var i in query)
            {
                HoaDonModels t = new HoaDonModels(i);
                list.Add(t);
            }
           

            return list;
        }
        public bool sp_themhoadon(int maban)
        {

          
            try
            {
                var ngaylap = DateTime.Now.Date;
                var gioLap = DateTime.Now.ToString("HH:mm:ss");
                HOADON hd = new HOADON(ngaylap, maban, gioLap);
                db.HOADONs.Add(hd);
                var ban = db.BANs.Find(maban);
                ban.TRANGTHAI = "Có người";
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_themcthdban(int idhoadon, int mathucdon, int soluong, int giamgia)
        {
           
            try
            {
                var query = db.CTHDs.Where(x => x.IDHOADON == idhoadon && x.MATHUCDON == mathucdon && x.GIAMGIA == giamgia).Select(x => x.MATHUCDON);
                if (query != null)
                {
                    var soluongcu = db.CTHDs.Where(x => x.IDHOADON == idhoadon && x.MATHUCDON == mathucdon && x.GIAMGIA == giamgia).Select(x => x.SOLUONG);
                    var tongsoluong = Convert.ToInt32(soluongcu) + soluong;
                    var soluongUp = db.CTHDs.Where(x => x.IDHOADON == idhoadon && x.MATHUCDON == mathucdon && x.GIAMGIA == giamgia).FirstOrDefault();
                    soluongUp.SOLUONG = tongsoluong;
                    db.SaveChanges();
                }
                else
                {
                    CTHD cthd = new CTHD(idhoadon, mathucdon, soluong, giamgia);
                    db.CTHDs.Add(cthd);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool sp_thanhtoanban(int maban, int mahoadon, double tongtien, string idnhanvien)
        {

            //begin
            //update HOADON set TRANGTHAIHOADON = 1,TONGTIEN = @tongtien,IDNHANVIEN = @idnhanvien,INHOADON = 2 where IDHOADON = @mahoadon and MABAN = @maban
            //update BAN set TRANGTHAI = N'Trống' where MABAN = @maban
            //end


            try
            {
                var hd = db.HOADONs.Where(x => x.MABAN == maban && x.MABAN == maban).FirstOrDefault();
                hd.TRANGTHAIHOADON = 1;
                hd.TONGTIEN = tongtien;
                hd.IDNHANVIEN = idnhanvien;
                hd.INHOADON = 2;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        //public DataTable sp_loaddanhsachthucdoncuaban_rpt(int maban, int mahoadon, string giora)
        //{
        //    /*int parameter = 3;
        //    string[] name = new string[parameter];
        //    object[] values = new object[parameter];
        //    name[0] = "@maban";
        //    name[1] = "@mahoadon";
        //    name[2] = "@giora";
        //    values[0] = maban;
        //    values[1] = mahoadon;
        //    values[2] = giora;
        //    return LoadDataParameter("sp_loaddanhsachthucdoncuaban_rpt", name, values, parameter);*/

        //}
        /*public bool sp_capnhathoadondain(int idhoadon)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@idhoadon";         
            values[0] = idhoadon;          
            return Execute("sp_capnhathoadondain", name, values, parameter);
        }
        public List<HoaDonModels> sp_loadhoadoncanin()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_loadhoadoncanin"));
            return JsonConvert.DeserializeObject<List<HoaDonModels>>(json);
        }*/
    }

}
