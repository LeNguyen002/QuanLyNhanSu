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
    public partial class NhanVien : UserControl
    {
        private string username, password;
        public NhanVien()
        {
            InitializeComponent();
        }

        string tencv = null,tenpb =null;
        public NhanVien(string user, string pass)
        {
            InitializeComponent();
            this.username = user;
            this.password = pass;
        }

        private void PhanQuyen(string quyen)
        {
            if (quyen.Trim() == "User")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                
            }
            if (quyen.Trim() == "Admin")
            {
                btnXoa.Enabled = false;
            }
        }

        private void load()
        {
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            label9.Text = null;
            lbMaNV.Text = null;

            PhanQuyen(TaiKhoan_BUS.Quyen(username, password));
            

            List<NhanVien_DTO> lstNhanVien = NhanVien_BUS.LayNV();
            dataGridView1.DataSource = lstNhanVien;
            

            dataGridView1.Columns["MaPB"].Visible = false;
            dataGridView1.Columns["MaHD"].Visible = false;
            dataGridView1.Columns["HeSoLuong"].Visible = false;
            dataGridView1.Columns["NgaySinh"].Visible = false;
            dataGridView1.Columns["DienThoai"].Visible = false;
            dataGridView1.Columns["NgayVaoLam"].Visible = false;
            dataGridView1.Columns["Hinh"].Visible = false;
            dataGridView1.Columns["SoCM"].Visible = false;
            dataGridView1.Columns["TrinhDoHV"].Visible = false;
            dataGridView1.Columns["DiaChi"].Visible = false;
            dataGridView1.Columns["Email"].Visible = false;
            dataGridView1.Columns["TTHonNhan"].Visible = false;
            dataGridView1.Columns["MaCV"].Visible = false;
            dataGridView1.Columns["TenPB"].Visible = false;
            //dataGridView1.Columns["LyDo"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (TaiKhoan_BUS.Quyen(username, password) == "User")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                lbMaNV.Text = dr.Cells["MaNhanVien"].Value.ToString();
                txtChuc.Text = dr.Cells["ChucVu"].Value.ToString();
                tencv = dr.Cells["ChucVu"].Value.ToString();
                tenpb = dr.Cells["TenPB"].Value.ToString();
                txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
                txtDT.Text = dr.Cells["DienThoai"].Value.ToString();
                txtEmail.Text = dr.Cells["Email"].Value.ToString();
                txtHonNhan.Text = dr.Cells["TTHonNhan"].Value.ToString();
                txtLuong.Text = dr.Cells["HeSoLuong"].Value.ToString();
                if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
                {
                    rdNam.Checked = true;
                }
                else rdNu.Checked = true;
                dtpNgaySinh.Text = dr.Cells["NgaySinh"].Value.ToString();
                txtPhong.Text = dr.Cells["TenPB"].Value.ToString();
                dateTimePicker1.Text = dr.Cells["NgayVaoLam"].Value.ToString();
                txtTen.Text = dr.Cells["TenNhanVien"].Value.ToString();
                txtTD.Text = dr.Cells["TrinhDoHV"].Value.ToString();
                txtSoCM.Text = dr.Cells["SoCM"].Value.ToString();
            }   
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtTen.Text = null;
            txtChuc.Text = null;
            txtDiaChi.Text = null;
            txtDT.Text = null;
            txtEmail.Text = null;
            txtHonNhan.Text = null;
            txtLuong.Text = null;
            txtPhong.Text = null;
            txtSoCM.Text = null;
            txtTD.Text = null;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void txtLuong_Leave(object sender, EventArgs e)
        {
            int t = Convert.ToInt32(txtLuong.Text);
            if (t < 0 || t > 10)
            {
                MessageBox.Show("Hệ số lương không hợp lệ không hợp lệ");
                txtLuong.Focus();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string t = txtEmail.Text;
            if (t.Contains("@") != true || t.Length < 5)
            {
                MessageBox.Show("Địa chỉ mail không hợp lệ không hợp lệ");
                txtEmail.Focus();
            }
        }

        private void lbEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "VD: ...@gmail.com";
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();
            string mahd = null, hdm=null, manvm = null;
            int hd = 0,nv1 = 0;
            hd = catchuoi(NhanVien_BUS.TimTopMaHD());
            if (hd < 9)
                hdm = "HD0" + Convert.ToInt32(hd + 1);
            else
                hdm = "HD" + Convert.ToInt32(hd + 1);
            nv.MaCV = NhanVien_BUS.TimMaCVBangTen(txtChuc.Text);
            nv.MaPB = PhongBan_BUS.TimMaPBBangTen(txtPhong.Text);
            nv.MaHD = hdm;
            
            nv1 = catchuoi1(NhanVien_BUS.TimTopMaNV());
            if (nv1 < 9)
                manvm = "NV0" + (nv1 + 1);
            else
                manvm = "NV" + (nv1 + 1);
            if (rdNam.Checked == true)
                nv.GioiTinh = "Nam";
            else
                nv.GioiTinh = "Nữ";
            nv.MaNhanVien = manvm;
            nv.Email = txtEmail.Text;
            nv.DienThoai = txtDT.Text;
            nv.TenNV = txtTen.Text;
            nv.NgaySinh = Convert.ToDateTime(dtpNgaySinh.Text);
            nv.SoCM = txtSoCM.Text;
            nv.TrinhDoHV = txtTD.Text;
            nv.Hinh = "";
            nv.NgayVaoLam = Convert.ToDateTime(dateTimePicker1.Text);
            nv.HeSoLuong = Convert.ToInt32(txtLuong.Text);
            nv.DiaChi = txtDiaChi.Text;
            nv.TTHonNhan = txtHonNhan.Text;
            if (NhanVien_BUS.ThemHD(nv))
                if (NhanVien_BUS.ThemNV(nv))
                    if (NhanVien_BUS.ThemCTCV(nv, "Tuyển Nhân Viên"))
                        MessageBox.Show("Đã thêm nhân viên");
            load();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            load();
            List<PhongBan_DTO> lstPhongBan = PhongBan_BUS.LayPB();
            txtPhong.DataSource = lstPhongBan;
            txtPhong.DisplayMember = "TenPB";
            txtPhong.ValueMember = "MaPB";

            List<ChucVu_DTO> lstChucVu = NhanVien_BUS.LayChucVu();
            txtChuc.DataSource = lstChucVu;
            txtChuc.DisplayMember = "TenCV";
            txtChuc.ValueMember = "MaCv";
        }

        private int catchuoi(string chuoicat)
        {
            string kq = chuoicat.Replace("HD", "");
            return Convert.ToInt32(kq);
        }

        private void txtDT_Leave(object sender, EventArgs e)
        {
            string t = txtDT.Text;
            if (t.Length < 9)
            {
                MessageBox.Show("Số điện thoại phải trên 9 chữ số");
                txtDT.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNhanVien = lbMaNV.Text;
            nv.MaHD = dr.Cells["MaHD"].Value.ToString();
            if (rdNam.Checked == true)
                nv.GioiTinh = "Nam";
            else
                nv.GioiTinh = "Nữ";
            nv.Email = txtEmail.Text;
            nv.DienThoai = txtDT.Text;
            nv.TenNV = txtTen.Text;
            nv.NgaySinh = Convert.ToDateTime(dtpNgaySinh.Text);
            nv.SoCM = txtSoCM.Text;
            nv.TrinhDoHV = txtTD.Text;
            nv.MaCV = NhanVien_BUS.TimMaCVBangTen(txtChuc.Text);
            nv.MaPB = PhongBan_BUS.TimMaPBBangTen(txtPhong.Text);
            nv.Hinh = "";
            nv.NgayVaoLam = Convert.ToDateTime(dateTimePicker1.Text);
            nv.HeSoLuong = Convert.ToInt32(txtLuong.Text);
            nv.DiaChi = txtDiaChi.Text;
            nv.TTHonNhan = txtHonNhan.Text;
            
            if (NhanVien_BUS.SuaNV(nv))
                if (NhanVien_BUS.SuaHD(nv))
                    if (tencv != txtChuc.Text && tenpb == txtPhong.Text)
                    {
                        if (NhanVien_BUS.SuaCTCV(nv, "Thay đổi chức vụ"))
                            MessageBox.Show("Đã sửa nhân viên");
                    }
                    else if (tencv == txtChuc.Text && tenpb != txtPhong.Text)
                    {
                        if (NhanVien_BUS.SuaCTCV(nv, "Chuyển phòng ban"))
                            MessageBox.Show("Đã sửa nhân viên");
                    }
                    else if (tencv != txtChuc.Text && tenpb != txtPhong.Text)
                    {
                        if (NhanVien_BUS.SuaCTCV(nv, "Chuyển phòng ban, Thay đổi chức vụ"))
                            MessageBox.Show("Đã sửa nhân viên");
                    }
            
            load();
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ten = txtTimTen.Text;
            List<NhanVien_DTO> lstnv = NhanVien_BUS.TimNhanVienTheoTen(ten);
            if (lstnv == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dataGridView1.DataSource = lstnv;
            dataGridView1.Columns["MaPB"].Visible = false;
            dataGridView1.Columns["MaHD"].Visible = false;
            dataGridView1.Columns["HeSoLuong"].Visible = false;
            dataGridView1.Columns["NgaySinh"].Visible = false;
            dataGridView1.Columns["DienThoai"].Visible = false;
            dataGridView1.Columns["NgayVaoLam"].Visible = false;
            dataGridView1.Columns["Hinh"].Visible = false;
            dataGridView1.Columns["SoCM"].Visible = false;
            dataGridView1.Columns["TrinhDoHV"].Visible = false;
            dataGridView1.Columns["DiaChi"].Visible = false;
            dataGridView1.Columns["Email"].Visible = false;
            dataGridView1.Columns["TTHonNhan"].Visible = false;
            dataGridView1.Columns["MaCV"].Visible = false;
            dataGridView1.Columns["TenPB"].Visible = false;
        }

        private void txtTimTen_Click(object sender, EventArgs e)
        {
            txtTimTen.Text = "";
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Thật Sự Muốn Xóa Nhân Viên Này?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                == DialogResult.OK)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.MaNhanVien = lbMaNV.Text;
                nv.MaHD = dr.Cells["MaHD"].Value.ToString();
                if (NhanVien_BUS.XoaThuongPhat(nv))
                    if (NhanVien_BUS.XoaPhuCap(nv))
                        if (NhanVien_BUS.XoaChamCong(nv))
                    if (NhanVien_BUS.XoaTaiKhoan(nv))
                        if (NhanVien_BUS.XoaCTCV(nv))
                            if (NhanVien_BUS.XoaNV(nv))
                                if (NhanVien_BUS.XoaHD(nv))
                load();

            }
        }

        private int catchuoi1(string chuoicat)
        {
            
            string kq = chuoicat.Replace("NV", "");
            return Convert.ToInt32(kq);
        }
    }
}
