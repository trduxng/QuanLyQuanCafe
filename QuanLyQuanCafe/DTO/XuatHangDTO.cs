using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class PhieuXuatDTO
    {
        public PhieuXuatDTO(string maPhieuXuat, DateTime ngayXuat, string maNV, string lyDoXuat)
        {
            this.MaPhieuXuat = maPhieuXuat;
            this.NgayXuat = ngayXuat;
            this.MaNV = maNV;
            this.LyDoXuat = lyDoXuat;
        }

        public PhieuXuatDTO(DataRow row)
        {
            this.MaPhieuXuat = row["MaPhieuXuat"].ToString();
            this.NgayXuat = (DateTime)row["NgayXuat"];
            this.MaNV = row["MaNV"].ToString();
            this.LyDoXuat = row["LyDoXuat"].ToString();
        }

        private string maPhieuXuat;
        public string MaPhieuXuat
        {
            get { return maPhieuXuat; }
            set { maPhieuXuat = value; }
        }

        private DateTime ngayXuat;
        public DateTime NgayXuat
        {
            get { return ngayXuat; }
            set { ngayXuat = value; }
        }

        private string maNV;
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        private string lyDoXuat;
        public string LyDoXuat
        {
            get { return lyDoXuat; }
            set { lyDoXuat = value; }
        }
    }

    public class ChiTietPhieuXuatDTO
    {
        public ChiTietPhieuXuatDTO(string maCTPX, string maPhieuXuat, string maMH, int soLuongXuat, string ghiChu)
        {
            this.MaCTPX = maCTPX;
            this.MaPhieuXuat = maPhieuXuat;
            this.MaMH = maMH;
            this.SoLuongXuat = soLuongXuat;
            this.GhiChu = ghiChu;
        }

        public ChiTietPhieuXuatDTO(DataRow row)
        {
            this.MaCTPX = row["MaCTPX"].ToString();
            this.MaPhieuXuat = row["MaPhieuXuat"].ToString();
            this.MaMH = row["MaMH"].ToString();
            this.SoLuongXuat = (int)row["SoLuongXuat"];
            this.GhiChu = row["GhiChu"].ToString();
        }

        private string maCTPX;
        public string MaCTPX
        {
            get { return maCTPX; }
            set { maCTPX = value; }
        }

        private string maPhieuXuat;
        public string MaPhieuXuat
        {
            get { return maPhieuXuat; }
            set { maPhieuXuat = value; }
        }

        private string maMH;
        public string MaMH
        {
            get { return maMH; }
            set { maMH = value; }
        }

        private int soLuongXuat;
        public int SoLuongXuat
        {
            get { return soLuongXuat; }
            set { soLuongXuat = value; }
        }

        private string ghiChu;
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
    }

    public class MatHangDTO
    {
        public MatHangDTO(string maMH, string tenMH, string maLoaiHang, int soLuong)
        {
            this.MaMH = maMH;
            this.TenMH = tenMH;
            this.MaLoaiHang = maLoaiHang;
            this.SoLuong = soLuong;
        }

        public MatHangDTO(DataRow row)
        {
            this.MaMH = row["MaMH"].ToString();
            this.TenMH = row["TenMH"].ToString();
            this.MaLoaiHang = row["MaLoaiHang"].ToString();
            this.SoLuong = (int)row["SoLuong"];
        }

        private string maMH;
        public string MaMH
        {
            get { return maMH; }
            set { maMH = value; }
        }

        private string tenMH;
        public string TenMH
        {
            get { return tenMH; }
            set { tenMH = value; }
        }

        private string maLoaiHang;
        public string MaLoaiHang
        {
            get { return maLoaiHang; }
            set { maLoaiHang = value; }
        }

        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
    }

    public class NhanVienDTO
    {
        public NhanVienDTO(string maNV, string tenNV)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
        }

        public NhanVienDTO(DataRow row)
        {
            this.MaNV = row["MaNV"].ToString();
            this.TenNV = row["TenNV"].ToString();
        }

        private string maNV;
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        private string tenNV;
        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }
    }
}
