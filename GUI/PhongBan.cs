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
    public partial class PhongBan : UserControl
    {


        private string username, password;
        public PhongBan()
        {
            InitializeComponent();
        }
        string ma = null, loai = null;
        public PhongBan(string user, string pass)
        {
            InitializeComponent();
            this.username = user;
            this.password = pass;
        }

        string maphong;
        public void load()
        {
            List<PhongBan_DTO> lstNhanVien = PhongBan_BUS.LayPB();
            dataGridView1.DataSource = lstNhanVien;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            label5.Text = null;
            label6.Text = null;
            lbSoNV.Text = null;
            if (TaiKhoan_BUS.Quyen(username, password) == "Admin")
            {
                btnThem.Enabled = false;
            }
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtMaPB.Text = dr.Cells["MaPB"].Value.ToString();
            txtTen.Text = dr.Cells["TenPB"].Value.ToString();
            lbSoNV.Text = dr.Cells["SoNV"].Value.ToString();
            maphong = txtMaPB.Text;
            if (TaiKhoan_BUS.Quyen(username, password) == "Admin")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPB.Text = "PB0";
            label5.Text = null;
            label6.Text = null;
            label7.Text = null;
            txtTen.Text = null;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaPB.Text))
            {
                if (!string.IsNullOrEmpty(txtTen.Text))
                {
                    PhongBan_DTO pb = new PhongBan_DTO();
                    pb.MaPB = txtMaPB.Text;
                    pb.TenPB = txtTen.Text;
                    
                    if (PhongBan_BUS.ThemPB(pb));
                    label7.Text = "Thêm Thành Công";
                    load();
                }
                else
                {
                    label6.Text = "Lỗi!!";
                    label5.Text = null;
                }
            }
            else
            {
                label5.Text = "Lỗi!!";
                label6.Text = null;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            PhongBan_DTO pb = new PhongBan_DTO();
            DataGridViewRow r = new DataGridViewRow();
            r = dataGridView1.SelectedRows[0];
            pb.MaPB = r.Cells[0].Value.ToString();
            pb.SoNV = int.Parse(r.Cells[2].Value.ToString()); ;
            if (PhongBan_BUS.XoaPB(pb))
            { 
                MessageBox.Show("Xoa Thanh cong");
                load();

            }

            else
            {
                MessageBox.Show("Vui lòng xóa hết nhân viên trong phòng, và nhân viên trong hợp đồng trước khi xóa phòng");
            }
           
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaPB.Text))
            {
                if (!string.IsNullOrEmpty(txtTen.Text))
                {
                    PhongBan_DTO pb = new PhongBan_DTO();
                    pb.MaPB = txtMaPB.Text;
                    pb.TenPB = txtTen.Text;
                    if (PhongBan_BUS.SuaPB(pb,maphong))
                    label7.Text = "Sửa Thành Công";
                    load();
                }
                else
                {
                    label6.Text = "Lỗi!!";
                    label5.Text = null;
                }
            }
            else
            {
                label5.Text = "Lỗi!!";
                label6.Text = null;
            }
        }
    }
}
