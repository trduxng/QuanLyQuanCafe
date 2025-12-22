using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO();return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }
        public List<MenuDTO> getListMenu(int id)
        {
            List<MenuDTO> listMenu = new List<MenuDTO>();
            string query = "select f.TenMonAn, bi.SoLuong,f.Gia,f.Gia*bi.SoLuong as ThanhTien from  dbo.ChiTietHD as bi,dbo.HoaDon as b, dbo.MonAn as f where bi.MaHD = b.MaHD and bi.MaMonAn = f.MaMonAn and b.TinhTrang ='0' and b.MaBan = "+id+"";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                MenuDTO menu = new MenuDTO(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
