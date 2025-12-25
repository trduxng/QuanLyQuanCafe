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
                DateTime tuNgay = dtptungay.DateTime.Date;
                // Lấy đến hết ngày cuối cùng (23:59:59)
                DateTime denNgay = dtptoingay.DateTime.Date.AddDays(1).AddSeconds(-1);

                DataTable data = DAO.PhieuXuatDAO.Instance.GetThongKePhieuXuat(tuNgay, denNgay);
                
                if (data.Rows.Count == 0)
                {
                    gridControl1.DataSource = null;
                    XtraMessageBox.Show("Không có dữ liệu trong khoảng thời gian vừa chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    gridControl1.DataSource = data;
                    // Tự động tạo lại cột theo tên cột trong Procedure (Tiếng Việt)
                    gridView1.PopulateColumns();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void fThongKePhieuXuat_Load(object sender, EventArgs e)
        {
            // Set giá trị mặc định cho DateEdit nếu cần
            dtptungay.DateTime = DateTime.Now.Date;
            dtptoingay.DateTime = DateTime.Now.Date;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(dtptungay.EditValue != null)
            {
                if(dtptoingay.EditValue != null)
                {
                    loaddulieu();
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa nhập đến ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập từ ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        
    }
}