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
using DevExpress.XtraGrid;
namespace QuanLyQuanCafe
{
    public partial class fBanAn : DevExpress.XtraEditors.XtraForm
    {
        QLCaFeDataContext db = new QLCaFeDataContext();
        BanAn ba = new BanAn();
        public fBanAn()
        {
            InitializeComponent();
            Trangthai();
        }

        private void fBanAn_Load(object sender, EventArgs e)
        {
            loadgrifcontrol();
            Antxt();
            Hienbtn();
            sbThem.Focus();
            loadclick();
        }
        // Ẩn các dữ liệu nhập
        private void Antxt()
        {
            txtEMaBan.ReadOnly = txtETenBan.ReadOnly = cbbETrangThai.ReadOnly = true;

        }

         // Hiện các dữ liệu nhập
        private void Hientxt()
        {
            txtEMaBan.ReadOnly = txtETenBan.ReadOnly = cbbETrangThai.ReadOnly  = false;
 
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
            txtEMaBan.Text = null;
            txtETenBan.Text = null;
            cbbETrangThai.Text = null;
        }

        //Hàm load data lên gridcontrol
        private void loadgrifcontrol()
        {
            var dsBanAn = db.BanAns.ToList();
            grCtrBanAn.DataSource = dsBanAn;
        }


        //Hàm load dữ liệu lên comboboxGioiTinh
        private void Trangthai()
        {

            cbbETrangThai.Properties.Items.Add("Có người");
            cbbETrangThai.Properties.Items.Add("Trống");
        }
        // Hàm load dữ liệu lên lkELoaiMon

        //Hàm load dữ liệu cho sự kiện click của gridcontrol
        private void loadclick()
        {
            txtEMaBan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtETenBan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            cbbETrangThai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            
        }

        private void grCtrBanAn_Click(object sender, EventArgs e)
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
            isThem = true;
            Hientxt();
            Anbtn();
            Clear();
            txtEMaBan.Enabled = true;
            txtEMaBan.Focus();
        }

        //Sự kiện click của nút Sửa
        private void sbSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            Anbtn();
            Hientxt();
            txtEMaBan.Enabled = false;
        }

        //Hàm viết cho nút Lưu
        private bool save()
        {
            if (isThem)
            {
                BanAn ba = new BanAn();
                if (string.IsNullOrEmpty(txtEMaBan.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập mã bàn ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMaBan.Focus();
                    return false;
                }
                else
                {
                    ba.MaBan = Convert.ToInt32(txtEMaBan.Text);

                }
                if (string.IsNullOrEmpty(txtETenBan.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên bàn ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenBan.Focus();
                    return false;

                }
                else
                {
                    ba.TenBan = txtETenBan.Text;

                }
                
                if (string.IsNullOrEmpty(cbbETrangThai.Text))
                {
                    XtraMessageBox.Show("Bạn chưa chọn trạng thái", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbETrangThai.Focus();
                    return false;
                }
                else
                {
                    ba.TrangThai = cbbETrangThai.EditValue.ToString();
                }
                try
                {
                    db.BanAns.InsertOnSubmit(ba);
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
                BanAn ba1 = new BanAn();
                ba1 = db.BanAns.Where(s => s.MaBan == Convert.ToInt32(txtEMaBan.Text)).SingleOrDefault();
                if (string.IsNullOrEmpty(txtETenBan.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên bàn ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenBan.Focus();
                    return false;

                }
                else
                {
                    ba1.TenBan = txtETenBan.Text;

                }

                if (string.IsNullOrEmpty(cbbETrangThai.Text))
                {
                    XtraMessageBox.Show("Bạn chưa chọn trạng thái", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbETrangThai.Focus();
                    return false;
                }
                else
                {
                    ba1.TrangThai = cbbETrangThai.EditValue.ToString();
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

        //Sự kiện click của nút Load
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

        //Sự kiện click co nút xóa
        private void sbXoa_Click(object sender, EventArgs e)
        {
            
            int row_index = gridView1.FocusedRowHandle;
            string col_FieldName = "MaBan";
            object value = gridView1.GetRowCellValue(row_index, col_FieldName);
            if (value != null)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa mã bàn: " + value.ToString(), "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    BanAn ba = db.BanAns.Where(s => s.MaBan == Convert.ToInt32(value)).SingleOrDefault();
                    if (ba != null)
                    {
                        try
                        {
                            db.BanAns.DeleteOnSubmit(ba);
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