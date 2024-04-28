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
    public partial class LSLam : UserControl
    {
        public LSLam()
        {
            InitializeComponent();
        }

        private void LSLam_Load(object sender, EventArgs e)
        {
            List<LichSu_DTO> lstLuong = NhanVien_BUS.LayLichSu();
            dataGridView1.DataSource = lstLuong;
            dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dataGridView1.Columns["MaNhanVien"].Width = 70;
            dataGridView1.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns["TenNV"].Width = 200;
            dataGridView1.Columns["TenCv"].HeaderText = "Tên Chức Vụ";
            dataGridView1.Columns["TenCv"].Width = 100;
            dataGridView1.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
            dataGridView1.Columns["NgayBatDau"].Width = 70;
            dataGridView1.Columns["LyDo"].HeaderText = "Lý Do";
            dataGridView1.Columns["LyDo"].Width = 150;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = NhanVien_BUS.LayMaTheoTen(txtTen.Text);
                List<LichSu_DTO> lstLuong = NhanVien_BUS.LayLichSuTheoMa(manv);
                dataGridView1.DataSource = lstLuong;
                dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dataGridView1.Columns["MaNhanVien"].Width = 70;
                dataGridView1.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
                dataGridView1.Columns["TenNV"].Width = 200;
                dataGridView1.Columns["TenCv"].HeaderText = "Tên Chức Vụ";
                dataGridView1.Columns["TenCv"].Width = 100;
                dataGridView1.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
                dataGridView1.Columns["NgayBatDau"].Width = 70;
                dataGridView1.Columns["LyDo"].HeaderText = "Lý Do";
                dataGridView1.Columns["LyDo"].Width = 150;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hoặc không tồn tại tên nhân viên vừa nhập");

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            List<LichSu_DTO> lstLuong = NhanVien_BUS.LayLichSu();
            dataGridView1.DataSource = lstLuong;
            dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dataGridView1.Columns["MaNhanVien"].Width = 70;
            dataGridView1.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns["TenNV"].Width = 200;
            dataGridView1.Columns["TenCv"].HeaderText = "Tên Chức Vụ";
            dataGridView1.Columns["TenCv"].Width = 100;
            dataGridView1.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
            dataGridView1.Columns["NgayBatDau"].Width = 70;
            dataGridView1.Columns["LyDo"].HeaderText = "Lý Do";
            dataGridView1.Columns["LyDo"].Width = 150;
        }
    }
}
