using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang.Models
{
    public class TaiKhoanModels
    {
        private string _TENDANGNHAP;
        private string _MATKHAU;
        private string _QUYEN;
        private string _HOTEN;

<<<<<<< HEAD
        public TaiKhoanModels()
        {
        }

=======
>>>>>>> 7c18fcd812eab7d91f130ce4abb572ac54a034c4
        public TaiKhoanModels(string tENDANGNHAP, string mATKHAU, string qUYEN, string hOTEN)
        {
            _TENDANGNHAP = tENDANGNHAP;
            _MATKHAU = mATKHAU;
            _QUYEN = qUYEN;
            _HOTEN = hOTEN;
        }

        public string TENDANGNHAP
        {
            get
            {
                return _TENDANGNHAP;
            }

            set
            {
                _TENDANGNHAP = value;
            }
        }

        public string MATKHAU
        {
            get
            {
                return _MATKHAU;
            }

            set
            {
                _MATKHAU = value;
            }
        }

        public string QUYEN
        {
            get
            {
                return _QUYEN;
            }

            set
            {
                _QUYEN = value;
            }
        }

        public string HOTEN
        {
            get
            {
                return _HOTEN;
            }

            set
            {
                _HOTEN = value;
            }
        }
    }
}
