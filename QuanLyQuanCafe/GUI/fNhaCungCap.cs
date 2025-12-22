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
    public partial class fNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        QLCaFeDataContext db = new QLCaFeDataContext();
        NhaCungCap ncc = new NhaCungCap();
        public fNhaCungCap()
        {
            InitializeComponent();
        }

        private void fNhaCungCap_Load(object sender, EventArgs e)
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
            txtEMaNhaCC.ReadOnly = txtETenNhaCC.ReadOnly = txtEDiaChiNhaCC.ReadOnly = txtESDT.ReadOnly = true;

        }

        // Hiện các dữ liệu nhập
        private void Hientxt()
        {
            txtEMaNhaCC.ReadOnly = txtETenNhaCC.ReadOnly = txtEDiaChiNhaCC.ReadOnly = txtESDT.ReadOnly = false;

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
            txtEMaNhaCC.Text = null;
            txtETenNhaCC.Text = null;
            txtESDT.Text = null;
            txtEDiaChiNhaCC.Text = null;
        }

        //Hàm load data lên gridcontrol
        private void loadgrifcontrol()
        {
            var dsNCC= db.NhaCungCaps.ToList();
            grCtrlNCC.DataSource = dsNCC;
        }
        //Hàm load dữ liệu cho sự kiện click của gridcontrol
        private void loadclick()
        {
            txtEMaNhaCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtETenNhaCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            txtEDiaChiNhaCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            txtESDT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
        }

        private void grCtrlNCC_Click(object sender, EventArgs e)
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
            SinhMaTuDongNCCDAO nvDAO = new SinhMaTuDongNCCDAO();
            txtEMaNhaCC.Text = nvDAO.XuLyMaNCC();
            isThem = true;
            Hientxt();
            Anbtn();
            txtETenNhaCC.Text = null;
            txtESDT.Text = null;
            txtEDiaChiNhaCC.Text = null;
            txtEMaNhaCC.Enabled = false;
            txtETenNhaCC.Focus();
        }
        //Sự kiện click của nút Sửa
        private void sbSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            Anbtn();
            Hientxt();
            txtEMaNhaCC.Enabled = false;
        }

        //Hàm viết cho nút Lưu
        private bool save()
        {
            if (isThem)
            {
                NhaCungCap ncc = new NhaCungCap();
                if (string.IsNullOrEmpty(txtEMaNhaCC.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập mã nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMaNhaCC.Focus();
                    return false;
                }
                else
                {
                    ncc.MaNhaCC = txtEMaNhaCC.Text;

                }
                if (string.IsNullOrEmpty(txtETenNhaCC.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenNhaCC.Focus();
                    return false;

                }
                else
                {
                    ncc.TenNhaCC = txtETenNhaCC.Text;

                }

                if (string.IsNullOrEmpty(txtEDiaChiNhaCC.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập địa chỉ nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEDiaChiNhaCC.Focus();
                    return false;
                }
                else
                {
                    ncc.DiaChi = txtEDiaChiNhaCC.Text;
                }
                if (string.IsNullOrEmpty(txtESDT.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtESDT.Focus();
                    return false;
                }
                else
                {
                    ncc.SDT = txtESDT.Text;
                }
                try
                {
                    db.NhaCungCaps.InsertOnSubmit(ncc);
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
                NhaCungCap ncc1 = new NhaCungCap();
                ncc1 = db.NhaCungCaps.Where(s => s.MaNhaCC== txtEMaNhaCC.Text).SingleOrDefault();
                if (string.IsNullOrEmpty(txtETenNhaCC.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenNhaCC.Focus();
                    return false;

                }
                else
                {
                    ncc1.TenNhaCC = txtETenNhaCC.Text;

                }

                if (string.IsNullOrEmpty(txtEDiaChiNhaCC.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập địa chỉ nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEDiaChiNhaCC.Focus();
                    return false;
                }
                else
                {
                    ncc1.DiaChi = txtEDiaChiNhaCC.Text;
                }
                if (string.IsNullOrEmpty(txtESDT.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtESDT.Focus();
                    return false;
                }
                else
                {
                    ncc1.SDT = txtESDT.Text;
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

        private void sbXoa_Click(object sender, EventArgs e)
        {
            int row_index = gridView1.FocusedRowHandle;
            string col_FieldName = "MaNhaCC";
            object value = gridView1.GetRowCellValue(row_index, col_FieldName);
            if (value != null)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa mã NCC: " + value.ToString(), "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    NhaCungCap ncc = db.NhaCungCaps.Where(s => s.MaNhaCC == value).SingleOrDefault();
                    if (ncc != null)
                    {
                        try
                        {
                            db.NhaCungCaps.DeleteOnSubmit(ncc);
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
    }
}