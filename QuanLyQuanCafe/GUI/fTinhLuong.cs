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
    public partial class fTinhLuong : DevExpress.XtraEditors.XtraForm
    {
        public fTinhLuong()
        {
            InitializeComponent();
        }
        QLCaFeDataContext db = new QLCaFeDataContext();
        private void fTinhLuong_Load(object sender, EventArgs e)
        {
            var nv = (from manv in db.NhanViens select manv.MaNV).ToList();
            cmbMaNV.DataSource = nv;

            txtTienCa.Enabled = false;
        }
        private void TinhCong()
        {

        }
        private void sbLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var tinhcong = db.ChamCongs.Where(cc => cc.MaNV == cmbMaNV.Text &&
                cc.NgayLam >= DateTime.Parse(datETuNgay.Text) &&
                cc.NgayLam <= DateTime.Parse(datEDenNgay.Text)).Sum(cc => cc.SoCaLam);
                var ChamCong = (from cc in db.ChamCongs
                                where (cc.MaNV == cmbMaNV.Text &&
                                cc.NgayLam >= DateTime.Parse(datETuNgay.Text) &&
                                cc.NgayLam <= DateTime.Parse(datEDenNgay.Text))
                                select cc).ToList();
                gridControl1.DataSource = ChamCong;
                txtTienCa.Enabled = true;
                lblsoca.Text = tinhcong.ToString();
                sbTinhLuong.Enabled = true;
            }
            catch(Exception)
            {
                XtraMessageBox.Show("Không có dữ liệu chấm công của nhân viên này trong khoảng thời gian đã chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sbTinhLuong.Enabled = false;
            }
        }

        private void sbTinhLuong_Click(object sender, EventArgs e)
        {
            var tinhcong = db.ChamCongs.Where(cc => cc.MaNV == cmbMaNV.Text &&
               cc.NgayLam >= DateTime.Parse(datETuNgay.Text) &&
               cc.NgayLam <= DateTime.Parse(datEDenNgay.Text)).Sum(cc => cc.SoCaLam);
            if (string.IsNullOrEmpty(txtTienCa.Text))
            {
                XtraMessageBox.Show("Hãy nhập số tiền của 1 ca làm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var tinhtien = Convert.ToInt32(tinhcong) * Convert.ToInt32(txtTienCa.Text);
                txtETongTien.Text = tinhtien.ToString();

            }
        }
    }
}