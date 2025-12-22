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
    public partial class fThongTinTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        QLCaFeDataContext db = new QLCaFeDataContext();
        public fThongTinTaiKhoan()
        {
            InitializeComponent();
        }
        public string maNV;
        public string TenDN;
        private void fThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            txtEMaTaiKhoan.Enabled = txtETenDangNhap.Enabled = false;
            var MaTK = (from TaiKhoan in db.TaiKhoans
                            where TaiKhoan.MaNV== maNV
                            select TaiKhoan.MaTK).SingleOrDefault();
            txtEMaTaiKhoan.Text = MaTK.ToString();
            txtETenDangNhap.Text = TenDN.ToString();

        }

        private void sbCapNhat_Click(object sender, EventArgs e)
        {
            TaiKhoan td = new TaiKhoan();
            td = db.TaiKhoans.Where(s => s.MaTK == txtEMaTaiKhoan.Text).SingleOrDefault();
            var KT = (from TaiKhoan in db.TaiKhoans where TaiKhoan.TenDangNhap == txtETenDangNhap.Text && TaiKhoan.MK == txtEMK.Text select TaiKhoan.MaTK).SingleOrDefault();
            if (KT == null)
            {
                XtraMessageBox.Show("Mật khẩu không hợp lệ. Vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (string.IsNullOrEmpty(txtEMK.Text))
                {
                    XtraMessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(txtEMKM.Text))
                {
                    XtraMessageBox.Show("Mật khẩu mới không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(txtEXNMK.Text))
                {
                    XtraMessageBox.Show("Xác nhận mật khẩu mới không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtEMKM.Text != txtEXNMK.Text)
                {
                    XtraMessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtEMKM.Text == txtEMK.Text)
                {
                    XtraMessageBox.Show("Mật khẩu mới trùng mật khẩu cũ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        td.MK = txtEMKM.Text;
                        db.SubmitChanges();
                        XtraMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        clear();
                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        private void clear()
        {
            txtEMK.Text = "";
            txtEMKM.Text = "";
            txtEXNMK.Text = "";
        }

        private void chkEMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEMK.Checked == true)
            {
                txtEMK.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtEMK.Properties.UseSystemPasswordChar = true;
            }
        }

        private void chkEMKM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEMKM.Checked == true)
            {
                txtEMKM.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtEMKM.Properties.UseSystemPasswordChar = true;
            }
        }

        private void chkEXNMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEXNMK.Checked == true)
            {
                txtEXNMK.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtEXNMK.Properties.UseSystemPasswordChar = true;
            }
        }

        private void sbHuy_Click(object sender, EventArgs e)
        {
            clear();
        }

        
    }
}