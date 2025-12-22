using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class LoadMonAnDAO
    {
        private static LoadMonAnDAO instance;
        public static LoadMonAnDAO Instance
        {
            get { if (instance == null) instance = new LoadMonAnDAO(); return LoadMonAnDAO.instance; }
            private set { LoadMonAnDAO.instance = value; }
        }
        private LoadMonAnDAO() { }
        public List<LoadMonAnDTO> GetlistMonAn(int id)
        {
            List<LoadMonAnDTO> list = new List<LoadMonAnDTO>();
            string query = "select MaMonAn , TenMonAn , MaLoaiMon , Gia from dbo.MonAn where MaLoaiMon ="+id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                LoadMonAnDTO monan = new LoadMonAnDTO(item);
                list.Add(monan);
            }
            return list;
        }
    }
}
