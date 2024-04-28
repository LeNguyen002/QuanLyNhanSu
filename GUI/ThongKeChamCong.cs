using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThongKeChamCong : UserControl
    {
        public ThongKeChamCong()
        {
            InitializeComponent();
        }

        private void rdNTT_CheckedChanged(object sender, EventArgs e)
        {
            ThongKe.tkNVNghiTrongNgay tknvntn = new ThongKe.tkNVNghiTrongNgay();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tknvntn);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ThongKe.tkXemccTheoTen tkxtt = new ThongKe.tkXemccTheoTen();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tkxtt);
        }
    }
}
