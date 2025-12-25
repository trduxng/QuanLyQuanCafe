using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class SinhMaTuDongPXDAO
    {
        private static SinhMaTuDongPXDAO instance;
        public static SinhMaTuDongPXDAO Instance
        {
            get { if (instance == null) instance = new SinhMaTuDongPXDAO(); return SinhMaTuDongPXDAO.instance; }
            private set { SinhMaTuDongPXDAO.instance = value; }
        }

        private SinhMaTuDongPXDAO() { }

        public string GetMaPhieuXuat()
        {
            string query = "PR_GetMaxMaPhieuXuat";
            object result = DataProvider.Instance.ExcuteScalar(query);
            string maPhieuXuat = "";
            if (result != DBNull.Value && result != null)
            {
                maPhieuXuat = result.ToString();
                string kyTuDau = maPhieuXuat.Substring(0, 2);
                int soCanTang = Convert.ToInt32(maPhieuXuat.Substring(2)) + 1;

                if (soCanTang >= 0 && soCanTang < 10)
                    maPhieuXuat = kyTuDau + "00" + soCanTang;
                else if (soCanTang >= 10 && soCanTang < 100)
                    maPhieuXuat = kyTuDau + "0" + soCanTang;
                else if (soCanTang >= 100 && soCanTang < 1000)
                    maPhieuXuat = kyTuDau + soCanTang;
                else
                    maPhieuXuat = "PX999"; // Full
            }
            else
            {
                maPhieuXuat = "PX001";
            }

            return maPhieuXuat;
        }
    }
}
