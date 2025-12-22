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
    public partial class fThongKephieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public fThongKephieuNhap()
        {
            InitializeComponent();
        }
        QLCaFeDataContext db = new QLCaFeDataContext();

        private void loaddulieu()
        {
            try
            {
                var tkPhieuNhap = (from tkpn in db.TKPhieuNhaps
                                   where tkpn.NgayNhap >= DateTime.Parse(dtptungay.Text) && tkpn.NgayNhap <= DateTime.Parse(dtptoingay.Text)
                                   select tkpn).ToList();
                var count = tkPhieuNhap.Count();
                if (count == 0)
                {
                    XtraMessageBox.Show("Không có dữ liệu trong khoảng thời gian vừa chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    gridControl1.DataSource = tkPhieuNhap;
                }
            }
            catch(Exception)
            { }
        }
        private void fThongKephieuNhap_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dtptungay.Text != "")
            {
                if (dtptoingay.Text != "")
                {
                    loaddulieu();
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa nhập đến ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập từ ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}