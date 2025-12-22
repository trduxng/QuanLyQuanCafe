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
using System.Drawing.Imaging;
using QuanLyQuanCafe.DAO;
using System.IO;

namespace QuanLyQuanCafe
{
    public partial class fLoaiMon : DevExpress.XtraEditors.XtraForm
    {
        QLCaFeDataContext db = new QLCaFeDataContext();
        LoaiMon lm = new LoaiMon();

        public fLoaiMon()
        {
            InitializeComponent();
        }

        private void fLoaiMon_Load(object sender, EventArgs e)
        {
            loadgrifcontrol();
            Antxt();
            sbHuy.Enabled = sbLuu.Enabled = false;
            sbThem.Focus();
            loadclick();
        }
        private void Antxt()
        {
            txtEMaLoaiMon.ReadOnly = txtETenLoaiMon.ReadOnly  = true;
            sbChonFile.Enabled = sbChupAnh.Enabled =  false;
        }

        // Hiện các dữ liệu nhập
        private void Hientxt()
        {
            txtEMaLoaiMon.ReadOnly = txtETenLoaiMon.ReadOnly  = false;
            sbChonFile.Enabled = sbChupAnh.Enabled =  true;
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
            txtEMaLoaiMon.Text = null;
            txtETenLoaiMon.Text = null;
           
        }

        //Hàm load data lên gridcontrol
        private void loadgrifcontrol()
        {
            var dsLoaiMon = db.LoaiMons.ToList();
            grCtrlLoaiMon.DataSource = dsLoaiMon;
        }

        private void loadAnh(string a)
        {
            QLCaFeDataContext db = new QLCaFeDataContext();
            LoaiMon ima = db.LoaiMons.Where(p => p.MaLoaiMon == Convert.ToInt32(a)).FirstOrDefault();
            if (ima.HinhAnh != null)
            {
                MemoryStream me = new MemoryStream(ima.HinhAnh.ToArray());
                Image img = Image.FromStream(me);

                picEHinhAnh.Image = img;
                //Anh = true
            }
            else
            {
                Image imge = Image.FromFile("C:\\Users\\tung0\\Desktop\\hinhanh\\nhanvien\\user.png");
                picEHinhAnh.Image = imge;
            }
        }
        //Hàm load dữ liệu cho sự kiện click của gridcontrol
        private void loadclick()
        {
            txtEMaLoaiMon.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtETenLoaiMon.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            loadAnh(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString());

        }

        private void grCtrlLoaiMon_Click(object sender, EventArgs e)
        {
            loadclick();
        }

        private bool isThem = true;
        //Sự kiện click của nút thêm
        private void sbThem_Click(object sender, EventArgs e)
        {
            //string maloaimon = Convert.ToString(lm.MaLoaiMon);
            //SinhMaTuDongLmDAO lmDAO = new SinhMaTuDongLmDAO();
            //txtEMaLoaiMon.Text = maloaimon;
            //txtEMaLoaiMon.Enabled = false;
            isThem = true;
            txtETenLoaiMon.Text = null;
            Hientxt();
            Anbtn();
            txtEMaLoaiMon.Focus();
            picEHinhAnh.Text = "";
        }

        //Sự kiện click của nút Sửa
        private void sbSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            Anbtn();
            Hientxt();
            txtEMaLoaiMon.Enabled = false;
        }

        bool Anh = false;
        private void picEHinhAnh_EditValueChanged(object sender, EventArgs e)
        {
            Anh = true;
        }
        //Hàm viết cho nút Lưu
        private bool save()
        {
            if (isThem)
            {
                LoaiMon lm = new LoaiMon();
                if (string.IsNullOrEmpty(txtEMaLoaiMon.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập mã loại món", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMaLoaiMon.Focus();
                    return false;

                }
                else
                {
                    lm.MaLoaiMon = Convert.ToInt32(txtEMaLoaiMon.Text);
                }
                if (string.IsNullOrEmpty(txtETenLoaiMon.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenLoaiMon.Focus();
                    return false;

                }
                else
                {
                    lm.TenLoaiMon = txtETenLoaiMon.Text;
                }
                try
                {
                    if (picEHinhAnh.EditValue != null)
                    {

                        MemoryStream stream = new MemoryStream();
                        picEHinhAnh.Image.Save(stream, ImageFormat.Jpeg);
                        lm.HinhAnh = stream.ToArray();
                    }
                }
                catch (Exception)
                {

                }
               
                try
                {
                    db.LoaiMons.InsertOnSubmit(lm);
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

               LoaiMon lm1 = new LoaiMon();
                lm1 = db.LoaiMons.Where(s => s.MaLoaiMon == Convert.ToInt32(txtEMaLoaiMon.Text)).SingleOrDefault();
                if (string.IsNullOrEmpty(txtETenLoaiMon.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenLoaiMon.Focus();
                    return false;

                }
                else
                {
                    lm1.TenLoaiMon = txtETenLoaiMon.Text;
                }
                if (Anh)
                {
                    MemoryStream stream = new MemoryStream();
                    picEHinhAnh.Image.Save(stream, ImageFormat.Jpeg);
                    lm1.HinhAnh = stream.ToArray();
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

        private void sbLuu_Click(object sender, EventArgs e)
        {
            try
            {
                save();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lưu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sbHuy_Click(object sender, EventArgs e)
        {
            Hienbtn();
            Antxt();
            picEHinhAnh.Image = null;
        }

        private void sbXoa_Click(object sender, EventArgs e)
        {
            int row_index = gridView1.FocusedRowHandle;
            string col_FieldName = "MaLoaiMon";
            object value = gridView1.GetRowCellValue(row_index, col_FieldName);
            if (value != null)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa món có mã: " + value.ToString(), "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    LoaiMon lm= db.LoaiMons.Where(s => s.MaLoaiMon == Convert.ToInt32(value)).SingleOrDefault();
                    if (lm != null)
                    {
                        try
                        {
                            db.LoaiMons.DeleteOnSubmit(lm);
                            db.SubmitChanges();
                            loadgrifcontrol();
                            XtraMessageBox.Show("Đã xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtEMaLoaiMon.Text="";
                            txtETenLoaiMon.Text = "";
                        }
                        catch (Exception)
                        {
                            XtraMessageBox.Show("Xóa thất bại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("Loại món này chưa có mã , không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
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


        //Hàm show máy ảnh
        private void showcamera()
        {
            DevExpress.XtraEditors.Camera.TakePictureDialog dialog = new DevExpress.XtraEditors.Camera.TakePictureDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Image ima = dialog.Image;
                using (var stream = new System.IO.MemoryStream())
                {
                    ima.Save(stream, ImageFormat.Jpeg);
                    picEHinhAnh.EditValue = stream.ToArray();
                }
            }
        }

        private void sbChupAnh_Click(object sender, EventArgs e)
        {
            showcamera();
        }

        string location = "";
        private void sbChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Allfile (*.*)|*.*";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                location = opd.FileName;
                Image image = Image.FromFile(location);
                picEHinhAnh.Image = image;
            }
        }

       
    }
}