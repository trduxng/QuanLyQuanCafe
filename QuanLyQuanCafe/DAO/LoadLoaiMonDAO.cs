using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class LoadLoaiMonDAO
    {
        private static LoadLoaiMonDAO instance;
        public static LoadLoaiMonDAO Instance
        {
            get { if (instance == null) instance = new LoadLoaiMonDAO(); return LoadLoaiMonDAO.instance; }
            private set { LoadLoaiMonDAO.instance = value; }
        }
        private LoadLoaiMonDAO() { }
        public List<LoadLoaiMonDTO> GetListLM()
        {
            List<LoadLoaiMonDTO> list = new List<LoadLoaiMonDTO>();
            string query = "select TenLoaiMon from dbo.LoaiMon";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                LoadLoaiMonDTO loaimon = new LoadLoaiMonDTO(item);
                list.Add(loaimon);
            }
            return list;
        }
    }
}
