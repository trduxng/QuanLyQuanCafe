using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class SinhMaTuDongNCCDAO
    {
        SinhMaTuDongNCCDTO nvDTO = new SinhMaTuDongNCCDTO();

        public string XuLyMaNCC()
        {
            string maNCC = nvDTO.getMaNCC();
            string kyTuDau = "NCC";
            int soCanTang = Convert.ToInt32(maNCC.Substring(3)) + 1;

            string maNV = "";
            if (soCanTang >= 0 && soCanTang < 10)
                maNV = kyTuDau + "0" + soCanTang;
            if (soCanTang >= 10 && soCanTang < 1000)
                maNV = kyTuDau + soCanTang;
            if (soCanTang >= 1000)
                maNV = "Không thể tăng hơn nữa!";
            return maNV;
        } 
    }
}
