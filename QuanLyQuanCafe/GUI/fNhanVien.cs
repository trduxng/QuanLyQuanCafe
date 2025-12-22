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
using System.Data.Linq;
using System.IO;
using System.Drawing.Imaging;
using QuanLyQuanCafe.DAO;
namespace QuanLyQuanCafe
{
    public partial class fNhanVien : DevExpress.XtraEditors.XtraForm
    {
        QLCaFeDataContext db = new QLCaFeDataContext();
        NhanVien nv = new NhanVien();
        public fNhanVien()
        {
            InitializeComponent();
            gioiTinh();
        }
        private void fNhanVien_Load(object sender, EventArgs e)
        {
           
            loadgrifcontrol();
            Antxt();
            sbHuy.Enabled = sbLuu.Enabled = false;
            sbThem.Focus();
            loadclick();
            sbXoa.Enabled = false;
        }

        // // Ẩn các dữ liệu nhập
        private void Antxt()
        {
            picAvatar.ReadOnly = txtEditMaNV.ReadOnly = txtEditTenNV.ReadOnly = txtEditSDT.ReadOnly = txtEditCMND.ReadOnly = cbbEChucVu.ReadOnly = txtEDiaChi.ReadOnly = dateENgaySinh.ReadOnly = dateENgayVaoLam.ReadOnly = cbbEGioiTinh.ReadOnly =  true;
            sbChonAnh.Enabled = sbChupAnh.Enabled =  false;

        }

        // Hiện các dữ liệu nhập
        private void Hientxt()
        {
            picAvatar.ReadOnly = txtEditMaNV.ReadOnly = txtEditTenNV.ReadOnly = txtEditSDT.ReadOnly = txtEditCMND.ReadOnly = cbbEChucVu.ReadOnly = txtEDiaChi.ReadOnly = dateENgaySinh.ReadOnly = dateENgayVaoLam.ReadOnly = cbbEGioiTinh.ReadOnly =  false;
            sbChonAnh.Enabled = sbChupAnh.Enabled =  true;
        }

        // Hiện các nút chức năng
        private void Hienbtn()
        {
            sbThem.Enabled = sbSua.Enabled = sbLoad.Enabled = true;
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
            txtEditMaNV.Text = null;
            txtEditTenNV.Text = null;
            txtEDiaChi.Text = null;
            txtEditCMND.Text = null;
            txtEditSDT.Text = null;
            cbbEChucVu.Text = null;
            cbbEGioiTinh.Text = null;
            dateENgaySinh.Text = null;
            dateENgayVaoLam.Text = null;
        }

        //Hàm load data lên gridcontrol
        private void loadgrifcontrol()
        {
            var dsNhanVien = db.NhanViens.ToList();
            GrCtrlNhanVien.DataSource = dsNhanVien;
        }

        //Hàm load dữ liệu lên comboboxGioiTinh
        private void gioiTinh()
        {

            cbbEGioiTinh.Properties.Items.Add("Nam");
            cbbEGioiTinh.Properties.Items.Add("Nữ");
            cbbEChucVu.Properties.Items.Add("Phục vụ");
            cbbEChucVu.Properties.Items.Add("Kế toán");
            cbbEChucVu.Properties.Items.Add("Quản lý");
        }

        private void loadAnh(string a)
        {
            QLCaFeDataContext db = new QLCaFeDataContext();
            NhanVien ima = db.NhanViens.Where(p => p.MaNV == a).FirstOrDefault();
            if (ima.HinhAnh != null)
            {
                MemoryStream me = new MemoryStream(ima.HinhAnh.ToArray());
                Image img = Image.FromStream(me);

                picAvatar.Image = img;
                //Anh = true
            }
            else
            {
                Image img = Image.FromFile("..\\..\\images\\employee.jpg");
                picAvatar.Image = img;
            }
        }
        //Hàm load dữ liệu cho sự kiện click của gridcontrol
        private void loadclick()
        {
            txtEditMaNV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtEditTenNV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            dateENgaySinh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]) != null)
            {
                cbbEGioiTinh.SelectedIndex = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() == "False") ? 1 : 0;
            }
            txtEditCMND.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
            txtEditSDT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
            txtEDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
            dateENgayVaoLam.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7]).ToString();
            cbbEChucVu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[9]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[9]).ToString();
            loadAnh(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString());
        }

        private void GrCtrlNhanVien_Click(object sender, EventArgs e)
        {
            sbXoa.Enabled = true;
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
            SinhMaTuDongNvDAO nvDAO = new SinhMaTuDongNvDAO();
            txtEditMaNV.Text = nvDAO.XuLyMaNhanVien();
            isThem = true;
            txtEditMaNV.Enabled = false;
            txtEditMaNV.ReadOnly = true;
            Hientxt();
            txtEditTenNV.Text = null;
            txtEDiaChi.Text = null;
            txtEditCMND.Text = null;
            txtEditSDT.Text = null;
            cbbEChucVu.Text = null;
            cbbEGioiTinh.Text = null;
            dateENgaySinh.Text = null;
            dateENgayVaoLam.Text = null;
            Anbtn();
            txtEditTenNV.Focus();
            picAvatar.Text ="";
            sbXoa.Enabled = false;
        }

        //Sự kiện click của nút Sửa
        private void sbSua_Click(object sender, EventArgs e)
        {
            sbXoa.Enabled = false;
            isThem = false;
            Anbtn();
            Hientxt();
            txtEditMaNV.Enabled = false;
        }

        //Hàm viết cho nút Lưu
        private bool save()
        {
            if (isThem)
            {
                NhanVien nv = new NhanVien();
                if (string.IsNullOrEmpty(txtEditMaNV.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập mã nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEditMaNV.Focus();
                    return false;
                }
                else
                {
                    nv.MaNV = txtEditMaNV.Text;
                }
                if (string.IsNullOrEmpty(txtEditTenNV.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEditTenNV.Focus();
                    return false;

                }
                else
                {
                    nv.TenNV = txtEditTenNV.Text;

                }
                if (string.IsNullOrEmpty(txtEditSDT.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEditSDT.Focus();
                    return false;

                }
                else
                {
                    nv.SDT = txtEditSDT.Text;

                }
                if (string.IsNullOrEmpty(txtEDiaChi.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập địa chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEDiaChi.Focus();
                    return false;
                }
                else
                {
                    nv.DiaChi = txtEDiaChi.Text;

                }
                if (string.IsNullOrEmpty(txtEditCMND.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập CMND", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEditCMND.Focus();
                    return false;
                }
                else
                {
                    nv.CMND = txtEditCMND.Text;

                }
                if (string.IsNullOrEmpty(dateENgaySinh.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập ngày sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateENgaySinh.Focus();
                    return false;
                }
                else
                {
                    nv.NgaySinh = dateENgaySinh.DateTime;

                }
                if (string.IsNullOrEmpty(dateENgayVaoLam.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập Ngày vào làm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateENgayVaoLam.Focus();
                    return false;
                }
                else
                {
                    nv.NgayVaoLam = dateENgayVaoLam.DateTime;

                }
                if (string.IsNullOrEmpty(cbbEChucVu.Text))
                {
                    XtraMessageBox.Show("Bạn chưa chọn chức vụ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbEChucVu.Focus();
                    return false;
                }
                else
                {
                    nv.ChucVu = cbbEChucVu.Text;

                }
                if (string.IsNullOrEmpty(cbbEGioiTinh.Text))
                {
                    XtraMessageBox.Show("Bạn chưa chọn giới tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbEGioiTinh.Focus();
                    return false;
                }
                else
                {
                    nv.GioiTinh = cbbEGioiTinh.EditValue.ToString() == "Nam" ? true : false;
                }
                try
                {
                    if(picAvatar.Image != null)                    
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            picAvatar.Image.Save(stream, ImageFormat.Jpeg);
                            nv.HinhAnh = stream.ToArray();
                        }
                    }
                    else
                    {
                        // Nếu chưa có ảnh, có thể gán ảnh mặc định
                        Image defaultImg = Image.FromFile("..\\..\\images\\employee.jpg");
                        picAvatar.Image = defaultImg;

                        using (MemoryStream stream = new MemoryStream())
                        {
                            defaultImg.Save(stream, ImageFormat.Jpeg);
                            nv.HinhAnh = stream.ToArray();
                        }
                    }
                }
                catch(Exception)
                {

                }
                try
                {
                    db.NhanViens.InsertOnSubmit(nv);
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
                NhanVien nv1 = new NhanVien();
                nv1 = db.NhanViens.Where(s => s.MaNV == txtEditMaNV.Text).SingleOrDefault();
                if (string.IsNullOrEmpty(txtEditTenNV.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEditTenNV.Focus();
                    return false;
                }
                else
                {
                    nv1.TenNV = txtEditTenNV.Text;
                }
                if (string.IsNullOrEmpty(txtEditSDT.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEditSDT.Focus();
                    return false;

                }
                else
                {
                    nv1.SDT = txtEditSDT.Text;
                }
                if (string.IsNullOrEmpty(txtEDiaChi.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập địa chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEDiaChi.Focus();
                    return false;
                }
                else
                {
                    nv1.DiaChi = txtEDiaChi.Text;
                }
                if (string.IsNullOrEmpty(txtEditCMND.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập CMND", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEditCMND.Focus();
                    return false;
                }
                else
                {
                    nv1.CMND = txtEditCMND.Text;
                }
                if (string.IsNullOrEmpty(dateENgaySinh.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập ngày sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateENgaySinh.Focus();
                    return false;
                }
                else
                {
                    nv1.NgaySinh = dateENgaySinh.DateTime;
                }
                if (string.IsNullOrEmpty(dateENgayVaoLam.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập Ngày vào làm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateENgayVaoLam.Focus();
                    return false;
                }
                else
                {
                    nv1.NgayVaoLam = dateENgayVaoLam.DateTime;
                }
                if (string.IsNullOrEmpty(cbbEChucVu.Text))
                {
                    XtraMessageBox.Show("Bạn chưa chọn chức vụ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbEChucVu.Focus();
                    return false;
                }
                else
                {
                    nv1.ChucVu = cbbEChucVu.Text;
                }
                if (string.IsNullOrEmpty(cbbEGioiTinh.Text))
                {
                    XtraMessageBox.Show("Bạn chưa chọn giới tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbEGioiTinh.Focus();
                    return false;
                }
                else
                {
                    nv1.GioiTinh = cbbEGioiTinh.EditValue.ToString() == "Nam" ? true : false;
                }
                if (Anh)
                {
                    MemoryStream stream = new MemoryStream();
                    picAvatar.Image.Save(stream, ImageFormat.Jpeg);
                    nv1.HinhAnh = stream.ToArray();
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

        //Sự kiện click của nút Load
        private void sbLoad_Click(object sender, EventArgs e)
        {
            sbXoa.Enabled = false;
            try
            {
                loadgrifcontrol();
                XtraMessageBox.Show("Đã load dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception)
            {
                 XtraMessageBox.Show("Load dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Sự kiện click co nút xóa
        private void sbXoa_Click(object sender, EventArgs e)
        {
            
            int row_index = gridView1.FocusedRowHandle;
            string col_FieldName = "MaNV";
            object value = gridView1.GetRowCellValue(row_index, col_FieldName);
            if (value != null)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên: " + value.ToString(), "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    NhanVien nv = db.NhanViens.Where(s => s.MaNV == value).SingleOrDefault();
                    if (nv != null)
                    {
                        try
                        {
                            db.NhanViens.DeleteOnSubmit(nv);
                            db.SubmitChanges();
                            loadgrifcontrol();
                            XtraMessageBox.Show("Đã xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            sbXoa.Enabled = false;
                        }
                        catch (Exception)
                        {
                            XtraMessageBox.Show("Xóa thất bại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Nhân viên này chưa có mã nhân viên, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //Sự kiện click cho nút lưu
        private void sbLuu_Click(object sender, EventArgs e)
        {
            try
            {
                save();
                txtEditMaNV.Enabled = true;
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
            Clear();
            txtEditMaNV.Enabled = true;
            picAvatar.Image = null;
        }
        
        //Hàm show máy ảnh
        private void showcamera()
        {
            DevExpress.XtraEditors.Camera.TakePictureDialog dialog = new DevExpress.XtraEditors.Camera.TakePictureDialog();
            if(dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Image ima = dialog.Image;
                using( var stream = new MemoryStream())
                {
                    ima.Save(stream, ImageFormat.Jpeg);
                    picAvatar.EditValue = stream.ToArray();
                }
            }
        }

        private void sbChupAnh_Click(object sender, EventArgs e)
        {
            showcamera();
        }


        //Hàm chọn ảnh
        string location = "";
        private void sbChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Allfile (*.*)|*.*";
            if(opd.ShowDialog()== DialogResult.OK)
            {
                location = opd.FileName;
                Image image = Image.FromFile(location);
                picAvatar.Image = image;
            }
        }
        bool Anh = false;
        private void picAvatar_EditValueChanged(object sender, EventArgs e)
        {
            Anh = true;
        }

        

        
       


    }
}