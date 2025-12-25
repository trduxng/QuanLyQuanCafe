using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class SinhMaTuDongCTPXDAO
    {
        private static SinhMaTuDongCTPXDAO instance;
        public static SinhMaTuDongCTPXDAO Instance
        {
            get { if (instance == null) instance = new SinhMaTuDongCTPXDAO(); return SinhMaTuDongCTPXDAO.instance; }
            private set { SinhMaTuDongCTPXDAO.instance = value; }
        }

        private SinhMaTuDongCTPXDAO() { }

        public string GetMaChiTietPhieuXuat()
        {
            string query = "PR_GetMaxMaCTPX";
            object result = DataProvider.Instance.ExcuteScalar(query);
            string maCTPX = "";
            if (result != DBNull.Value && result != null)
            {
                maCTPX = result.ToString();
                string kyTuDau = maCTPX.Substring(0, 3);
                int soCanTang = Convert.ToInt32(maCTPX.Substring(3)) + 1;

                if (soCanTang >= 0 && soCanTang < 10)
                    maCTPX = kyTuDau + "000" + soCanTang;
                else if (soCanTang >= 10 && soCanTang < 100)
                    maCTPX = kyTuDau + "00" + soCanTang;
                else if (soCanTang >= 100 && soCanTang < 1000)
                    maCTPX = kyTuDau + "0" + soCanTang;
                else if (soCanTang >= 1000 && soCanTang < 10000)
                    maCTPX = kyTuDau + soCanTang;
                else
                    maCTPX = "CTP9999"; // Full
            }
            else
            {
                maCTPX = "CTP0001";
            }

            return maCTPX;
        }
    }
}
