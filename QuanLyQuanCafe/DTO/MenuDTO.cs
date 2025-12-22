using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class MenuDTO
    {
        public MenuDTO(string tenmon, int soluong, int dongia, int thanhtien)
        {
            this.TenMon = tenmon;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.ThanhTien = thanhtien;
        }

        public MenuDTO(DataRow row)
        {
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

    }
}
