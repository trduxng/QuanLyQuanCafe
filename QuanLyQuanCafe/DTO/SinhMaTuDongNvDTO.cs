using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class SinhMaTuDongNvDTO
    {
        QLCaFeDataContext nv = new QLCaFeDataContext();

        public string getMaNhanVien()
        {
            string maNhanVien = "";
            // Vì Proc PR_GETMaNhanVien trả về OUTPUT dạng string nên ta cần khai báo thêm ref như bên dưới 
            nv.PR_GETMaNhanVien(ref maNhanVien);
            return maNhanVien;
            // Trả về dữ liệu: ví dụ như "NV001" 
        }
    }
}
