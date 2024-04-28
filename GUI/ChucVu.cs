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

namespace GUI
{
    public partial class ChucVu : UserControl
    {
        public ChucVu()
        {
            InitializeComponent();
        }

        private void load()
        {
            
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenCV.Text = null;
            txtMaCV.Text = null;
            lbTB.Text = null;
            List<ChucVu_DTO> lstnv = NhanVien_BUS.LayChucVu();
            dataGridView1.DataSource = lstnv;
        }

        private void ChucVu_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtTenCV.Text = null;
            txtMaCV.Text = "CV";
            txtMaCV.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtMaCV.Text = dr.Cells["MaCV"].Value.ToString();
            txtTenCV.Text = dr.Cells["TenCV"].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaCV.Text))
            {
                if (!string.IsNullOrEmpty(txtMaCV.Text))
                {
                    ChucVu_DTO cv = new ChucVu_DTO();
                    cv.MaCV = txtMaCV.Text;
                    cv.TenCv = txtTenCV.Text;
                    if (ChucVu_BUS.ThemCV(cv))
                    lbTB.Text = "Đã lưu!!";
                    load();
                }
                else
                {
                    MessageBox.Show("Lỗi");
                    txtTenCV.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lỗi");
                txtMaCV.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (ChucVu_BUS.XoaCV(txtMaCV.Text))
                {
                    MessageBox.Show("Xóa thành công");
                    load();
                }
                else
                {
                    MessageBox.Show("Vui lòng chuyển hết nhân viên đang giữ chức vụ hiện tại trước khi xóa");
                }
            }
        }
    }
}
