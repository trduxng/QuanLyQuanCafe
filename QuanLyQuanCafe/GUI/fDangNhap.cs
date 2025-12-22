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
    public partial class fDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public fDangNhap()
        {
            InitializeComponent();
        }
        private void hamlogin()
        {
            var kt = (from TaiKhoan in db.TaiKhoans
                      where TaiKhoan.TenDangNhap == txtETK.Text.Trim() && TaiKhoan.MK == txtEMK.Text
                      select TaiKhoan).SingleOrDefault();
            if (kt == null)
            {
                XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.Vui lòng đăng nhập lại","Lỗi",MessageBoxButtons.OK);
            }
            else
            {
                fGiaoDienChinh f = new fGiaoDienChinh();
                this.Hide();
                f.temp = txtETK.Text;
                f.ShowDialog();
                this.Show();
            }
        }
        QLCaFeDataContext db = new QLCaFeDataContext();
        private void sbDN_Click(object sender, EventArgs e)
        {
            hamlogin();
        }

        private void sbThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void txtEMK_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                hamlogin();
            }
        }

        private void txtETK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                hamlogin();
            }
        }

        private void chkEHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEHienThiMK.Checked)
            {
                txtEMK.Properties.UseSystemPasswordChar = false;
            }
            else
                txtEMK.Properties.UseSystemPasswordChar = true;
        }
    }
}