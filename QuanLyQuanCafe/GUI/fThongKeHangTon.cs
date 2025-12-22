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

namespace QuanLyQuanCafe
{
    public partial class fThongKeHangTon : DevExpress.XtraEditors.XtraForm
    {
        public fThongKeHangTon()
        {
            InitializeComponent();
        }

        private void fThongKeHangTon_Load(object sender, EventArgs e)
        {

        }
        QLCaFeDataContext db = new QLCaFeDataContext();

        private void loaddulieu()
        {
            var TKHT = (from tk in db.MatHangs select tk).ToList();
            gridControl1.DataSource = TKHT;
        }

        private void sbTKHT_Click(object sender, EventArgs e)
        {
            loaddulieu();
        }

    }
}