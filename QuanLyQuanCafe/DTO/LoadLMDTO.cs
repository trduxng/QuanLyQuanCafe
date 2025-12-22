using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class LoadLMDTO
    {
        public LoadLMDTO(int maloai, string tenloai)
        {
            this.MaLoai = maloai;
            this.TenLoai = tenloai;
        }
        public LoadLMDTO(DataRow row)
        {
            this.MaLoai = Convert.ToInt32(row["MaLoaiMon"].ToString());
            this.TenLoai = row["TenLoaiMon"].ToString();
        }
        private string tenLoai;
        public string TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }
        private int maLoai;
        public int MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }
    }
}
