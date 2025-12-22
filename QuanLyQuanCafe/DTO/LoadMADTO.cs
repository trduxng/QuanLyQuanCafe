using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class LoadMADTO
    {
        public LoadMADTO(int mamon, string tenmon, int maloai, int giamon)
        {
            this.MaMon = mamon;
            this.TenMon = tenmon;
            this.MaLoai = maloai;
            this.GiaMon = giamon;
        }
        public LoadMADTO(DataRow row)
        {
            this.MaMon = Convert.ToInt32(row["MaMonAn"].ToString());
            this.TenMon = row["TenMonAn"].ToString();
            this.MaLoai = Convert.ToInt32(row["MaLoaiMon"].ToString());
            this.GiaMon = (int)Convert.ToDouble(row["Gia"].ToString());
        }
        private int giaMon;
        public int GiaMon
        {
            get { return giaMon; }
            set { giaMon = value; }
        }
        private int maLoai;
        public int MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }
        private string tenMon;
        public string TenMon
        {
            get { return tenMon; }
            set { tenMon = value; }
        }
        private int maMon;
        public int MaMon
        {
            get { return maMon; }
            set { maMon = value; }
        }
    }
}
