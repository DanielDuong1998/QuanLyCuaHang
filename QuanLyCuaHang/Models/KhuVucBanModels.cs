using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyCuaHang.Models
{
    public class KhuVucBanModels
    {
        private int _MAKHUVUC;
        private string _TENKHUVUC;
        private int _MABAN;
        private string _TENBAN;
        private string _TRANGTHAI;
        private int _SLBAN;
        private int _IDHOADON;
      
        public  KhuVucBanModels(int MABAN, string TENBAN,Boolean a)
        {
            _MABAN = MABAN;
            _TENBAN = TENBAN;
        }
        public KhuVucBanModels(BAN b, int iDHOADON)
        {
            _MABAN = b.MABAN;
            _TENBAN = b.TENBAN;
            _TRANGTHAI = b.TRANGTHAI;
            _IDHOADON = iDHOADON;
        }

        public  KhuVucBanModels(int mAKHUVUC, string tENKHUVUC)
        {
            _MAKHUVUC = mAKHUVUC;
            _TENKHUVUC = tENKHUVUC;
        }

        public KhuVucBanModels(int? mAKHUVUC, string tENKHUVUC, int sLBAN)
        {
            _MAKHUVUC = (int)mAKHUVUC;
            _TENKHUVUC = tENKHUVUC;
            _SLBAN = sLBAN;
        }

        public KhuVucBanModels(string tENBAN, string tENKHUVUC, string tRANGTHAI)
        {
            _TENBAN = tENBAN;
            _TENKHUVUC = tENKHUVUC;
            _TRANGTHAI = tRANGTHAI;
        }

        public KhuVucBanModels(int MABAN, string TENBAN, string TRANGTHAI, int? MAKHUVUC)
        {
            _MABAN = MABAN;
            _TENBAN = TENBAN;

            _TRANGTHAI = TRANGTHAI;
            _MAKHUVUC = (int)MAKHUVUC;
        }

        public int MAKHUVUC
        {
            get
            {
                return _MAKHUVUC;
            }

            set
            {
                _MAKHUVUC = value;
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

        public int MABAN
        {
            get
            {
                return _MABAN;
            }

            set
            {
                _MABAN = value;
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

        public string TRANGTHAI
        {
            get
            {
                return _TRANGTHAI;
            }

            set
            {
                _TRANGTHAI = value;
            }
        }

        public int SLBAN
        {
            get
            {
                return _SLBAN;
            }

            set
            {
                _SLBAN = value;
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
