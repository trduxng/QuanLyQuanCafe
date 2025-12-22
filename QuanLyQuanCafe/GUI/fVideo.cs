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

namespace QuanLyQuanCafe.GUI
{
    public partial class fVideo : DevExpress.XtraEditors.XtraForm
    {
        public fVideo()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = @"C:\Users\tung0\Desktop\hinhanh\video.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void fVideo_Load(object sender, EventArgs e)
        {

        }
    }
}