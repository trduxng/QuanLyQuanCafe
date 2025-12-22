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
using System.IO;
using QuanLyQuanCafe.GUI;
using DevExpress.XtraEditors.Popup;

namespace QuanLyQuanCafe
{
    public partial class fGiaoDienChinh : DevExpress.XtraEditors.XtraForm
    {
        public fGiaoDienChinh()
        {
            InitializeComponent();
        }
        public string temp;
        QLCaFeDataContext db = new QLCaFeDataContext();
        private void fGiaoDienChinh_Load(object sender, EventArgs e)
        {
            
            //PopupCalcEditForm f = new PopupCalcEditForm(new CalcEdit());
            //f.TopLevel = false;
            //f.Location = PointToScreen(new Point(9, 460));
            //f.Parent = this;
            //f.Show();
            picAVT.ReadOnly = true;
            var mnv = (from TaiKhoan in db.TaiKhoans
                      where TaiKhoan.TenDangNhap == temp
                      select TaiKhoan.MaNV).SingleOrDefault();
            var ten = (from Ten in db.NhanViens
                         where Ten.MaNV == mnv
                         select Ten.TenNV).SingleOrDefault();
            txtTenNguoiDung.Text = ten.ToString();
            var chucvu = (from Ten in db.NhanViens
                       where Ten.MaNV == mnv
                       select Ten.ChucVu).SingleOrDefault();
            txtChucVu.Text = chucvu.ToString();
            var loaiTK = (from LTK in db.TaiKhoans
                          where LTK.TenDangNhap == temp
                          select LTK.LoaiTk).SingleOrDefault();
            if(loaiTK==1)
            {
                rbQLNS.Enabled = true;
            }
            else
            {
                rbQLNS.Enabled = false;
            }
            var anh = (from Anh in db.NhanViens
                       where Anh.MaNV == mnv
                       select Anh.HinhAnh).SingleOrDefault();
            MemoryStream me = new MemoryStream(anh.ToArray());
            Image img = Image.FromStream(me);
            picAVT.Image = img;
        }
        public static string adm;

        private Form kiemtraform(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }

        private void btnChamCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fChamCong));
            if(frm == null)
            {
                fChamCong forms = new fChamCong();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fNhanVien));
            if (frm == null)
            {
                fNhanVien forms = new fNhanVien();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnTinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fTinhLuong));
            if (frm == null)
            {
                fTinhLuong forms = new fTinhLuong();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fTaiKhoan));
            if (frm == null)
            {
                fTaiKhoan forms = new fTaiKhoan();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnMonAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fMonAn));
            if (frm == null)
            {
                fMonAn forms = new fMonAn();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnLoaiMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fLoaiMon));
            if (frm == null)
            {
                fLoaiMon forms = new fLoaiMon();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnBanAn_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fBanAn));
            if (frm == null)
            {
                fBanAn forms = new fBanAn();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fNhaCungCap));
            if (frm == null)
            {
                fNhaCungCap forms = new fNhaCungCap();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnHangBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fGoiMon));
            if (frm == null)
            {
                fGoiMon forms = new fGoiMon();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnNhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fNhapHang));
            if (frm == null)
            {
                fNhapHang forms = new fNhapHang();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnXuatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fXuatHang));
            if (frm == null)
            {
                fXuatHang forms = new fXuatHang();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btndoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fThongKeDoanhThu));
            if (frm == null)
            {
                fThongKeDoanhThu forms = new fThongKeDoanhThu();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnHangTon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fThongKeHangTon));
            if (frm == null)
            {
                fThongKeHangTon forms = new fThongKeHangTon();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fThongKephieuNhap));
            if (frm == null)
            {
                fThongKephieuNhap forms = new fThongKephieuNhap();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fThongKePhieuXuat));
            if (frm == null)
            {
                fThongKePhieuXuat forms = new fThongKePhieuXuat();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            var mnv = (from TaiKhoan in db.TaiKhoans
                       where TaiKhoan.TenDangNhap == temp
                       select TaiKhoan.MaNV).SingleOrDefault();
            Form frm = kiemtraform(typeof(fThongTinTaiKhoan));
            if (frm == null)
            {
                fThongTinTaiKhoan forms = new fThongTinTaiKhoan();
                forms.maNV = mnv.ToString();
                forms.TenDN = temp.ToString();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide(); 
            Form frm = kiemtraform(typeof(fKhachHang));
            if (frm == null)
            {
                fKhachHang forms = new fKhachHang();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        public void EnableButtonBar() 
        {
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
        }
        public void DisableButtonBar()
        {
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fGioiThieu));
            if (frm == null)
            {
                fGioiThieu forms = new fGioiThieu();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fHoTro));
            if (frm == null)
            {
                fHoTro forms = new fHoTro();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            picTheme.Hide();
            lblTieuDe.Hide();
            Form frm = kiemtraform(typeof(fVideo));
            if (frm == null)
            {
                fVideo forms = new fVideo();
                forms.MdiParent = this;
                forms.Show();
            }
            else
            {
                frm.Activate();
            }
        }

       
     
      
       

      

        
        
    }

}