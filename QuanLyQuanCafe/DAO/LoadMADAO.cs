using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class LoadMADAO
    {
         private static LoadMADAO instance;
        public static LoadMADAO Instance
        {
            get { if (instance == null) instance = new LoadMADAO(); return LoadMADAO.instance; }
            private set { LoadMADAO.instance = value; }
        }
        private LoadMADAO() { }
        public List<LoadMADTO> GetlistMonAn(int id)
        {
            List<LoadMADTO> list = new List<LoadMADTO>();
            string query = "select MaMonAn , TenMonAn , MaLoaiMon , Gia from dbo.MonAn where MaLoaiMon ="+id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                LoadMADTO monan = new LoadMADTO(item);
                list.Add(monan);
            }
            return list;
        }
    }
}
