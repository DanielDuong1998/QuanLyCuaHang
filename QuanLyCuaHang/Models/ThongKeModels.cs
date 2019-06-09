using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang.Models
{
    public class ThongKeModels
    {
        private string _TENTHUCDON;
        private int _IDHOADON;
        private string _TENKHUVUC;
        private int _SOLUONG;
        private object _DONGIA;
        private int _GIAMGIA;
        private string _TENBAN;
        private object _TONGTIEN;
        private object _NGAYLAP;
        private string _GIOLAP;
        private int _MATHUCDON;

        public ThongKeModels(string TENTHUCDON, int? SOLUONG, double? tongTien)
        {
            _TENTHUCDON = TENTHUCDON;
            _SOLUONG = (int)SOLUONG;
            _TONGTIEN = (double)tongTien;
        }

        public ThongKeModels(string tENTHUCDON, double? dONGIA, int? sOLUONG, int mATHUCDON, int? gIAMGIA)
        {
            _TENTHUCDON = tENTHUCDON;
            _DONGIA = dONGIA;
            _SOLUONG = (int)sOLUONG;
            _MATHUCDON = mATHUCDON;
            _GIAMGIA = (int)gIAMGIA;
        }

        public ThongKeModels(string tENKHUVUC, string tENBAN, double? tONGTIEN, DateTime? nGAYLAP, string gIOLAP, int iDHOADON)
        {
            _TENKHUVUC = tENKHUVUC;
            _TENBAN = tENBAN;
            _TONGTIEN = tONGTIEN;
            _NGAYLAP = nGAYLAP;
            _GIOLAP = gIOLAP;
            _IDHOADON = iDHOADON;
        }

        public string TENTHUCDON
        {
            get
            {
                return _TENTHUCDON;
            }

            set
            {
                _TENTHUCDON = value;
            }
        }

        public int SOLUONG
        {
            get
            {
                return _SOLUONG;
            }

            set
            {
                _SOLUONG = value;
            }
        }

        public object DONGIA
        {
            get
            {
                return _DONGIA=double.Parse(_DONGIA.ToString()).ToString("N0");
            }

            set
            {
                _DONGIA = value;
            }
        }

        public int GIAMGIA
        {
            get
            {
                return _GIAMGIA;
            }

            set
            {
                _GIAMGIA = value;
            }
        }

        public string TENBAN
        {
            get
            {
                return _TENBAN;
            }

            set
            {
                _TENBAN = value;
            }
        }

        public object TONGTIEN
        {
            get
            {
                return _TONGTIEN=double.Parse(_TONGTIEN.ToString()).ToString("N0");
            }

            set
            {
                _TONGTIEN = value;
            }
        }

        public object NGAYLAP
        {
            get
            {
                return _NGAYLAP;
            }

            set
            {
                _NGAYLAP = value;
            }
        }

        public string GIOLAP
        {
            get
            {
                return _GIOLAP;
            }

            set
            {
                _GIOLAP = value;
            }
        }

        public string TENKHUVUC
        {
            get
            {
                return _TENKHUVUC;
            }

            set
            {
                _TENKHUVUC = value;
            }
        }

        public int IDHOADON
        {
            get
            {
                return _IDHOADON;
            }

            set
            {
                _IDHOADON = value;
            }
        }
    }
}
