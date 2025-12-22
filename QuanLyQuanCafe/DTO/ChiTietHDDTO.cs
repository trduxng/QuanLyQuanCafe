using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class ChiTietHDDTO
    {
        public ChiTietHDDTO( int macthd, int mahd, int mamon, int sl)
        {
            this.MACTHD = macthd;
            this.MahD = mahd;
            this.MaMon = mamon;
            this.SoLuong = sl;
        }

        public ChiTietHDDTO(DataRow row )
        {
            this.MACTHD = (int)row["MaCTHD"];
            this.MahD =(int)row["MaHD"];
            this.MaMon = (int)row["MaMonAn"];
            var sltemp = row["SoLuong"];
            if(sltemp!= null)
            {
                this.SoLuong =Convert.ToInt32(sltemp.ToString());
            }

        }
        private int mahD;
        public  int MahD
        {
            get { return mahD; }
            set { mahD = value; }
        }
        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private int maMon;
        public int MaMon
        {
            get { return maMon; }
            set { maMon = value; }
        }
        private int maCTHD;
        public int MACTHD
        {
            get { return maCTHD; }
            set { maCTHD = value; }
        }
    }
}
