using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class LoadLMDAO
    {
         private static LoadLMDAO instance;
        public static LoadLMDAO Instance
        {
            get { if (instance == null) instance = new LoadLMDAO(); return LoadLMDAO.instance; }
            private set { LoadLMDAO.instance = value; }
        }
        private LoadLMDAO() { }
        public List<LoadLMDTO> GetListLM()
        {
            List<LoadLMDTO> list = new List<LoadLMDTO>();
            string query = "select MaLoaiMon , TenLoaiMon from dbo.LoaiMon";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                LoadLMDTO loaimon = new LoadLMDTO(item);
                list.Add(loaimon);
            }
            return list;
        }
    }
}
