using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class PhieuXuatDAO
    {
        private static PhieuXuatDAO instance;
        public static PhieuXuatDAO Instance
        {
            get { if (instance == null) instance = new PhieuXuatDAO(); return PhieuXuatDAO.instance; }
            private set { PhieuXuatDAO.instance = value; }
        }

        private PhieuXuatDAO() { }

        public List<PhieuXuatDTO> LayDanhSachPhieuXuat()
        {
            List<PhieuXuatDTO> danhSach = new List<PhieuXuatDTO>();
            string query = "PR_GetDanhSachPhieuXuat";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                PhieuXuatDTO phieuXuat = new PhieuXuatDTO(item);
                danhSach.Add(phieuXuat);
            }
            return danhSach;
        }

        public bool ThemPhieuXuat(PhieuXuatDTO px)
        {
            string query = "PR_InsertPhieuXuat @MaPhieuXuat , @NgayXuat , @MaNV , @LyDoXuat";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { px.MaPhieuXuat, px.NgayXuat, px.MaNV, px.LyDoXuat });
            return result > 0;
        }

        public bool SuaPhieuXuat(PhieuXuatDTO px)
        {
            string query = "PR_UpdatePhieuXuat @MaPhieuXuat , @NgayXuat , @MaNV , @LyDoXuat";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { px.MaPhieuXuat, px.NgayXuat, px.MaNV, px.LyDoXuat });
            return result > 0;
        }

        public bool XoaPhieuXuat(string maPhieuXuat)
        {
            string query = "PR_DeletePhieuXuat @MaPhieuXuat";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maPhieuXuat });
            return result > 0;
        }

        public DataTable GetThongKePhieuXuat(DateTime tuNgay, DateTime denNgay)
        {
            string query = "PR_ThongKePhieuXuat @TuNgay , @DenNgay";
            return DataProvider.Instance.ExcuteQuery(query, new object[] { tuNgay, denNgay });
        }
    }

    public class ChiTietPhieuXuatDAO
    {
        private static ChiTietPhieuXuatDAO instance;
        public static ChiTietPhieuXuatDAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuXuatDAO(); return ChiTietPhieuXuatDAO.instance; }
            private set { ChiTietPhieuXuatDAO.instance = value; }
        }

        private ChiTietPhieuXuatDAO() { }

        public List<ChiTietPhieuXuatDTO> LayDanhSachChiTietPhieuXuat(string maPhieuXuat)
        {
            List<ChiTietPhieuXuatDTO> danhSach = new List<ChiTietPhieuXuatDTO>();
            string query = "PR_GetDanhSachChiTietPhieuXuat @MaPhieuXuat";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { maPhieuXuat });
            foreach (DataRow item in data.Rows)
            {
                ChiTietPhieuXuatDTO chiTiet = new ChiTietPhieuXuatDTO(item);
                danhSach.Add(chiTiet);
            }
            return danhSach;
        }

        public bool ThemChiTietPhieuXuat(ChiTietPhieuXuatDTO ctpx)
        {
            MatHangDTO matHang = MatHangDAO.Instance.GetMatHangByMaMH(ctpx.MaMH);
            if (matHang.SoLuong < ctpx.SoLuongXuat)
            {
                return false; // Not enough stock
            }

            string query = "PR_InsertChiTietPhieuXuat @MaCTPX , @MaPhieuXuat , @MaMH , @SoLuongXuat , @GhiChu";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { ctpx.MaCTPX, ctpx.MaPhieuXuat, ctpx.MaMH, ctpx.SoLuongXuat, ctpx.GhiChu });

            if (result > 0)
            {
                int soLuongMoi = matHang.SoLuong - ctpx.SoLuongXuat;
                return MatHangDAO.Instance.UpdateSoLuong(ctpx.MaMH, soLuongMoi);
            }
            return false;
        }

        public bool SuaChiTietPhieuXuat(ChiTietPhieuXuatDTO ctpx, int soLuongCu)
        {
            MatHangDTO matHang = MatHangDAO.Instance.GetMatHangByMaMH(ctpx.MaMH);
            int soLuongChenhLech = ctpx.SoLuongXuat - soLuongCu;

            if (matHang.SoLuong < soLuongChenhLech)
            {
                return false; // Not enough stock
            }

            string query = "PR_UpdateChiTietPhieuXuat @MaCTPX , @MaMH , @SoLuongXuat , @GhiChu";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { ctpx.MaCTPX, ctpx.MaMH, ctpx.SoLuongXuat, ctpx.GhiChu });

            if (result > 0)
            {
                int soLuongMoi = matHang.SoLuong - soLuongChenhLech;
                return MatHangDAO.Instance.UpdateSoLuong(ctpx.MaMH, soLuongMoi);
            }
            return false;
        }

        public bool XoaChiTietPhieuXuat(string maCTPX, string maMH, int soLuongXuat)
        {
            string query = "PR_DeleteChiTietPhieuXuat @MaCTPX";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maCTPX });
            if (result > 0)
            {
                MatHangDTO matHang = MatHangDAO.Instance.GetMatHangByMaMH(maMH);
                int soLuongMoi = matHang.SoLuong + soLuongXuat;
                return MatHangDAO.Instance.UpdateSoLuong(maMH, soLuongMoi);
            }
            return false;
        }
    }

    public class MatHangDAO
    {
        private static MatHangDAO instance;
        public static MatHangDAO Instance
        {
            get { if (instance == null) instance = new MatHangDAO(); return MatHangDAO.instance; }
            private set { MatHangDAO.instance = value; }
        }

        private MatHangDAO() { }

        public List<MatHangDTO> LayDanhSachMatHang()
        {
            List<MatHangDTO> danhSach = new List<MatHangDTO>();
            string query = "SELECT * FROM MatHang"; // Or PR_GetDanhSachMatHang if you created it
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MatHangDTO matHang = new MatHangDTO(item);
                danhSach.Add(matHang);
            }
            return danhSach;
        }

        public MatHangDTO GetMatHangByMaMH(string maMH)
        {
            string query = "PR_GetMatHangByMaMH @MaMH";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { maMH });
            if (data.Rows.Count > 0)
            {
                return new MatHangDTO(data.Rows[0]);
            }
            return null;
        }

        public bool UpdateSoLuong(string maMH, int soLuong)
        {
            string query = "PR_UpdateSoLuongMatHang @MaMH , @SoLuong";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maMH, soLuong });
            return result > 0;
        }
    }

    public class NhanVienDAO
    {
        private static NhanVienDAO instance;
        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return NhanVienDAO.instance; }
            private set { NhanVienDAO.instance = value; }
        }

        private NhanVienDAO() { }

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            List<NhanVienDTO> danhSach = new List<NhanVienDTO>();
            string query = "PR_GetDanhSachNhanVien"; 
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVienDTO nhanVien = new NhanVienDTO(item);
                danhSach.Add(nhanVien);
            }
            return danhSach;
        }
    }
}