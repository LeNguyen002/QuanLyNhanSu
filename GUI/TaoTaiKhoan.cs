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
    public partial class TaoTaiKhoan : UserControl
    {
        public TaoTaiKhoan()
        {
            InitializeComponent();
        }

        int dem = 0;

        public void load()
        {
            dem = 0;
            List<NhanVien_DTO> lstNhanVien = TaiKhoan_BUS.NVChuaTK();
            dataGridView1.DataSource = lstNhanVien;
            dataGridView1.Columns["MaPB"].Visible = false;
            dataGridView1.Columns["MaHD"].Visible = false;
            dataGridView1.Columns["HeSoLuong"].Visible = false;
            dataGridView1.Columns["GioiTinh"].Visible = false;
            dataGridView1.Columns["NgaySinh"].Visible = false;
            dataGridView1.Columns["SoCM"].Visible = false;
            dataGridView1.Columns["DienThoai"].Visible = false;
            dataGridView1.Columns["TrinhDoHV"].Visible = false;
            dataGridView1.Columns["DiaChi"].Visible = false;
            dataGridView1.Columns["Email"].Visible = false;
            dataGridView1.Columns["Hinh"].Visible = false;
            dataGridView1.Columns["TTHonNhan"].Visible = false;
            dataGridView1.Columns["NgayVaoLam"].Visible = false;
            dataGridView1.Columns["TenPB"].Visible = false;
            dataGridView1.Columns["MaCV"].Visible = false;
            btnLuu.Enabled = false;
            timer1.Start();
            txtTK.Clear();
            txtMK.Clear();
            cbQuyen.Text = null;

        }


        private void TaoTaiKhoan_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            timer1.Stop();
            string manv = dataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            lbMaNV.Text = manv;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (!string.IsNullOrEmpty(txtTK.Text))
            {
                if (!string.IsNullOrEmpty(txtMK.Text))
                {
                    if (!string.IsNullOrEmpty(cbQuyen.Text))
                    {
                        TaiKhoan_DTO tk = new TaiKhoan_DTO();
                        tk.MaNhanVien = lbMaNV.Text;
                        tk.TenDangNhap = txtTK.Text;
                        tk.MatKhau = txtMK.Text;
                        tk.TenQuyenHan = cbQuyen.Text;
                        if (TaiKhoan_BUS.ThemTK(tk) == false)
                        {
                            MessageBox.Show("Tài Khoản Đã Tồn Tại!! Vui Lòng Chọn Tài Khoản Khác");
                            txtTK.Clear();
                            txtTK.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Thêm Thành Công");
                            load();
                        }
               

                    }
                    else
                    {
                        MessageBox.Show("Chọn Quyền Hạn");
                        cbQuyen.Focus();
                        timer1.Stop();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập Mật Khẩu");
                    txtMK.Focus();
                    timer1.Stop();
                }
            }
            else
            {
                MessageBox.Show("Nhập Tài Khoản");
                txtTK.Focus();
                timer1.Stop();

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
    }
}
