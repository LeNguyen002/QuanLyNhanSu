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
    public partial class BangLuong : UserControl
    {
        private string username, password;
        public BangLuong()
        {
            InitializeComponent();
        }
        public BangLuong(string user, string pass)
        {
            InitializeComponent();
            this.username = user;
            this.password = pass;
        }

        int thang = DateTime.Now.Month, nam = DateTime.Now.Year, ngay = DateTime.Now.Day, luongcoban = 0, tongluong = 0, tienthuong = 0, tienphat = 0, phucap = 0, m = 0;

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtThang.Text))
            {
                if (!string.IsNullOrEmpty(txtNam.Text))
                {
                    if (Convert.ToInt32(txtThang.Text) > 12 || Convert.ToInt32(txtThang.Text) < 1)
                    {
                        lbTB.Text = "Tháng không hợp lệ";
                    }
                    else
                    {
                        m = 1;
                        dataGridView1.Refresh();
                        load();
                        lbTB.Text = null;
                    }
                }
                else
                {
                    lbTB.Text = "Lỗi";
                }
            }
            else
            {
                lbTB.Text = "Lỗi";
            }
        }



        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbHeSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(cbHeSoLuong.Text);
            if (a > 0 && a < 11)
            {
                txtLCB.Text = Luong_BUS.LayCBTheoHS(cbHeSoLuong.Text);
                btCapNhat.Enabled = true;
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(cbHeSoLuong.Text);
            if (!string.IsNullOrEmpty(cbHeSoLuong.Text))
            {
                if (!string.IsNullOrEmpty(txtLCB.Text))
                {
                    if (a > 0 && a < 11)
                    {
                        if (Luong_BUS.SuaLuongCB(Convert.ToInt32(cbHeSoLuong.Text), Convert.ToInt32(txtLCB.Text)))
                            load();
                        else
                        {
                            MessageBox.Show("Không tồn tại Hệ số lương đang nhập");
                            cbHeSoLuong.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi!!");
                    txtLCB.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lỗi!!");
                cbHeSoLuong.Focus();
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            lbTen.Text = dataGridView1.CurrentRow.Cells["TenNV"].Value.ToString();
            cbHeSoLuong.Text = dataGridView1.CurrentRow.Cells["HeSoLuong"].Value.ToString();
            btCapNhat.Enabled = true;
            string manv = dataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            lbChucVu.Text = Luong_BUS.LayCV(manv);
            txtLCB.Text = Luong_BUS.LayCB(manv);

        }

        string manv = null, songaylam = null, songaynghicophep = null, songaynghikhongphep = null, chucvu = null;
        public void load()
        {
            DateTime ngaydau, ngaycuoi;
            songaylam = "0"; luongcoban = 0; tongluong = 0; tienthuong = 0; tienphat = 0; phucap = 0;
            if (m == 0)
            {
                ngaydau = Convert.ToDateTime(thang + "/" + "01/" + nam);
                ngaycuoi = Convert.ToDateTime(thang + "/" + "30/" + nam);
            }
            else
            {
                ngaydau = Convert.ToDateTime(txtThang.Text + "/" + "01/" + txtNam.Text);
                ngaycuoi = Convert.ToDateTime(txtThang.Text + "/" + "30/" + txtNam.Text);
            }
            btCapNhat.Enabled = false;
            lbTen.Text = null;
            lbChucVu.Text = null;
            lbTB.Text = null;
            List<Luong_DTO> lstLuong = Luong_BUS.LayLuong();
            dataGridView1.DataSource = lstLuong;
            dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dataGridView1.Columns["MaNhanVien"].Width = 70;
            dataGridView1.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns["TenNV"].Width = 200;
            dataGridView1.Columns["HeSoLuong"].HeaderText = "Hệ Số Lương";
            dataGridView1.Columns["HeSoLuong"].Width = 100;
            dataGridView1.Columns["NL"].HeaderText = "Số Ngày Làm";
            dataGridView1.Columns["NL"].Width = 70;
            dataGridView1.Columns["T"].HeaderText = "Tiền Thưởng";
            dataGridView1.Columns["T"].Width = 100;
            dataGridView1.Columns["P"].HeaderText = "Tiền Phạt";
            dataGridView1.Columns["P"].Width = 100;
            dataGridView1.Columns["PhuCap"].HeaderText = "Phụ Cấp";
            dataGridView1.Columns["PhuCap"].Width = 100;
            dataGridView1.Columns["TL"].HeaderText = "Tổng Lương";
            dataGridView1.Columns["TL"].Width = 110;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                manv = dataGridView1.Rows[i].Cells["MaNhanVien"].Value.ToString();
                songaylam = Luong_BUS.LaySoNgayLam(manv, ngaydau, ngaycuoi);
                tienthuong = Luong_BUS.LayTienThuong(manv, ngaydau, ngaycuoi);
                tienphat = Luong_BUS.LayTienPhat(manv, ngaydau, ngaycuoi);
                dataGridView1.Rows[i].Cells["NL"].Value = songaylam;
                dataGridView1.Rows[i].Cells["T"].Value = tienthuong;
                dataGridView1.Rows[i].Cells["P"].Value = tienphat;
                dataGridView1.Rows[i].Cells["PhuCap"].Value = Luong_BUS.LayPhuCap(manv, ngaycuoi);
                tongluong = TinhLuong1(manv, songaylam, tienthuong.ToString(), tienphat.ToString(), ngaydau, ngaycuoi);
                dataGridView1.Rows[i].Cells["TL"].Value = tongluong;
            }

            if (TaiKhoan_BUS.Quyen(username, password) == "User" || TaiKhoan_BUS.Quyen(username, password) == "Admin")
            {
                cbHeSoLuong.Enabled = false;
                txtLCB.Enabled = false;
                btCapNhat.Enabled = false;
            }
        }
        private void BangLuong_Load(object sender, EventArgs e)
        {
            load();
            txtNam.Text = "2023";
        }

        private int TinhLuong1(string manv, string soNgayLam, string tienThuong, string tienPhat, DateTime ngaydau, DateTime ngaycuoi)
        {

            int a = Convert.ToInt32(tienThuong) - Convert.ToInt32(tienPhat);
            int ncp = Convert.ToInt32(Luong_BUS.LayNghiCP(manv, ngaydau, ngaycuoi));
            int luongCoBan = Convert.ToInt32(Luong_BUS.LayCB(manv));
            int nl = Convert.ToInt32(songaylam);
            int p = Luong_BUS.LayPhuCap(manv, ngaycuoi);
            if (ncp > 3)
                nl = nl - (ncp % 3);
            tongluong = (luongCoBan / 26) * nl + a + p;
            return tongluong;
        }


        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;


            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value = "Mã nhân viên";
            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value = "Tên nhân viên";
            cl2.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value = "Hệ số lương";
            cl3.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value = "Số ngày làm";
            cl4.ColumnWidth = 12;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value = "Tiền thưởng";
            cl5.ColumnWidth = 12;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value = "Tiền phạt";
            cl6.ColumnWidth = 12;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value = "Phụ cấp";
            cl7.ColumnWidth = 12;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value = "Tổng lương";
            cl8.ColumnWidth = 18;


            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 6;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng theo datatable
            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];


            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];
                for (int col = 0; col < dataTable.Columns.Count; col++)
                    arr[row, col] = dataRow[col];
            }


            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count - 1;
            int columnEnd = dataTable.Columns.Count;


            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart]; // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;


            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn("1");
            DataColumn col2 = new DataColumn("2");
            DataColumn col3 = new DataColumn("3");
            DataColumn col4 = new DataColumn("4");
            DataColumn col5 = new DataColumn("5");
            DataColumn col6 = new DataColumn("6");
            DataColumn col7 = new DataColumn("7");
            DataColumn col8 = new DataColumn("8");

            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);
            dt.Columns.Add(col5);
            dt.Columns.Add(col6);
            dt.Columns.Add(col7);
            dt.Columns.Add(col8);


            foreach (DataGridViewRow dtgvRow in dataGridView1.Rows)
            {
                DataRow dtrow = dt.NewRow();
                dtrow[0] = dtgvRow.Cells[0].Value; 
                dtrow[1] = dtgvRow.Cells[1].Value; 
                dtrow[2] = dtgvRow.Cells[2].Value; 
                dtrow[3] = dtgvRow.Cells[3].Value; 
                dtrow[4] = dtgvRow.Cells[4].Value; 
                dtrow[5] = dtgvRow.Cells[5].Value; 
                dtrow[6] = dtgvRow.Cells[6].Value;
                dtrow[7] = dtgvRow.Cells[7].Value;

                dt.Rows.Add(dtrow);
            }         
            ExportFile(dt, "Danh sách", "DANH SÁCH LƯƠNG NHÂN VIÊN");
        }

    }
}
