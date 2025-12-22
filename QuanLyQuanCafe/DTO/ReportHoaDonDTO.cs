using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class ReportHoaDonDTO
    {
        public ReportHoaDonDTO(int mahd, DateTime? ngaylap,int maban, int tinhtrang, int giamgia,string tenmon,int soluong,int gia,int thanhtien)
        {
            this.MaHD = mahd;
            this.NgayLap = ngaylap;
            this.MaBan = maban;
            this.TinhTrang = tinhtrang;
            this.GiamGia = giamgia;
            this.TenMon = tenmon;
            this.SoLuong = soluong;
            this.DonGia = gia;
            this.ThanhTien = thanhtien;
        }

        public ReportHoaDonDTO(DataRow row)
        {

            this.MaHD =(int)row["MaHD"];
            var datetemp = row["NgayLap"];
            if(datetemp.ToString()!= "")
            {
                this.NgayLap = (DateTime?)datetemp;
            }
            this.MaBan = (int)row["MaBan"];
            this.TinhTrang = (int)row["TinhTrang"];
            this.GiamGia = (int)row["GiamGia"];
            this.TenMon = row["TenMonAn"].ToString();
            this.SoLuong = (int)Convert.ToInt32(row["SoLuong"].ToString());
            this.DonGia = (int)Convert.ToDouble(row["Gia"].ToString());
            this.ThanhTien = (int)Convert.ToDouble(row["ThanhTien"].ToString());

        }
        private int thanhTien;
        public int ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        private int donGia;
        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private string tenMon;
        public string TenMon
        {
            get { return tenMon; }
            set { tenMon = value; }
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
       
        
        private int maBan;
        public int MaBan
        {
            get { return maBan; }
            set { maBan = value; }
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
