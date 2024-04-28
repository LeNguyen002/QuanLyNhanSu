using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI.ThongKe
{
    public partial class tkNVNghiTrongNgay : UserControl
    {
        public tkNVNghiTrongNgay()
        {
            InitializeComponent();
        }
        int thang = DateTime.Now.Month, nam = DateTime.Now.Year, ngay = DateTime.Now.Day;
        DateTime n;

        private void btXem_Click(object sender, EventArgs e)
        {
            
            DateTime ngaydau = Convert.ToDateTime(Convert.ToInt32(cbThang.Text) + "/" + "01/" + Convert.ToInt32(cbNam.Text) + " ");
            DateTime ngaycuoi = Convert.ToDateTime(Convert.ToInt32(cbThang.Text) + "/" + "29/" + Convert.ToInt32(cbNam.Text) + " ");
            if (radioButton1.Checked == true)
            {
                    n = Convert.ToDateTime(Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(txtNgay.Text) + "/" + Convert.ToInt32(cbNam.Text));
                    List<ChamCong_DTO> lstLuong = NhanVien_BUS.ThongKeNVNghiTheoNgay(n);
                if (lstLuong == null)
                {
                    dataGridView1.DataSource = null;
                }    

                else
                {
                    dataGridView1.DataSource = lstLuong;
                    dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                    dataGridView1.Columns["MaNhanVien"].Width = 70;
                    dataGridView1.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
                    dataGridView1.Columns["TenNV"].Width = 250;
                    dataGridView1.Columns["TinhTrang"].HeaderText = "Tình Trạng";
                    dataGridView1.Columns["TinhTrang"].Width = 130;
                    dataGridView1.Columns["Ngay"].Visible = false;
                }
                    

            }
            else
            {
                txtNgay.Enabled = false;
                List<ChamCong_DTO> lstLuong = NhanVien_BUS.ThongKeNVNghiTheoThang(ngaydau, ngaycuoi);
                if (lstLuong == null)
                {
                    dataGridView1.DataSource = null;
                }

                else
                {
                    dataGridView1.DataSource = lstLuong;
                    dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
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
        private void load()
        {
            txtNgay.Enabled = false;
            cbThang.Enabled = false;
            cbNam.Enabled = false;
            btXem.Enabled = false;
        }
        private void tkNVNghiTrongNgay_Load(object sender, EventArgs e)
        {
            load();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtNgay.Enabled = true;
            cbThang.Enabled = true;
            cbNam.Enabled = true;
            btXem.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtNgay.Enabled = false;
            cbThang.Enabled = true;
            cbNam.Enabled = true;
            btXem.Enabled = true;
        }
    }
}
