using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class ChiTietHDDAO
    {
        private static ChiTietHDDAO instance;
        public static ChiTietHDDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHDDAO(); return ChiTietHDDAO.instance; }
            private set { ChiTietHDDAO.instance = value; }
        }
        private ChiTietHDDAO() { }
        public List<ChiTietHDDTO> GetDsChiTietHD(int id)
        {
            List<ChiTietHDDTO> listBill = new List<ChiTietHDDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from dbo.ChiTietHD where MaHD=N'"+id+"'");
            foreach(DataRow item in data.Rows)
            {
                ChiTietHDDTO info = new ChiTietHDDTO(item);
                listBill.Add(info);
            }
            return listBill;
        }
        public void InsertCTHD(int maHD,int maMA,int soLuong, int thanhTien)
        {
            DataProvider.Instance.ExcuteNonQuery("PR_InsertCTHD @MaHD , @MaMonAn , @SoLuong , @ThanhTien", new object[] {  maHD, maMA, soLuong, thanhTien });

        }
    }

}
