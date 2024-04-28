using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.ThongKe
{
    public partial class tkXemccTheoTen : UserControl
    {
        public tkXemccTheoTen()
        {
            InitializeComponent();
        }

        private void tkXemccTheoTen_Load(object sender, EventArgs e)
        {
            btXem.Enabled = false;
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            btXem.Enabled = true;
        }

        private void btXem_Click(object sender, EventArgs e)
        {

            DateTime ngaydau = Convert.ToDateTime(Convert.ToInt32(cbThang.Text) + "/" + "01/" + Convert.ToInt32(cbNam.Text) + " ");
            DateTime ngaycuoi = Convert.ToDateTime(Convert.ToInt32(cbThang.Text) + "/" + "29/" + Convert.ToInt32(cbNam.Text) + " ");
            List<ChamCong_DTO> lstLuong = NhanVien_BUS.ChamCongTheoThangTheoTenNV(txtTen.Text,ngaydau,ngaycuoi);
            if (lstLuong == null)
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                dataGridView1.DataSource = lstLuong;
                dataGridView1.Columns["MaNhanVien"].Width = 70;
                dataGridView1.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
                dataGridView1.Columns["TenNV"].Width = 250;
                dataGridView1.Columns["TinhTrang"].HeaderText = "Tình Trạng";
                dataGridView1.Columns["TinhTrang"].Width = 130;
                dataGridView1.Columns["Ngay"].HeaderText = "Ngày";
                dataGridView1.Columns["Ngay"].Width = 100;
            }
        }
    }
}
