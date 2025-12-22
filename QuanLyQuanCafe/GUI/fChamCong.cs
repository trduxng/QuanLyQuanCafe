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
    public partial class fChamCong : DevExpress.XtraEditors.XtraForm
    {
        public fChamCong()
        {
            InitializeComponent();
        }
        QLCaFeDataContext db = new QLCaFeDataContext();
        bool check;
        private void Antxt()
        {
            txtEMaCC.ReadOnly =  dateENgayLam.ReadOnly = true;

        }
        private void Hienbtn()
        {
            sbThem.Enabled = sbSua.Enabled = sbXoa.Enabled = sbLoad.Enabled = true;
            sbLuu.Enabled = sbHuy.Enabled = false;

        }
        private void Clear()
        {
            txtEMaCC.Text = null;
            cmbMNV.Text = null;
            cmbSoCaLam.Text = null;
            dateENgayLam.Text = null;

        }
        private void fChamCong_Load(object sender, EventArgs e)
        {
            loaddata();
            display(true);
            Loadcmb();
            laydulieu();
        }
        private void loaddata()
        {
            var dsChamCong = db.ChamCongs.ToList();
            GrCtrlChamCong.DataSource = dsChamCong;
        }

        private void laydulieu()
        {
            txtEMaCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            cmbMNV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            dateENgayLam.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            cmbSoCaLam.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();

        }

        private void GrCtrlChamCong_Click(object sender, EventArgs e)
        {
            laydulieu();
        }
        private void display(bool e)
        {
            sbThem.Enabled = e;
            sbSua.Enabled = e;
            sbXoa.Enabled = e;
            sbLuu.Enabled = !e;
            sbHuy.Enabled = !e;
        }
        private void Loadcmb()
        {
            var MNV = (from mnv in db.NhanViens select mnv.MaNV).ToList();
            cmbMNV.DataSource = MNV;
            cmbSoCaLam.Items.Add(1);
            cmbSoCaLam.Items.Add(2);
            cmbSoCaLam.Items.Add(3);
        }

        private void sbThem_Click(object sender, EventArgs e)
        {
            SinhMaTuDongCCDAO nvDAO = new SinhMaTuDongCCDAO();
            txtEMaCC.Text = nvDAO.XuLyMaChamCong();
            display(false);
            Loadcmb();
            check = true;
            txtEMaCC.Enabled = false;
            
        }

        private void sbSua_Click(object sender, EventArgs e)
        {
            display(false);
            Loadcmb();
            check = false;
        }

        private void sbXoa_Click(object sender, EventArgs e)
        {
            ChamCong cc = new ChamCong();
            cc = db.ChamCongs.Where(s => s.MaChamCong == txtEMaCC.Text).SingleOrDefault();
            try
            {
                db.ChamCongs.DeleteOnSubmit(cc);
                db.SubmitChanges();
                XtraMessageBox.Show("Xóa Thành công");
                loaddata();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbLuu_Click(object sender, EventArgs e)
        {
            display(true);
            if (check)
            {
                ChamCong cc = new ChamCong();
                if (string.IsNullOrEmpty(txtEMaCC.Text))
                {
                    XtraMessageBox.Show("Mã chấm công không được để trống", "Thông báo");
                }
                else
                {
                    cc.MaChamCong = txtEMaCC.Text;
                }

                cc.MaNV = cmbMNV.Text;
                cc.NgayLam = dateENgayLam.DateTime;

                if (cmbSoCaLam.Text == "1")
                {
                    cc.SoCaLam = 1;
                }
                else if (cmbSoCaLam.Text == "2")
                {
                    cc.SoCaLam = 2;
                }
                else if (cmbSoCaLam.Text == "3")
                {
                    cc.SoCaLam = 3;
                }
                try
                {
                    db.ChamCongs.InsertOnSubmit(cc);
                    db.SubmitChanges();
                    XtraMessageBox.Show("Thêm Thành công");
                    loaddata();

                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Thêm thất bại","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ChamCong cc2 = new ChamCong();
                cc2 = db.ChamCongs.Where(s => s.MaChamCong == txtEMaCC.Text).SingleOrDefault();
                cc2.MaNV = cmbMNV.Text;
                cc2.NgayLam = dateENgayLam.DateTime;

                if (cmbSoCaLam.Text == "1")
                {
                    cc2.SoCaLam = 1;
                }
                else if (cmbSoCaLam.Text == "2")
                {
                    cc2.SoCaLam = 2;
                }
                else if (cmbSoCaLam.Text == "3")
                {
                    cc2.SoCaLam = 3;
                }
                try
                {
                    db.SubmitChanges();
                    XtraMessageBox.Show("Sửa Thành công");
                    loaddata();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sbLoad_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void sbHuy_Click(object sender, EventArgs e)
        {
            Hienbtn();
            Antxt();
            Clear();
        }
    }
}