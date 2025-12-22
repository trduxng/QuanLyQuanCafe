using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class SinhMaTuDongNvDAO
    {
        SinhMaTuDongNvDTO nvDTO = new SinhMaTuDongNvDTO();

        public string XuLyMaNhanVien()
        {
            string maNhanVien = nvDTO.getMaNhanVien();
            string kyTuDau = "NV";
            int soCanTang = Convert.ToInt32(maNhanVien.Substring(2)) + 1;

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
