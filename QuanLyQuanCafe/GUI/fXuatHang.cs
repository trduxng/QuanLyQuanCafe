using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyQuanCafe
{
    public partial class fXuatHang : DevExpress.XtraEditors.XtraForm
    {
        public fXuatHang()
        {
            InitializeComponent();
            this.Load += fXuatHang_Load;

            // GridView Events
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView2.FocusedRowChanged += gridView2_FocusedRowChanged;

            // Phieu Xuat buttons
            simpleButton7.Click += sbThem_Click; // Thêm
            simpleButton6.Click += sbHuy_Click; // Hủy
            simpleButton5.Click += sbSua_Click; // Sửa
            simpleButton8.Click += sbXoa_Click; // Xóa

            // Chi Tiet Phieu Xuat buttons
            simpleButton1.Click += sbThemChiTiet_Click; // Thêm
            simpleButton2.Click += sbHuyChiTiet_Click; // Hủy
            simpleButton10.Click += sbSuaChiTiet_Click; // Sửa
            simpleButton9.Click += sbXoaChiTiet_Click; // Xóa

            HienThiTxt(false);
            HienThiTxtChiTiet(false);
        }

        private bool isAdding = false;
        private bool isAddingDetail = false;
        private int soLuongCu = 0;

        #region UI Helpers
        void HienThiTxt(bool a)
        {
            dateEdit1.Enabled = a;
            comboBoxEdit1.Enabled = a;
            textEdit8.Enabled = a;
            textEdit6.ReadOnly = true; // ID always readonly
        }

        void HienThiTxtChiTiet(bool a)
        {
            textEdit2.Enabled = a; // MaMH
            textEdit3.Enabled = a; // SoLuong
            textEdit5.Enabled = a; // GhiChu
            textBox1.ReadOnly = true; // MaPhieuXuat readonly
        }

        void LoadPhieuXuat()
        {
            gridControl1.DataSource = PhieuXuatDAO.Instance.LayDanhSachPhieuXuat();
        }

        void LoadChiTietPhieuXuat(string maPhieuXuat)
        {
            gridControl2.DataSource = ChiTietPhieuXuatDAO.Instance.LayDanhSachChiTietPhieuXuat(maPhieuXuat);
        }

        void LoadNhanVien()
        {
            comboBoxEdit1.Properties.Items.Clear();
            List<NhanVienDTO> danhSachNhanVien = NhanVienDAO.Instance.LayDanhSachNhanVien();
            foreach (NhanVienDTO item in danhSachNhanVien)
            {
                comboBoxEdit1.Properties.Items.Add(item.MaNV);
            }
        }

        void LoadMatHang()
        {
            // Nếu textEdit2 là ComboBox thì load dữ liệu ở đây.
            // Hiện tại giả định nhập tay hoặc người dùng tự xử lý textEdit2
        }

        void PhieuXuatBinding()
        {
            textEdit6.DataBindings.Clear();
            textEdit6.DataBindings.Add("Text", gridControl1.DataSource, "MaPhieuXuat");
            dateEdit1.DataBindings.Clear();
            dateEdit1.DataBindings.Add("DateTime", gridControl1.DataSource, "NgayXuat");
            comboBoxEdit1.DataBindings.Clear();
            comboBoxEdit1.DataBindings.Add("Text", gridControl1.DataSource, "MaNV");
            textEdit8.DataBindings.Clear();
            textEdit8.DataBindings.Add("Text", gridControl1.DataSource, "LyDoXuat");
        }

        void ChiTietPhieuXuatBinding()
        {
            try
            {
                textEdit2.DataBindings.Clear();
                textEdit2.DataBindings.Add("Text", gridControl2.DataSource, "MaMH");
                textEdit3.DataBindings.Clear();
                textEdit3.DataBindings.Add("Text", gridControl2.DataSource, "SoLuongXuat");
                textEdit5.DataBindings.Clear();
                textEdit5.DataBindings.Add("Text", gridControl2.DataSource, "GhiChu");
            }
            catch { }
        }
        #endregion

        #region Events
        private void fXuatHang_Load(object sender, EventArgs e)
        {
            LoadPhieuXuat();
            LoadNhanVien();
            PhieuXuatBinding();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("MaPhieuXuat") != null)
            {
                string maPhieuXuat = gridView1.GetFocusedRowCellValue("MaPhieuXuat").ToString();
                LoadChiTietPhieuXuat(maPhieuXuat);
                textBox1.Text = maPhieuXuat; // Update binding manually for master-detail link
                ChiTietPhieuXuatBinding();
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.GetFocusedRowCellValue("MaCTPX") != null)
            {
                if (gridView2.GetFocusedRowCellValue("SoLuongXuat") != null)
                {
                    int.TryParse(gridView2.GetFocusedRowCellValue("SoLuongXuat").ToString(), out soLuongCu);
                }
            }
        }
        #endregion

        #region PhieuXuat CRUD
        private void sbThem_Click(object sender, EventArgs e)
        {
            if (isAdding)
            {
                if (string.IsNullOrEmpty(comboBoxEdit1.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!");
                    return;
                }
                string maPhieuXuat = textEdit6.Text;
                DateTime ngayXuat = dateEdit1.DateTime;
                string maNV = comboBoxEdit1.Text;
                string lyDoXuat = textEdit8.Text;

                PhieuXuatDTO px = new PhieuXuatDTO(maPhieuXuat, ngayXuat, maNV, lyDoXuat);
                if (PhieuXuatDAO.Instance.ThemPhieuXuat(px))
                {
                    MessageBox.Show("Thêm phiếu xuất thành công!");
                    LoadPhieuXuat();
                    PhieuXuatBinding();
                }
                else
                {
                    MessageBox.Show("Thêm phiếu xuất thất bại!");
                }

                isAdding = false;
                simpleButton7.Text = "Thêm";
                simpleButton5.Enabled = true;
                simpleButton8.Enabled = true;
                HienThiTxt(false);
            }
            else
            {
                isAdding = true;
                simpleButton7.Text = "Lưu";
                simpleButton5.Enabled = false;
                simpleButton8.Enabled = false;
                HienThiTxt(true);
                textEdit6.Text = SinhMaTuDongPXDAO.Instance.GetMaPhieuXuat();
                dateEdit1.DateTime = DateTime.Now;
                comboBoxEdit1.Text = "";
                textEdit8.Text = "";
                gridControl2.DataSource = null; // Clear detail grid when adding new master
            }
        }

        private void sbHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            simpleButton7.Text = "Thêm";
            simpleButton5.Enabled = true;
            simpleButton8.Enabled = true;
            HienThiTxt(false);
            PhieuXuatBinding();
        }

        private void sbSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxEdit1.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                return;
            }
            string maPhieuXuat = textEdit6.Text;
            DateTime ngayXuat = dateEdit1.DateTime;
            string maNV = comboBoxEdit1.Text;
            string lyDoXuat = textEdit8.Text;

            PhieuXuatDTO px = new PhieuXuatDTO(maPhieuXuat, ngayXuat, maNV, lyDoXuat);
            if (PhieuXuatDAO.Instance.SuaPhieuXuat(px))
            {
                MessageBox.Show("Sửa phiếu xuất thành công!");
                LoadPhieuXuat();
                PhieuXuatBinding();
            }
            else
            {
                MessageBox.Show("Sửa phiếu xuất thất bại!");
            }
        }

        private void sbXoa_Click(object sender, EventArgs e)
        {
            string maPhieuXuat = textEdit6.Text;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu xuất " + maPhieuXuat + "?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (PhieuXuatDAO.Instance.XoaPhieuXuat(maPhieuXuat))
                {
                    MessageBox.Show("Xóa phiếu xuất thành công!");
                    LoadPhieuXuat();
                    PhieuXuatBinding();
                }
                else
                {
                    MessageBox.Show("Xóa phiếu xuất thất bại!");
                }
            }
        }
        #endregion

        #region ChiTietPhieuXuat CRUD
        private void sbThemChiTiet_Click(object sender, EventArgs e)
        {
            if (isAddingDetail)
            {
                if (string.IsNullOrEmpty(textEdit2.Text) || string.IsNullOrEmpty(textEdit3.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }
                
                // Generate new ID for new record
                string maCTPX = SinhMaTuDongCTPXDAO.Instance.GetMaChiTietPhieuXuat();
                string maPhieuXuat = textBox1.Text;
                string maMH = textEdit2.Text;
                int soLuongXuat = int.Parse(textEdit3.Text);
                string ghiChu = textEdit5.Text;

                ChiTietPhieuXuatDTO ctpx = new ChiTietPhieuXuatDTO(maCTPX, maPhieuXuat, maMH, soLuongXuat, ghiChu);
                if (ChiTietPhieuXuatDAO.Instance.ThemChiTietPhieuXuat(ctpx))
                {
                    MessageBox.Show("Thêm chi tiết thành công!");
                    LoadChiTietPhieuXuat(maPhieuXuat);
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết thất bại! (Không đủ hàng)");
                }
                
                isAddingDetail = false;
                simpleButton1.Text = "Thêm";
                simpleButton10.Enabled = true;
                simpleButton9.Enabled = true;
                HienThiTxtChiTiet(false);
                ChiTietPhieuXuatBinding(); // Restore bindings
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Vui lòng chọn phiếu xuất trước!");
                    return;
                }
                isAddingDetail = true;
                simpleButton1.Text = "Lưu";
                simpleButton10.Enabled = false;
                simpleButton9.Enabled = false;
                HienThiTxtChiTiet(true);

                textEdit2.DataBindings.Clear();
                textEdit3.DataBindings.Clear();
                textEdit5.DataBindings.Clear();

                textEdit2.Text = "";
                textEdit3.Text = "0";
                textEdit5.Text = "";
            }
        }

        private void sbHuyChiTiet_Click(object sender, EventArgs e)
        {
            isAddingDetail = false;
            simpleButton1.Text = "Thêm";
            simpleButton10.Enabled = true;
            simpleButton9.Enabled = true;
            HienThiTxtChiTiet(false);
            ChiTietPhieuXuatBinding();
        }

        private void sbSuaChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text) || string.IsNullOrEmpty(textEdit3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            string maCTPX = gridView2.GetFocusedRowCellValue("MaCTPX").ToString();
            string maPhieuXuat = textBox1.Text;
            string maMH = textEdit2.Text;
            int soLuongXuat = int.Parse(textEdit3.Text);
            string ghiChu = textEdit5.Text;

            ChiTietPhieuXuatDTO ctpx = new ChiTietPhieuXuatDTO(maCTPX, maPhieuXuat, maMH, soLuongXuat, ghiChu);

            if (ChiTietPhieuXuatDAO.Instance.SuaChiTietPhieuXuat(ctpx, soLuongCu))
            {
                MessageBox.Show("Sửa chi tiết thành công!");
                LoadChiTietPhieuXuat(maPhieuXuat);
                ChiTietPhieuXuatBinding();
            }
            else
            {
                MessageBox.Show("Sửa chi tiết thất bại! (Không đủ hàng)");
            }
        }

        private void sbXoaChiTiet_Click(object sender, EventArgs e)
        {
            string maCTPX = gridView2.GetFocusedRowCellValue("MaCTPX").ToString();
            string maMH = gridView2.GetFocusedRowCellValue("MaMH").ToString();
            int soLuongXuat = (int)gridView2.GetFocusedRowCellValue("SoLuongXuat");

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết phiếu xuất " + maCTPX + "?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ChiTietPhieuXuatDAO.Instance.XoaChiTietPhieuXuat(maCTPX, maMH, soLuongXuat))
                {
                    MessageBox.Show("Xóa chi tiết thành công!");
                    LoadChiTietPhieuXuat(textBox1.Text);
                    ChiTietPhieuXuatBinding();
                }
                else
                {
                    MessageBox.Show("Xóa chi tiết thất bại!");
                }
            }
        }
        #endregion
    }
}