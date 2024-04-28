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

namespace GUI
{
    public partial class SuaTK : UserControl
    {
        public SuaTK()
        {
            InitializeComponent();
        }
        int dem = 0;
        public void load()
        {
            dem = 0;
            TaoTaiKhoan ttk = new TaoTaiKhoan();
            this.Controls.Add(ttk);
            txtTK.Text = null;
            cbQH.Text = null;
            txtMK.Text = null;
            timer1.Start();
            btLuu.Enabled = false;
            btXoa.Enabled = false;
            lbMNV.Text = null;
            List<TaiKhoan_DTO> lstNhanVien = TaiKhoan_BUS.NVCoTK();
            dg.DataSource = lstNhanVien;
        }
        private void SuaTK_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            timer1.Stop();
            btLuu.Enabled = true;
            btXoa.Enabled = true;
            DataGridViewRow dr = dg.SelectedRows[0];
            txtTK.Text = dr.Cells["TenDangNhap"].Value.ToString();
            txtMK.Text = dr.Cells["MatKhau"].Value.ToString();
            cbQH.Text = dr.Cells["QuyenHan"].Value.ToString();
            lbMNV.Text = dr.Cells["MaNhanVien"].Value.ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (MessageBox.Show("Bạn Thật Sự Muốn Xóa Tài Khoản Này?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.MaNhanVien = lbMNV.Text;
                if (TaiKhoan_BUS.XoaTK(tk))
                load();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dem++;
            if (dem == 3)
            {
                timer1.Stop();
                load();
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTK.Text))
            {
                if (!string.IsNullOrEmpty(txtMK.Text))
                {
                    if (!string.IsNullOrEmpty(cbQH.Text))
                    {
                        timer1.Start();
                        TaiKhoan_DTO tk = new TaiKhoan_DTO();
                        tk.MaNhanVien = lbMNV.Text;
                        tk.TenDangNhap = txtTK.Text;
                        tk.MatKhau = txtMK.Text;
                        tk.TenQuyenHan = cbQH.Text;
                        
                        if (TaiKhoan_BUS.SuaTK(tk))
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!!");
                        cbQH.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi!!");
                    txtMK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lỗi!!");
                txtTK.Focus();
            }
        }
    }
}
