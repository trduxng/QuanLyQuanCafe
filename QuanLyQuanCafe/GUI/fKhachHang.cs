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
    public partial class fKhachHang : DevExpress.XtraEditors.XtraForm
    {
        QLCaFeDataContext db = new QLCaFeDataContext();
        KhachHang kh = new KhachHang();
        public fKhachHang()
        {
            InitializeComponent();
        }
        private void fKhachHang_Load(object sender, EventArgs e)
        {
            loadgrifcontrol();
            Antxt();
            sbHuy.Enabled = sbLuu.Enabled = false;
            sbThem.Focus();
            loadclick();
        }

        // Ẩn các dữ liệu nhập
        private void Antxt()
        {
            txtEMaKH.ReadOnly = txtETenKH.ReadOnly = txtEDiaChi.ReadOnly = txtESDT.ReadOnly = true;

        }

        // Hiện các dữ liệu nhập
        private void Hientxt()
        {
            txtEMaKH.ReadOnly = txtETenKH.ReadOnly = txtEDiaChi.ReadOnly = txtESDT.ReadOnly = false;

        }

        // Hiện các nút chức năng
        private void Hienbtn()
        {
            sbThem.Enabled = sbSua.Enabled = sbXoa.Enabled = sbLoad.Enabled = true;
            sbLuu.Enabled = sbHuy.Enabled = false;

        }

        //Ẩn các nút chức năng
        private void Anbtn()
        {
            sbThem.Enabled = sbSua.Enabled = sbXoa.Enabled = sbLoad.Enabled = false;
            sbLuu.Enabled = sbHuy.Enabled = true;
        }

        //Xóa rỗng dữ liệu nhập
        private void Clear()
        {
            txtEMaKH.Text = null;
            txtETenKH.Text = null;
            txtESDT.Text = null;
            txtEDiaChi.Text = null;
        }

        //Hàm load data lên gridcontrol
        private void loadgrifcontrol()
        {
            var dsKH = db.KhachHangs.ToList();
            grCtrlKH.DataSource = dsKH;
        }
        //Hàm load dữ liệu cho sự kiện click của gridcontrol
        private void loadclick()
        {
            txtEMaKH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtETenKH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            txtEDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            txtESDT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
        }

        private void grCtrlKH_Click(object sender, EventArgs e)
        {
            try
            {
                loadclick();
            }
            catch (Exception)
            {

            }
        }

        //Sự kiện click của nút thêm
        private bool isThem = true;
        private void sbThem_Click(object sender, EventArgs e)
        {
            SinhMaTuDongKHDAO nvDAO = new SinhMaTuDongKHDAO();
            txtEMaKH.Text = nvDAO.XuLyMaKH();
            isThem = true;
            Hientxt();
            Anbtn();
            txtEMaKH.Enabled = false;
            txtETenKH.Focus();
            txtETenKH.Text = null;
            txtESDT.Text = null;
            txtEDiaChi.Text = null;
        }

        //Sự kiện click của nút Sửa
        private void sbSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            Anbtn();
            Hientxt();
            txtEMaKH.Enabled = false;
        }

        //Hàm viết cho nút Lưu
        private bool save()
        {
            if (isThem)
            {
                KhachHang kh = new KhachHang();
                if (string.IsNullOrEmpty(txtEMaKH.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập mã khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMaKH.Focus();
                    return false;
                }
                else
                {
                    kh.MaKH = txtEMaKH.Text;

                }
                if (string.IsNullOrEmpty(txtETenKH.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenKH.Focus();
                    return false;

                }
                else
                {
                    kh.TenKH = txtETenKH.Text;

                }

                if (string.IsNullOrEmpty(txtEDiaChi.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập địa chỉ khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEDiaChi.Focus();
                    return false;
                }
                else
                {
                    kh.DiaChi = txtEDiaChi.Text;
                }
                if (string.IsNullOrEmpty(txtESDT.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtESDT.Focus();
                    return false;
                }
                else
                {
                    kh.SDT = txtESDT.Text;
                }
                try
                {
                    db.KhachHangs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    loadgrifcontrol();
                    XtraMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hienbtn();
                    Antxt();
                    Clear();
                    return true;
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    Hienbtn();
                    return false;
                }

            }
            else
            {
                KhachHang kh1 = new KhachHang();
                kh1 = db.KhachHangs.Where(s => s.MaKH == txtEMaKH.Text).SingleOrDefault();
                if (string.IsNullOrEmpty(txtETenKH.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenKH.Focus();
                    return false;

                }
                else
                {
                    kh1.TenKH = txtETenKH.Text;

                }

                if (string.IsNullOrEmpty(txtEDiaChi.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập địa chỉ khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEDiaChi.Focus();
                    return false;
                }
                else
                {
                    kh1.DiaChi = txtEDiaChi.Text;
                }
                if (string.IsNullOrEmpty(txtESDT.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtESDT.Focus();
                    return false;
                }
                else
                {
                    kh1.SDT = txtESDT.Text;
                }
                try
                {
                    db.SubmitChanges();
                    loadgrifcontrol();
                    XtraMessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hienbtn();
                    Antxt();
                    Clear();
                    return true;
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    Hienbtn();
                    return false;
                }
            }
        }
        private void sbXoa_Click(object sender, EventArgs e)
        {
            int row_index = gridView1.FocusedRowHandle;
            string col_FieldName = "MaKH";
            object value = gridView1.GetRowCellValue(row_index, col_FieldName);
            if (value != null)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa mã KH: " + value.ToString(), "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    KhachHang kh = db.KhachHangs.Where(s => s.MaKH == value).SingleOrDefault();
                    if (kh != null)
                    {
                        try
                        {
                            db.KhachHangs.DeleteOnSubmit(kh);
                            db.SubmitChanges();
                            loadgrifcontrol();
                            XtraMessageBox.Show("Đã xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            XtraMessageBox.Show("Xóa thất bại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
        }
        //Sự kiện click cho nút lưu
        private void sbLuu_Click(object sender, EventArgs e)
        {
            try
            {
                save();
            }
            catch (Exception)
            {

            }
        }

        //Sự kiện click cho nút hủy
        private void sbHuy_Click(object sender, EventArgs e)
        {
            Hienbtn();
            Antxt();
        }

        private void sbLoad_Click(object sender, EventArgs e)
        {
            try
            {
                loadgrifcontrol();
                XtraMessageBox.Show("Đã load dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Load dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       

       

       
    }
}