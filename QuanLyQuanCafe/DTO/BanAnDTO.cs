using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BanAnDTO
    {
         public BanAnDTO(int maban, string tenban, string trangthai)
        {
            this.MaBan = maban;
            this.TenBan = tenban;
            this.TrangThai = trangthai;
        }
        public BanAnDTO(DataRow row)
        {
            this.MaBan = (int)row["MaBan"];
            this.TenBan = row["TenBan"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
        }
        private int maBan;
        public int MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }
        private string tenBan;
        public string TenBan
        {
            get { return tenBan; }
            set { tenBan = value; }
        }
        private string trangThai;
        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

    }
}
