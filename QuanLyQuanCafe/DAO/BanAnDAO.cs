using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BanAnDAO
    {
        private static BanAnDAO instance;
        public static BanAnDAO Instance
        {
            get { if (instance == null) instance = new BanAnDAO();return BanAnDAO.instance; }
            private set { BanAnDAO.instance = value; }
        }

        public static int Dai = 85;
        public static int Rong = 85;
        private BanAnDAO()
        {

        }
        public void ChuyenBan(int maban1, int maban2)
        {
            DataProvider.Instance.ExcuteQuery("PR_ChuyenBan @MaBan1 , @MaBan2 " , new object[]{maban1,maban2});
        }
        public List<BanAnDTO> LoadDsBan()
        {
            List<BanAnDTO> dsBan = new List<BanAnDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("PR_GETDanhSachBan");
            foreach (DataRow item in data.Rows)
            {
                BanAnDTO banan = new BanAnDTO(item);
                dsBan.Add(banan);
            }
            return dsBan;
        }


        public static int TableWidth { get; set; }
    }
}
