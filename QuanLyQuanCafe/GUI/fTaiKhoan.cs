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
using QuanLyQuanCafe.DAO;

namespace QuanLyQuanCafe
{
    public partial class fTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public fTaiKhoan()
        {
            InitializeComponent();
        }
        QLCaFeDataContext db = new QLCaFeDataContext();
        bool check;
        private void fTaiKhoan_Load(object sender, EventArgs e)
        {
            loadData();
            display(true);
            txtEMaTK.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtETenTk.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            int chucvu = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString());
            txtMK.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            cmbMNV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();

            if (chucvu == 1)
            {
                cmbCV.Text = "Admin";
            }
            else
            {
                cmbCV.Text = "Nhân viên";
            }
        }
        private void loadData()
        {
            var dsTK = db.TaiKhoans.ToList();
            grCtrlTaiKhoan.DataSource = dsTK;
        }
        private void display(bool e)
        {
            sbThem.Enabled = e;
            sbSua.Enabled = e;
            sbXoa.Enabled = e;
            sbLuu.Enabled = !e;
            sbHuy.Enabled = !e;
        }
        private void clear()
        {
            txtEMaTK.Text = "";
            txtETenTk.Text = "";
            txtMK.Text = "";
        }
        private void grCtrlTaiKhoan_Click_1(object sender, EventArgs e)
        {
            txtEMaTK.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtETenTk.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            int chucvu = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString());
            txtMK.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            cmbMNV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
            if (chucvu == 1)
            {
                cmbCV.Text = "Admin";
            }
            else
            {
                cmbCV.Text = "Nhân viên";
            }
        }

        private void sbThem_Click_1(object sender, EventArgs e)
        {
            SinhMaTuDongTaiKhoanDAO nvDAO = new SinhMaTuDongTaiKhoanDAO();
            txtEMaTK.Text = nvDAO.XuLyMaTK();
            display(false);
            txtEMaTK.Enabled = false;
            var MNV = (from mnv in db.NhanViens select mnv.MaNV).ToList();
            cmbMNV.DataSource = MNV;
            cmbCV.Items.Add("Admin");
            cmbCV.Items.Add("Nhân viên");
            check = true;
            txtETenTk.Text = "";
            txtMK.Text = "";
            txtETenTk.Focus();
        }

        private void sbSua_Click_1(object sender, EventArgs e)
        {
            display(false);
            clear();
            txtEMaTK.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtETenTk.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            txtMK.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            var MNV = (from mnv in db.TaiKhoans select mnv.MaNV).ToList();
            cmbMNV.DataSource = MNV;
            cmbCV.Items.Add("Admin");
            cmbCV.Items.Add("Nhân viên");
            check = false;
        }
        private void sbXoa_Click_1(object sender, EventArgs e)
        {
            TaiKhoan TK = new TaiKhoan();
            TK = db.TaiKhoans.Where(s => s.MaTK == txtEMaTK.Text).SingleOrDefault();
            try
            {
                db.TaiKhoans.DeleteOnSubmit(TK);
                db.SubmitChanges();
                XtraMessageBox.Show("Xóa Thành công", "Thông báo");
                loadData();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Xóa Thật bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbLuu_Click_1(object sender, EventArgs e)
        {
            display(true);
            if (check)
            {
                TaiKhoan tk = new TaiKhoan();
                if (string.IsNullOrEmpty(txtEMaTK.Text))
                {
                    XtraMessageBox.Show("Mã tài khoản không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMaTK.Focus();
                }
                else
                {
                    tk.MaTK = txtEMaTK.Text;
                }
                if (string.IsNullOrEmpty(txtETenTk.Text))
                {
                    XtraMessageBox.Show("Tên tài khoản không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenTk.Focus();
                }
                else
                {
                    tk.TenDangNhap = txtETenTk.Text;
                }
                if (string.IsNullOrEmpty(txtMK.Text))
                {
                    XtraMessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMK.Focus();
                }
                else
                {
                    tk.MK = txtMK.Text;
                }
                if (cmbCV.Text == "Admin")
                {
                    tk.LoaiTk = 1;
                }
                else
                {
                    tk.LoaiTk = 2;
                }
                tk.MaNV = cmbMNV.Text;
                try
                {
                    db.TaiKhoans.InsertOnSubmit(tk);
                    db.SubmitChanges();
                    XtraMessageBox.Show("Thêm thanh công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                TaiKhoan tk = new TaiKhoan();
                tk = db.TaiKhoans.Where(s => s.MaTK == txtEMaTK.Text).SingleOrDefault();
                if (string.IsNullOrEmpty(txtEMaTK.Text))
                {
                    XtraMessageBox.Show("Mã tài khoản không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMaTK.Focus();
                }
                else
                {
                    tk.MaTK = txtEMaTK.Text;
                }
                if (string.IsNullOrEmpty(txtETenTk.Text))
                {
                    XtraMessageBox.Show("Tên tài khoản không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenTk.Focus();
                }
                else
                {
                    tk.TenDangNhap = txtETenTk.Text;
                }
                if (string.IsNullOrEmpty(txtMK.Text))
                {
                    XtraMessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMK.Focus();
                }
                else
                {
                    tk.MK = txtMK.Text;
                }
                if (cmbCV.Text == "Admin")
                {
                    tk.LoaiTk = 1;
                }
                else
                {
                    tk.LoaiTk = 2;
                }
                tk.MaNV = cmbMNV.Text;
                try
                {
                    db.SubmitChanges();
                   XtraMessageBox.Show("Sửa Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void sbHuy_Click_1(object sender, EventArgs e)
        {

            display(true);
            txtEMaTK.Text = null;
            txtETenTk.Text = null;
            txtMK.Text = null;
        }
        private void sbLoad_Click_1(object sender, EventArgs e)
        {
            loadData();
            XtraMessageBox.Show("Load thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        private void gridView1_CustomColumnDisplayText_1(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "LoaiTk")
            {
                if (Convert.ToInt32(e.Value) == 1)
                {
                    e.DisplayText = "Admin";
                }
                else
                {
                    e.DisplayText = "Nhân viên";
                }
            }
        }

       

        

        

       

        

       
        
    }
}