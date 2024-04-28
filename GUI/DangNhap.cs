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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrEmpty(txtTaiKhoan.Text))
                {
                    if (!string.IsNullOrEmpty(txtMatKhau.Text))
                    {
                        TaiKhoan_DTO tk = new TaiKhoan_DTO();
                        tk = TaiKhoan_BUS.LayTK(txtTaiKhoan.Text, txtMatKhau.Text);
                         if (tk != null)
                        {
                            MainForm f = new MainForm(txtTaiKhoan.Text, txtMatKhau.Text);
                            this.Hide();
                            f.Show();
                            f.Logout += F_Logout;
                        }
                        else
                        {
                            label2.Text = " Lỗi!! Sai tài khoản hoặc mật khẩu";
                            txtTaiKhoan.Clear();
                            txtMatKhau.Clear();
                            txtTaiKhoan.Focus();
                        }
                    }
                    else
                    {
                        label2.Text = " Lỗi!! nhập mật khẩu";
                        txtMatKhau.Focus();
                    }
                }
                else
                {
                    label2.Text = " Lỗi!! Nhập tài khoản của bạn";
                    txtTaiKhoan.Focus();
                }
        }

        private void F_Logout(object sender, EventArgs e)
        {
            (sender as MainForm).isExit = false;
            (sender as MainForm).Close();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
