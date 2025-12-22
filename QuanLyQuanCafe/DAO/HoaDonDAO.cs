using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            private set { HoaDonDAO.instance = value; }
        }
        private HoaDonDAO() { }
        public int GetHD(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from dbo.HoaDon where MaBan='"+id+"' and TinhTrang = '0'");
            if(data.Rows.Count>0)
            {
                HoaDonDTO bill = new HoaDonDTO(data.Rows[0]);
                return bill.MaHD;
            }
            return -1;
        }
        public void ThanhToan(int id, int giamgia)
        {
            string query = "UPDATE dbo.HoaDon SET TinhTrang =1, " + "GiamGia = "+ giamgia + " Where MaHD=" + id;
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        public void InsertHD(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("exec PR_InsertHD @MaBan",new object[]{id});

        }
        public int GetMaxMaHD()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("SELECT MAX(MaHD) FROM dbo.HoaDon");
            }
            catch
            {
                return 1;
            }
        }
    }
}
