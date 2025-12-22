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
using System.IO;
using QuanLyQuanCafe.DAO;
namespace QuanLyQuanCafe
{
    public partial class fMonAn : DevExpress.XtraEditors.XtraForm
    {
        QLCaFeDataContext db = new QLCaFeDataContext();
        ThucDon ma = new ThucDon();
        public fMonAn()
        {
            InitializeComponent();
        }
        
        private void fMonAn_Load(object sender, EventArgs e)
        {
            loadgrifcontrol();
            loadgrilookup();
            Antxt();
            Hienbtn();
            loadclick();
        }

        // Ẩn các dữ liệu nhập
        private void Antxt()
        {
            txtEMaMon.ReadOnly = txtETenMonAn.ReadOnly = txtEGia.ReadOnly = lkELoaiMon.ReadOnly = true;
            sbChonFile.Enabled = sbChupAnh.Enabled =  false;
        }

        // Hiện các dữ liệu nhập
        private void Hientxt()
        {
            txtEMaMon.ReadOnly = txtETenMonAn.ReadOnly = txtEGia.ReadOnly = lkELoaiMon.ReadOnly = false;
            sbChonFile.Enabled = sbChupAnh.Enabled = true;   
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
            txtEMaMon.Text = null;
            txtETenMonAn.Text = null;
            lkELoaiMon.Text = null;
            txtEGia.Text = null;
           
        }
        
        //Hàm load data lên gridcontrol
        private void loadgrifcontrol()
        {
            var dsMonAn = db.ThucDons.ToList();
            gridCtrlMonAn.DataSource = dsMonAn;
        }

        // Hàm load dữ liệu lên lkELoaiMon
        private void loadgrilookup()
        {
            var dsLoaiMon = db.LoadLoaiMons.ToList();
            lkELoaiMon.Properties.DataSource = dsLoaiMon;
            lkELoaiMon.Properties.DisplayMember = "TenLoaiMon";
            lkELoaiMon.Properties.ValueMember = "MaLoaiMon";
        }

        private void loadAnh(string a)
        {
            QLCaFeDataContext db = new QLCaFeDataContext();
            MonAn ima = db.MonAns.Where(p => p.MaMonAn == Convert.ToInt32(a)).FirstOrDefault();
            if (ima.HinhAnh != null)
            {
                MemoryStream me = new MemoryStream(ima.HinhAnh.ToArray());
                Image img = Image.FromStream(me);

                picEHinhMonAn.Image = img;
                //Anh = true
            }
            else
            {
                Image imge = Image.FromFile("C:\\Users\\tung0\\Desktop\\hinhanh\\MonAn\\food.jpg");
                picEHinhMonAn.Image = imge;
            }
        }
        //Hàm load dữ liệu cho sự kiện click của gridcontrol
        private void loadclick()
        {
            
            
            txtEMaMon.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtETenMonAn.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            lkELoaiMon.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            txtEGia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]) == null ? "" : gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            loadAnh(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString());
            
        }
        private void gridCtrlMonAn_Click(object sender, EventArgs e)
        {
            loadclick();
        }
        private bool isThem = true;

        //Sự kiện click của nút thêm
        private void sbThem_Click(object sender, EventArgs e)
        {
            ////SinhMaTuDongMaDAO maDAO = new SinhMaTuDongMaDAO();
            //txtEMaMon.Text = ma.MaMonAn.Substring(2) + 1;
           
            isThem = true;
            txtEMaMon.Enabled = true;
            Hientxt();
            Anbtn();
            txtEMaMon.Text = null;
            txtETenMonAn.Text = null;
            lkELoaiMon.Text = null;
            txtEGia.Text = null; 
            txtEMaMon.Focus();
            picEHinhMonAn.Text = "";
        }

        //Sự kiện click của nút Sửa
        private void sbSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            Anbtn();
            Hientxt();
            txtEMaMon.Enabled = false;
        }
        bool Anh = false;
        private void picEHinhMonAn_EditValueChanged(object sender, EventArgs e)
        {
            Anh = true;
        }

        //Hàm viết cho nút Lưu
        private bool save()
        {
            if (isThem)
            {
                MonAn td = new MonAn();
                if (string.IsNullOrEmpty(txtEMaMon.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập mã món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMaMon.Focus();
                    return false;

                }
                else
                {
                    td.MaMonAn = Convert.ToInt32(txtEMaMon.Text);
                }
                if (string.IsNullOrEmpty(txtETenMonAn.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenMonAn.Focus();
                    return false;

                }
                else
                {
                    td.TenMonAn = txtETenMonAn.Text;
                }
                if (string.IsNullOrEmpty(lkELoaiMon.Text))
                {
                    XtraMessageBox.Show("Bạn chưa chọn loại món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lkELoaiMon.Focus();
                    return false;

                }
                else
                {
                    td.MaLoaiMon = Convert.ToInt32(maloai);
                }
                if (string.IsNullOrEmpty(txtEGia.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập giá món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEGia.Focus();
                    return false;

                }
                else
                {
                    td.Gia = Convert.ToInt32(txtEGia.Text);
                }
                try
                {
                    if (picEHinhMonAn.EditValue != null)
                    {

                        MemoryStream stream = new MemoryStream();
                        picEHinhMonAn.Image.Save(stream, ImageFormat.Jpeg);
                        td.HinhAnh = stream.ToArray();
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    db.MonAns.InsertOnSubmit(td);
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

                MonAn td1 = new MonAn();
                td1 = db.MonAns.Where(s => s.MaMonAn ==Convert.ToInt32(txtEMaMon.Text)).SingleOrDefault();
                if (string.IsNullOrEmpty(txtETenMonAn.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtETenMonAn.Focus();
                    return false;

                }
                else
                {
                    td1.TenMonAn = txtETenMonAn.Text;
                }
                if (string.IsNullOrEmpty(lkELoaiMon.Text))
                {
                    XtraMessageBox.Show("Bạn chưa chọn loại món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lkELoaiMon.Focus();
                    return false;

                }
                else
                {
                    td1.MaLoaiMon = Convert.ToInt32(maloai);
                }
                if (string.IsNullOrEmpty(txtEGia.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập giá món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEGia.Focus();
                    return false;

                }
                else
                {
                    td1.Gia = Convert.ToInt32(txtEGia.Text);
                }
                if (Anh)
                {
                    MemoryStream stream = new MemoryStream();
                    picEHinhMonAn.Image.Save(stream, ImageFormat.Jpeg);
                    td1.HinhAnh = stream.ToArray();
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

        string maloai;
        private void lkELoaiMon_EditValueChanged_1(object sender, EventArgs e)
        {
            maloai = lkELoaiMon.EditValue.ToString();
        } 
       
        //Sự kiện click của nút Load
        private void sbLoad_Click(object sender, EventArgs e)
        {
            try
            {
                loadgrilookup();
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
            string col_FieldName = "MaMonAn";
            object value = gridView1.GetRowCellValue(row_index, col_FieldName);
            if (value != null)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa món có mã: " + value.ToString(), "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    MonAn ma = db.MonAns.Where(s => s.MaMonAn == Convert.ToInt32(value)).SingleOrDefault();
                    if (ma != null)
                    {
                        try
                        {
                            db.MonAns.DeleteOnSubmit(ma);
                            db.SubmitChanges();
                            loadgrifcontrol();
                            XtraMessageBox.Show("Đã xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            XtraMessageBox.Show("Xóa thất bại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("Món này chưa có mã , không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch(Exception)
            {
                XtraMessageBox.Show("Lưu thất bại","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        //Sự kiện click cho nút hủy
        private void sbHuy_Click(object sender, EventArgs e)
        {
            Hienbtn();
            Antxt();
            picEHinhMonAn.Image = null;
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
                    picEHinhMonAn.EditValue = stream.ToArray();
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
                picEHinhMonAn.Image = image;
            }
        }
       

       
       
       

 
    }
}