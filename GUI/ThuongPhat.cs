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
    public partial class ThuongPhat : UserControl
    {
        public ThuongPhat()
        {
            InitializeComponent();
        }
        int tien = 0, thang = DateTime.Now.Month, nam = DateTime.Now.Year;
        string mapb = null, manv = null, tenpb = null;
        string tennv = null, loai = null;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLyDo.Enabled = true;
            txtT.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            rdThuong.Enabled = true;
            rdPhat.Enabled = true;
            
            tennv = dataGridView1.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            if (dataGridView1.CurrentRow.Cells["Loai"].Value.ToString() == "Thưởng")
            {
                rdThuong.Checked = true;
                loai = "Thưởng";
            }
            else
            {
                rdPhat.Checked = true;
                loai = "Phạt";
            }
            txtLyDo.Text = dataGridView1.CurrentRow.Cells["LyDo"].Value.ToString();
            txtT.Text = dataGridView1.CurrentRow.Cells["Tien"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rdPhat.Checked == true)
                loai = "Phạt";
            else loai = "Thưởng";
            if (MessageBox.Show("Bạn Thật Sự Muốn Xóa!!", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ThuongPhat_DTO tp = new ThuongPhat_DTO();
                tp.Loai = loai;
                tp.Tien = Convert.ToInt32(txtT.Text);
                tp.LyDo = txtLyDo.Text;
                if (ThuongPhat_BUS.XoaTP(NhanVien_BUS.LayMaTheoTen(tennv), tp))
                load();
            }
        }

        private void ThuongPhat_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(cbPhongBan.Text) || cbPhongBan.Text == "Tất Cả")
               // MessageBox.Show("Vui lòng chọn Phòng Ban và Tên nhân viên trước");
            //else
            //{
                txtLyDo.Enabled = true;
                txtT.Enabled = true;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                rdThuong.Enabled = true;
                txtMa.Enabled = true;
                rdPhat.Enabled = true;
                txtLyDo.Text = null;
                txtT.Text = null;
                btnThem.Enabled = false;
           // }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (rdPhat.Checked == true)
                loai = "Phạt";
            else loai = "Thưởng";
            if (!string.IsNullOrEmpty(txtLyDo.Text))
            {
                if (!string.IsNullOrEmpty(txtT.Text))
                {
                    ThuongPhat_DTO tp = new ThuongPhat_DTO();
                    tp.Loai = loai;
                    tp.Tien = Convert.ToInt32(txtT.Text);
                    tp.LyDo = txtLyDo.Text;
                    tp.Ngay = DateTime.Now;
                    if (ThuongPhat_BUS.ThemTP(txtMa.Text, tp));
                    load();
                }

            }
        }

        DateTime nd, nc;
        public void load()
        {
            nd = Convert.ToDateTime(thang + "/1" + "/" + nam);
            nc = Convert.ToDateTime(thang + "/30" + "/" + nam);
            txtLyDo.Enabled = false;
            txtT.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            rdThuong.Enabled = false;
            txtMa.Enabled = false;
            rdPhat.Enabled = false;
            txtLyDo.Text = null;
            txtT.Text = null;
            rdThuong.Checked = false;
            rdPhat.Checked = false;
            txtMa.Text = null;
            List<ThuongPhat_DTO> lstThuongPhat = ThuongPhat_BUS.LayTP();
            dataGridView1.DataSource = lstThuongPhat;
            dataGridView1.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns["TenNhanVien"].Width = 200;
            dataGridView1.Columns["Loai"].HeaderText = "Loại";
            dataGridView1.Columns["Loai"].Width = 50;
            dataGridView1.Columns["Tien"].HeaderText = "VND";
            dataGridView1.Columns["Tien"].Width = 90;
            dataGridView1.Columns["LyDo"].HeaderText = "Lý Do";
            dataGridView1.Columns["LyDo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Ngay"].HeaderText = "Ngày";
            dataGridView1.Columns["Ngay"].Width = 60;
        }
    }
}
