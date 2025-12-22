using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class ReportHoaDonDAO
    {
         private static ReportHoaDonDAO instance;
        public static ReportHoaDonDAO Instance
        {
            get { if (instance == null) instance = new ReportHoaDonDAO(); return ReportHoaDonDAO.instance; }
            private set { ReportHoaDonDAO.instance = value; }
        }
        private ReportHoaDonDAO() { }
        
        public List<ReportHoaDonDTO> Inhoadon(int id)
        {
            List<ReportHoaDonDTO> list = new List<ReportHoaDonDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select MaHD , NgayLap  ,MaBan , Tinhtrang , GiamGia , TenMonAn , SoLuong , Gia , ThanhTien from ReportHoaDon Where MaHD = " + id);
            foreach (DataRow item in data.Rows)
            {
                ReportHoaDonDTO loaimon = new ReportHoaDonDTO(item);
                list.Add(loaimon);
            }
            return list;
        }
    }
}
