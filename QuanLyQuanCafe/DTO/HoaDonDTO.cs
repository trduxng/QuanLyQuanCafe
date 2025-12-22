using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class HoaDonDTO
    {
        public HoaDonDTO(int mahd, DateTime? ngaylap, int tinhtrang, int giamgia)
        {
            this.MaHD = mahd;
            this.NgayLap = ngaylap;
            this.TinhTrang = tinhtrang;
            this.GiamGia = giamgia;
        }

        public HoaDonDTO(DataRow row)
        {

            this.MaHD =(int)row["MaHD"];
            var datetemp = row["NgayLap"];
            if(datetemp.ToString()!= "")
            {
                this.NgayLap = (DateTime?)datetemp;
            }
            this.TinhTrang = (int)row["TinhTrang"];
            this.GiamGia = (int)row["GiamGia"];

        }
        private int giamGia;
        public int GiamGia
        {
            get { return giamGia; }
            set { giamGia = value; }
        }
        private int tinhTrang;
        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
       
        private DateTime? ngayLap;
        public DateTime? NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        private int maHD;
        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
    }
}
