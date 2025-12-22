namespace QuanLyQuanCafe
{
    partial class fDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtETK = new DevExpress.XtraEditors.TextEdit();
            this.txtEMK = new DevExpress.XtraEditors.TextEdit();
            this.chkEHienThiMK = new DevExpress.XtraEditors.CheckEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.sbThoat = new DevExpress.XtraEditors.SimpleButton();
            this.sbDN = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtETK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEHienThiMK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu:";
            // 
            // txtETK
            // 
            this.txtETK.EditValue = "";
            this.txtETK.Location = new System.Drawing.Point(84, 126);
            this.txtETK.Name = "txtETK";
            this.txtETK.Size = new System.Drawing.Size(156, 20);
            this.txtETK.TabIndex = 0;
            this.txtETK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtETK_KeyDown);
            // 
            // txtEMK
            // 
            this.txtEMK.EditValue = "";
            this.txtEMK.Location = new System.Drawing.Point(84, 152);
            this.txtEMK.Name = "txtEMK";
            this.txtEMK.Properties.UseSystemPasswordChar = true;
            this.txtEMK.Size = new System.Drawing.Size(156, 20);
            this.txtEMK.TabIndex = 1;
            this.txtEMK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEMK_KeyDown);
            // 
            // chkEHienThiMK
            // 
            this.chkEHienThiMK.Location = new System.Drawing.Point(84, 177);
            this.chkEHienThiMK.Name = "chkEHienThiMK";
            this.chkEHienThiMK.Properties.Caption = "Hiển thị mật khẩu";
            this.chkEHienThiMK.Size = new System.Drawing.Size(136, 19);
            this.chkEHienThiMK.TabIndex = 2;
            this.chkEHienThiMK.CheckedChanged += new System.EventHandler(this.chkEHienThiMK_CheckedChanged);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::QuanLyQuanCafe.Properties.Resources.user_image_with_black_background__1_;
            this.pictureEdit1.Location = new System.Drawing.Point(65, 5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(136, 115);
            this.pictureEdit1.TabIndex = 7;
            // 
            // sbThoat
            // 
            this.sbThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbThoat.ImageOptions.Image")));
            this.sbThoat.Location = new System.Drawing.Point(158, 202);
            this.sbThoat.Name = "sbThoat";
            this.sbThoat.Size = new System.Drawing.Size(82, 30);
            this.sbThoat.TabIndex = 4;
            this.sbThoat.Text = "Thoát";
            this.sbThoat.Click += new System.EventHandler(this.sbThoat_Click);
            // 
            // sbDN
            // 
            this.sbDN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbDN.ImageOptions.Image")));
            this.sbDN.Location = new System.Drawing.Point(26, 202);
            this.sbDN.Name = "sbDN";
            this.sbDN.Size = new System.Drawing.Size(82, 30);
            this.sbDN.TabIndex = 3;
            this.sbDN.Text = "Đăng nhập";
            this.sbDN.Click += new System.EventHandler(this.sbDN_Click);
            // 
            // fDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 236);
            this.Controls.Add(this.chkEHienThiMK);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.sbThoat);
            this.Controls.Add(this.sbDN);
            this.Controls.Add(this.txtEMK);
            this.Controls.Add(this.txtETK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fDangNhap";
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fDangNhap_FormClosing);
            this.Load += new System.EventHandler(this.fDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtETK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEHienThiMK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtETK;
        private DevExpress.XtraEditors.TextEdit txtEMK;
        private DevExpress.XtraEditors.SimpleButton sbDN;
        private DevExpress.XtraEditors.SimpleButton sbThoat;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.CheckEdit chkEHienThiMK;
    }
}