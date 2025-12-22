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
using QuanLyQuanCafe.DTO;
using System.Globalization;
using System.Threading;
using QuanLyQuanCafe.GUI;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyQuanCafe
{
    public partial class fGoiMon : DevExpress.XtraEditors.XtraForm
    {
        QLCaFeDataContext db = new QLCaFeDataContext();
        ThucDon ma = new ThucDon();
        public fGoiMon()
        {
            InitializeComponent();
            LoadLM();
            LoadComboboxBanAn(cbbChuyenBan);
        }
        private void loadgrifcontrol()
        {
            var dsMonAn = db.ThucDons.ToList();
            grCtrlGoiMon.DataSource = dsMonAn;
        }
        private void fGoiMon_Load(object sender, EventArgs e)
        {

            AnGoiMon();
            //LoadLM();
        }
        private void AnGoiMon()
        {
            grGoiMon.Enabled = sbThem.Enabled = grCtrlGoiMon.Enabled = false;
        }
        private void HienGoiMon()
        {
            grGoiMon.Enabled = sbThem.Enabled = grCtrlGoiMon.Enabled = true;
        }

        private void sbGoiMon_Click_1(object sender, EventArgs e)
        {
            loadgrifcontrol();
            HienGoiMon();
            LoadLM();
        }
        void LoadLM()
        {
            List<LoadLMDTO> listLm = LoadLMDAO.Instance.GetListLM();
            cbbLoaiMon.DataSource = listLm;
            cbbLoaiMon.DisplayMember = "TenLoai";
        }
        void LoadTenMon(int id)
        {
            List<LoadMADTO> listMa = LoadMADAO.Instance.GetlistMonAn(id);
            cbbTenMon.DataSource = listMa;
            cbbTenMon.DisplayMember = "TenMon";

        }
        void LoadBanAn()
        {
            flpBan.Controls.Clear();
            List<BanAnDTO> listBan = BanAnDAO.Instance.LoadDsBan();
            foreach (BanAnDTO item in listBan)
            {
                Button btn = new Button() { Width = BanAnDAO.Dai, Height = BanAnDAO.Rong };
                btn.Text = item.TenBan + Environment.NewLine + item.TrangThai;
                btn.Click += btn_Click;
                btn.Tag = item;


                switch (item.TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.CornflowerBlue;

                        break;
                    default:
                        btn.BackColor = Color.Purple;
                        btn.ForeColor = Color.White;
                        break;
                }
                flpBan.Controls.Add(btn);
            }

        }



        void showHD(int id)
        {
            lsvHD.Items.Clear();
            List<MenuDTO> listBillInfo = MenuDAO.Instance.getListMenu(id);
            int TongTien = 0;
            foreach (MenuDTO item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenMon.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                TongTien += item.ThanhTien;
                lsvHD.Items.Add(lsvItem);


            }
            CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            txtETongTien.Text = TongTien.ToString("c", culture);

        }
        void LoadComboboxBanAn(System.Windows.Forms.ComboBox cb)
        {
            cb.DataSource = BanAnDAO.Instance.LoadDsBan();
            cb.DisplayMember = "TenBan";
        }
        void btn_Click(object sender, EventArgs e)
        {

            int maBan = ((sender as Button).Tag as BanAnDTO).MaBan;
            string tenBan = ((sender as Button).Tag as BanAnDTO).TenBan;
            string trangThai = ((sender as Button).Tag as BanAnDTO).TrangThai;
            int mahd = HoaDonDAO.Instance.GetHD(maBan);
            if (mahd == -1)
            {
                txtMaHD.Text = "Bàn này chưa có hóa đơn";
            }
            else
            {
                txtMaHD.Text = mahd.ToString();
            }
            lsvHD.Tag = (sender as Button).Tag;
            showHD(maBan);
            txtTenBan.Text = tenBan;
            txtTrangThai.Text = trangThai;


        }

        private void sbLoadBan_Click(object sender, EventArgs e)
        {
            LoadBanAn();
            sbLoadBan.Enabled = false;
        }

        private void cbbLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
            if (cb.SelectedItem == null)
                return;
            LoadLMDTO selected = cb.SelectedItem as LoadLMDTO;
            id = selected.MaLoai;
            LoadTenMon(id);
        }

        private void sbThem_Click(object sender, EventArgs e)
        {

            BanAnDTO table = lsvHD.Tag as BanAnDTO;
            if (table == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn bàn cần thêm món", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maHD = HoaDonDAO.Instance.GetHD(table.MaBan);
            int maMonAn = (cbbTenMon.SelectedItem as LoadMADTO).MaMon;
            int donGia = (cbbTenMon.SelectedItem as LoadMADTO).GiaMon;
            int sl = (int)nmrSoLuong.Value;
            int thanhtien = sl * donGia;
            if (maHD == -1)
            {
                if (sl < 0)
                {
                    XtraMessageBox.Show("Món bạn muốn bớt không có trong hóa đơn, vui lòng xem lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HoaDonDAO.Instance.InsertHD(table.MaBan);
                    ChiTietHDDAO.Instance.InsertCTHD(HoaDonDAO.Instance.GetMaxMaHD(), maMonAn, sl, thanhtien);
                }
            }
            else
            {
                try
                {
                    ChiTietHDDAO.Instance.InsertCTHD(maHD, maMonAn, sl, thanhtien);
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Món bạn muốn bớt không có trong hóa đơn, vui lòng xem lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            showHD(table.MaBan);
            LoadBanAn();
        }

        private void sbThanhToan_Click(object sender, EventArgs e)
        {
            BanAnDTO table = lsvHD.Tag as BanAnDTO;
            if (table == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn bàn cần thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int maHD = HoaDonDAO.Instance.GetHD(table.MaBan);
                int giamGia = (int)nmGiamGia.Value;
                double tongtienchuagiamgia = (Convert.ToDouble(txtETongTien.Text.Split(',')[0]) * 1000);
                //MessageBox.Show(tongtienchuagiamgia.ToString());
                //double tongtienchuagiamgia = double.Parse(txtETongTien.Text, NumberStyles.Currency);﻿
                double tongtiendagiamgia = tongtienchuagiamgia - (tongtienchuagiamgia / 100) * giamGia;
                if (maHD != -1)
                {
                    DialogResult dr = XtraMessageBox.Show(string.Format("Bạn có chắc thanh toán cho {0} với mã giảm giá là {1}%\n  =>Tổng tiền: {2}đ", table.TenBan, giamGia, tongtiendagiamgia), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        HoaDonDAO.Instance.ThanhToan(maHD, giamGia);
                        showHD(table.MaBan);
                    }
                }
                LoadBanAn();
            }
            //}
            //catch(Exception)
            //{ }
        }

        private void sbChuyenBan_Click(object sender, EventArgs e)
        {
           
            int maban1 = (lsvHD.Tag as BanAnDTO).MaBan;
            int maban2 = (cbbChuyenBan.SelectedItem as BanAnDTO).MaBan;
            DialogResult dr = XtraMessageBox.Show(string.Format("Bạn có thực sự muốn chuyển {0} sang {1}", (lsvHD.Tag as BanAnDTO).TenBan, (cbbChuyenBan.SelectedItem as BanAnDTO).TenBan), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                BanAnDAO.Instance.ChuyenBan(maban1, maban2);
                LoadBanAn();
            }
            
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            BanAnDTO table = lsvHD.Tag as BanAnDTO;
            if (table == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn bàn cần in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ketnoi = ConfigurationManager.ConnectionStrings["QuanLyQuanCafe.Properties.Settings.QlCafeConnectionString2"].ConnectionString;
                SqlConnection con = new SqlConnection(ketnoi);
                con.Open();
                SqlCommand cmd = new SqlCommand("select MaHD , NgayLap , TenBan , Tinhtrang , GiamGia , TenMonAn , SoLuong , Gia , ThanhTien from ReportHoaDon Where MaHD = " + Convert.ToInt32(txtMaHD.Text), con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                //List<ReportHoaDonDTO> listLm = ReportHoaDonDAO.Instance.Inhoadon(id);
                rptHoaDon report = new rptHoaDon();
                report.DataSource = dt;
                //report.LoadrptHoadon();
                report.ShowPreviewDialog();
            }
            
        }

        

        
    }
           
}