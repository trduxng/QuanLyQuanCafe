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
    public partial class fThongKePhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        public fThongKePhieuXuat()
        {
            InitializeComponent();
        }
        QLCaFeDataContext db = new QLCaFeDataContext();
        private void loaddulieu()
        {
            try
            {

                var CTPX = (from ctpx in db.TKPhieuXuats
                            where ctpx.NgayXuat >= DateTime.Parse(dtptungay.Text) && ctpx.NgayXuat <= DateTime.Parse(dtptoingay.Text)
                            select ctpx).ToList();
                var count = CTPX.Count();
                if (count == 0)
                {
                    XtraMessageBox.Show("Không có dữ liệu trong khoảng thời gian vừa chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    gridControl1.DataSource = CTPX;
                }
            }
            catch(Exception)
            {

            }

        }
        private void fThongKePhieuXuat_Load(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(dtptungay.Text!="")
            {
                if(dtptoingay.Text!="")
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