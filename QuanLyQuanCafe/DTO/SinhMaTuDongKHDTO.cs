using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class SinhMaTuDongKHDTO
    {
        QLCaFeDataContext nv = new QLCaFeDataContext();

        public string getMaKH()
        {
            string maKH = "";
            // Vì Proc PR_GETMaNhanVien trả về OUTPUT dạng string nên ta cần khai báo thêm ref như bên dưới 
            nv.PR_GETMaKhachHang(ref maKH);
            return maKH;
            // Trả về dữ liệu: ví dụ như "NV001" 
        }
    }
}
