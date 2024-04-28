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

namespace GUI
{
    public partial class DoiMatKhau : UserControl
    {
        private string username, password;
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        public DoiMatKhau(string user, string pass)
        {
            InitializeComponent();
            this.username = user;
            this.password = pass;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            lblTaiKhoan.Text = TaiKhoan_BUS.LayTenTK(username,password);
            lbMKC.Text = null;
            lbMKM.Text = null;
            lbNL.Text = null;
            lbTb.Text = null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMKC.Text))
            {
                if (!string.IsNullOrEmpty(txtMKM.Text))
                {
                    if (!string.IsNullOrEmpty(txtNL.Text))
                    {
                        if (txtMKM.Text == txtNL.Text)
                        {
                            if (password == txtMKC.Text)  
                            {
                                if (TaiKhoan_BUS.DoiMK(username, txtMKM.Text, txtMKC.Text))
                                if (MessageBox.Show("Khởi Động Lại Phần Mềm Để Hoàn Tất Cập Nhật Mật Khẩu?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                {
                                    lbMKC.Text = null;
                                    lbMKM.Text = null;
                                    lbNL.Text = null;
                                    Application.Restart();
                                }
                            }
                            else
                            {
                                lbMKC.Text = "Sai Mật Khẩu!!";
                                lbMKM.Text = null;
                                lbNL.Text = null;
                                lbTb.Text = null;
                                txtMKC.Focus();
                            }
                        }
                        else
                        {
                            lbNL.Text = "Mật Khẩu Nhập Lại Không Giống!!";
                            lbMKC.Text = null;
                            lbMKM.Text = null;
                            lbTb.Text = null;
                            txtNL.Focus();
                        }
                    }
                    else
                    {
                        lbNL.Text = "Lỗi!!";
                        lbMKC.Text = null;
                        lbMKM.Text = null;
                        lbTb.Text = null;
                        txtNL.Focus();
                    }
                }
                else
                {
                    lbMKM.Text = "Lỗi!!";
                    lbMKC.Text = null;
                    lbNL.Text = null;
                    lbTb.Text = null;
                    txtMKM.Focus();
                }
            }
            else
            {
                lbMKC.Text = "Lỗi!!";
                lbMKM.Text = null;
                lbNL.Text = null;
                lbTb.Text = null;
                txtMKC.Focus();
            }
        }
    }
}
