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
    public partial class MainForm : Form
    {
        private string username,password;
        public MainForm()
        {
            InitializeComponent();
        }

        public bool isExit = true;

        public event EventHandler Logout;

        public MainForm(string user,string pass)
        {
            InitializeComponent();
            this.username = user;
            this.password = pass;
        }

        private void load()
        {
            timer1.Start();
            label1.Text = "Chào: " + TaiKhoan_BUS.LayTenNV(username, password);
            if (TaiKhoan_BUS.Quyen(username, password) == "User")
            {
                btnTaoTK.Enabled = false;
                btnPhongBan.Enabled = false;
                btnChamCong.Enabled = false;
                btnChucVu.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                btTKLuong.Enabled = false;
                btPhuCap.Enabled = false;
                brnChamCong.Enabled = false;
            }
            if (TaiKhoan_BUS.Quyen(username, password) == "Admin")
            {
                btnTaoTK.Enabled = false;
                btTKLuong.Enabled = false;
            }
            if (TaiKhoan_BUS.Quyen(username, password) == "Super Admin")
            {
                btnTaoTK.Enabled = true;
                btnPhongBan.Enabled = true;
                btnChamCong.Enabled = true;
                btnChucVu.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                btTKLuong.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            if (MessageBox.Show("Ban muon thoat chuong trinh", "Canh bao", MessageBoxButtons.YesNo) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            DoiMatKhau dmk = new DoiMatKhau(username,password);
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(dmk);
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            pnLoad.Controls.Clear();
            SuaTK stk = new SuaTK();
            pnLoad.Controls.Add(stk);
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            PhongBan pb = new PhongBan(username, password);
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(pb);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            NhanVien nv = new NhanVien(username,password);
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(nv);
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            ChucVu cv = new ChucVu();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(cv);
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            ChamCong cc = new ChamCong();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(cc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            BangLuong tl = new BangLuong(username,password);
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tl);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            ThuongPhat tp = new ThuongPhat();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tp);
        }

        private void btPhuCap_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            PhuCap pc = new PhuCap(username, password);
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(pc);
        }

        private void brnChamCong_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            ThongKeChamCong tkcc = new ThongKeChamCong();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tkcc);
        }

        private void btTKLuong_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            LSLam tkcc = new LSLam();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tkcc);
        }

        private void btnThongTinCN_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            DoiThongTin dmk = new DoiThongTin(username, password);
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(dmk);
        }

        
    }
}
