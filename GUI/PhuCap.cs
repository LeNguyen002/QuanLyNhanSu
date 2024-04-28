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
    public partial class PhuCap : UserControl
    {
        private string username, password;
        public PhuCap()
        {
            InitializeComponent();
        }
        string ma = null, loai = null;
        public PhuCap(string user, string pass)
        {
            InitializeComponent();
            this.username = user;
            this.password = pass;
        }

        public void load()
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            txtTien.Enabled = false;
            btLuu.Enabled = false;
            btXoa.Enabled = false;
            btSua.Enabled = false;
            if (TaiKhoan_BUS.Quyen(username,password)=="Admin")
            {
                btThem.Enabled = false;
                btSua.Enabled = false;
                btXoa.Enabled = false;
                btLuu.Enabled = false;
                dataGridView1.Enabled = false;
            }
            List<PhuCap_DTO> lstPhuCap = PhuCap_BUS.LayPC();
            dataGridView1.DataSource = lstPhuCap;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = true;
            txtTen.Enabled = true;
            txtTien.Enabled = true;
            btLuu.Enabled = true;
            txtTen.Clear();
            txtTien.Clear();
            btThem.Enabled = false;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            PhuCap_DTO pc = new PhuCap_DTO();
            pc.MaNhanVien = txtMa.Text;
            pc.LoaiPC = txtTen.Text;
            pc.Tien = int.Parse(txtTien.Text);
            pc.TuNgay = dtpTu.Value;
            pc.DenNgay = dtpDen.Value;
            if (PhuCap_BUS.ThemPC(pc))
            load();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            PhuCap_DTO pc = new PhuCap_DTO();
            pc.MaNhanVien = txtMa.Text;
            pc.LoaiPC = txtTen.Text;
            pc.Tien = int.Parse(txtTien.Text);
            pc.TuNgay = dtpTu.Value;
            pc.DenNgay = dtpDen.Value;
            if (PhuCap_BUS.SuaPC(pc))
                load();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            PhuCap_DTO pc = new PhuCap_DTO();
            pc.MaNhanVien = txtMa.Text;
            pc.LoaiPC = txtTen.Text;
            pc.Tien = int.Parse(txtTien.Text);
            pc.TuNgay = dtpTu.Value;
            pc.DenNgay = dtpDen.Value;
            if (PhuCap_BUS.XoaPC(pc))
                load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTen.Text = dataGridView1.CurrentRow.Cells["TenPC"].Value.ToString();
            txtTien.Text = dataGridView1.CurrentRow.Cells["Tien"].Value.ToString();
            dtpTu.Text = dataGridView1.CurrentRow.Cells["TuNgay"].Value.ToString();
            dtpDen.Text = dataGridView1.CurrentRow.Cells["DenNgay"].Value.ToString();
            txtMa.Text = dataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            btSua.Enabled = true;
            btXoa.Enabled = true;
            btThem.Enabled = true;
            txtMa.Enabled = true;
            txtTen.Enabled = true;
            txtTien.Enabled = true;
        }

        private void PhuCap_Load(object sender, EventArgs e)
        {
            load();

        }
    }
}
