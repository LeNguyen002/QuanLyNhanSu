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
    public partial class DoiThongTin : UserControl
    {
        private string gt;
        private string username, password;
        public DoiThongTin()
        {
            InitializeComponent();
        }

        public DoiThongTin(string user, string pass)
        {
            InitializeComponent();
            this.username = user;
            this.password = pass;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTen.Text))
            {
                if (!string.IsNullOrEmpty(txtSoCM.Text))
                {
                    if (!string.IsNullOrEmpty(txtDT.Text))
                    {
                        if (!string.IsNullOrEmpty(txtTrinhDo.Text))
                        {
                            if (!string.IsNullOrEmpty(txtDiaChi.Text))
                            {
                                if (!string.IsNullOrEmpty(txtEmail.Text))
                                {
                                    if (!string.IsNullOrEmpty(txtHonNhan.Text))
                                    {
                                        if (MessageBox.Show("Bạn muốn sửa?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            
                                            if (TaiKhoan_BUS.SuaThongTin(lbMaNV.Text,txtTen.Text,gt, Convert.ToDateTime(dtpNgaySinh.Text),txtSoCM.Text,txtDT.Text, txtTrinhDo.Text, txtDiaChi.Text, txtEmail.Text,txtHonNhan.Text))
                                            lbLoi.Text = "Đã Lưu!!";
                                                if (MessageBox.Show("Khởi động lại phần mềm để cập nhật thông tin vừa thay đổi?", "Thông Báo",
                                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                                    Application.Restart();
                                        }

                                    }
                                    else
                                    {
                                        lbLoi.Text = "Lỗi!!";
                                        txtHonNhan.Focus();
                                    }
                                }
                                else
                                {
                                    lbLoi.Text = "Lỗi!!";
                                    txtEmail.Focus();
                                }
                            }
                            else
                            {
                                lbLoi.Text = "Lỗi!!";
                                txtDiaChi.Focus();
                            }
                        }
                        else
                        {
                            lbLoi.Text = "Lỗi!!";
                            txtTrinhDo.Focus();
                        }
                    }
                    else
                    {
                        lbLoi.Text = "Lỗi!!";
                        txtDT.Focus();
                    }
                }
                else
                {
                    lbLoi.Text = "Lỗi!!";
                    txtSoCM.Focus();
                }
            }
            else
            {
                lbLoi.Text = "Lỗi!!";
                txtTen.Focus();
            }
        }

        private void DoiThongTin_Load(object sender, EventArgs e)
        {
            NhanVien_DTO nv = TaiKhoan_BUS.ThongTinNV(username, password);
            lbMaNV.Text = nv.MaNhanVien;
            txtTen.Text = nv.TenNV;
            if (nv.GioiTinh == "Nam")
                rdNam.Checked = true;
            else rdNu.Checked = true;
            dtpNgaySinh.Value = nv.NgaySinh;
            txtSoCM.Text = nv.SoCM;
            txtDT.Text = nv.DienThoai;
            txtTrinhDo.Text = nv.TrinhDoHV;
            txtDiaChi.Text = nv.DiaChi;
            txtEmail.Text = nv.Email;
            txtHonNhan.Text = nv.TTHonNhan;
            pictureBox1.Image = Image.FromFile(nv.Hinh);
            if (rdNam.Checked == true)
                gt = "Nam";
            else gt = "Nữ";
        }
    }
}
