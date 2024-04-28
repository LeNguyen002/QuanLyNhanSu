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
    public partial class ChamCong : UserControl
    {
        public ChamCong()
        {
            InitializeComponent();
        }
        int ngay = DateTime.Now.Day, thang = DateTime.Now.Month, nam = DateTime.Now.Year, dem = 0;
        string manv = null;
        string a, b = null;
        public void load()
        {
            label2.Text = null;
            lbMa.Text = null;
            lbTen.Text = null;
            lbTinhTrang.Text = null;
            btCapNhat.Enabled = false;
            a =  ChamCong_BUS.LayCC2(dtpNgay.Value);
            b = dtpNgay.Value.Month + "/" + dtpNgay.Value.Day + "/" + dtpNgay.Value.Year + " 12:00:00 AM";
            if (a == b)
            {
                MessageBox.Show("Đã chấm công cho ngày " + dtpNgay.Value.Month + "/" + dtpNgay.Value.Day + "/" + dtpNgay.Value.Year, "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                dataGridView1.Refresh();
                List<ChamCong_DTO> chamCong = ChamCong_BUS.LayCC(dtpNgay.Value);
                dataGridView1.DataSource = chamCong;
                dataGridView1.Columns["Ngay"].Visible = false;
                dem = 1;
            }
            else
            {
                btCapNhat.Enabled = true;
                dataGridView1.Refresh();
                List<ChamCong_DTO> chamCong = ChamCong_BUS.LayCC1();
                dataGridView1.DataSource = chamCong;
                dataGridView1.Columns["Ngay"].Visible = false;
                dem = 0;
            }
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            a = ChamCong_BUS.LayCC2(dtpNgay.Value);
            b = dtpNgay.Value.Month + "/" + dtpNgay.Value.Day + "/" + dtpNgay.Value.Year + " 12:00:00 AM";
            if (a == b)
            {
                MessageBox.Show("Đã chấm công cho ngày " + dtpNgay.Value.Month + "/" + dtpNgay.Value.Day + "/" + dtpNgay.Value.Year, "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                dataGridView1.Refresh();
                List<ChamCong_DTO> chamCong = ChamCong_BUS.LayCC(dtpNgay.Value);
                dataGridView1.DataSource = chamCong;
                dataGridView1.Columns["Ngay"].Visible = false;
                dem = 1;
            }
            else
            {
                btCapNhat.Enabled = true;
                dataGridView1.Refresh();
                List<ChamCong_DTO> chamCong = ChamCong_BUS.LayCC1();
                dataGridView1.DataSource = chamCong;
                dataGridView1.Columns["Ngay"].Visible = false;
                dem = 0;
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (ChamCong_BUS.XoaCC(dtpNgay.Value))
                {
                    a = null;
                    b = null;
                    load();
                }
                else
                {
                    label2.Text = "Lỗi!!";
                }
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {  
                int d = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells["TinhTrang"].Value == null)
                    {
                        label2.ForeColor = Color.Red;
                        label2.Text = "Lỗi!! \n Vui lòng kiểm tra lại";
                        dataGridView1.Rows[i].Cells["TinhTrang"].Selected = true;
                        d = 0;
                    }
                    else d++;
                }
                if (d != 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string tinhtrang = dataGridView1.Rows[i].Cells["TinhTrang"].Value.ToString();
                        manv = dataGridView1.Rows[i].Cells["Ma"].Value.ToString();
                        if (ChamCong_BUS.ThemChamCong(manv, dtpNgay.Value, tinhtrang) == false)
                        {
                            return;
                        }
                    }
                    load();
                }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 && dem == 1)
            {
                lbMa.Text = dataGridView1.CurrentRow.Cells["Ma"].Value.ToString();
                lbTen.Text = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString();
                lbTinhTrang.Text = dataGridView1.CurrentRow.Cells["TinhTrang"].Value.ToString();
            }
            else if (e.ColumnIndex != 0 && dem == 0)
            {
                lbMa.Text = dataGridView1.CurrentRow.Cells["Ma"].Value.ToString();
                lbTen.Text = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString();
                lbTinhTrang.Text = "Chưa có giá trị";
            }
        }

        private void cbCC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCC.Checked == true)
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].Cells["TinhTrang"].Value = "Đi Làm";
            else
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].Cells["TinhTrang"].Value = "";
        }

        private void ChamCong_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
