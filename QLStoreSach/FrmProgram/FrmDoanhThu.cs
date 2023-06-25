using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

namespace QLStoreSach.FrmProgram
{
    public partial class FrmDoanhThu : Form
    {
        public FrmDoanhThu()
        {
            InitializeComponent();
        }
        static string strCon = @"Data Source=XUANHUONG;Initial Catalog=QLStoreSach;Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(strCon);


        //load lên listview
        private void loadDT()
        {
            lvDoanhThu.Items.Clear();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("select * from HoaDon ORDER BY NgayLap DESC", sqlCon);
                //thuc thi
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaHoaDon = reader.GetString(0);
                    string MaKhachHang = reader.GetString(1);
                    int TongTien = reader.GetInt32(3);

                    //hien thi len giao dien
                    ListViewItem lv = new ListViewItem(MaHoaDon);
                    lv.SubItems.Add(MaKhachHang);
                    lv.SubItems.Add(DateTime.Parse(reader["NgayLap"].ToString()).ToString("dd-MM-yyyy"));
                    lv.SubItems.Add(TongTien.ToString());
                    lvDoanhThu.Items.Add(lv);
                }
                //đóng
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
            }
            catch
            {
                this.Alert("Error", FrmThongBao.enmType.Error);
            }
        }

        private void FrmDoanhThu_Load(object sender, EventArgs e)
        {
            loadDT();
        }
        public void Alert(string msg, FrmThongBao.enmType type)
        {
            FrmThongBao frm = new FrmThongBao();
            frm.showAlert(msg, type);
        }

        private void bunifuDatepicker2_onValueChanged(object sender, EventArgs e)
        {
            selectDate();
        }        

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            selectDate();
        }
        // lọc dữ leeiuj theo ngày
        private void selectDate()
        {
            lvDoanhThu.Items.Clear();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("select * from HoaDon where CAST(NgayLap as date) between '" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' and '" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "' ORDER BY NgayLap DESC", sqlCon);
                //thuc thi
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaHoaDon = reader.GetString(0);
                    string MaKhachHang = reader.GetString(1);
                    int TongTien = reader.GetInt32(3);

                    //hien thi len giao dien
                    ListViewItem lv = new ListViewItem(MaHoaDon);
                    lv.SubItems.Add(MaKhachHang);
                    lv.SubItems.Add(DateTime.Parse(reader["NgayLap"].ToString()).ToString("dd-MM-yyyy"));
                    lv.SubItems.Add(TongTien.ToString());
                    lvDoanhThu.Items.Add(lv);
                }
                //đóng
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Lỗi không thể tìm kiếm", FrmThongBao.enmType.Error);
            }
        }
        // tìm kiếm theo mã hóa đơn
        private void selectMHD()
        {
            lvDoanhThu.Items.Clear();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("select * from HoaDon where MaHoaDon like N'" + tbTimKiem.Text + "%'ORDER BY NgayLap", sqlCon);
                //thuc thi
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaHoaDon = reader.GetString(0);
                    string MaKhachHang = reader.GetString(1);
                    int TongTien = reader.GetInt32(3);

                    //hien thi len giao dien
                    ListViewItem lv = new ListViewItem(MaHoaDon);
                    lv.SubItems.Add(MaKhachHang);
                    lv.SubItems.Add(DateTime.Parse(reader["NgayLap"].ToString()).ToString("dd-MM-yyyy"));
                    lv.SubItems.Add(TongTien.ToString());
                    lvDoanhThu.Items.Add(lv);
                }
                //đóng
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Lỗi không thể tìm kiếm", FrmThongBao.enmType.Error);
            }
        }
        //tìm kiếm theo mã khách hàng
        private void selectMKH()
        {
            lvDoanhThu.Items.Clear();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("select * from HoaDon where MaKhachHang like N'" + tbTimKiem.Text + "%'ORDER BY NgayLap DESC", sqlCon);
                //thuc thi
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaHoaDon = reader.GetString(0);
                    string MaKhachHang = reader.GetString(1);
                    int TongTien = reader.GetInt32(3);

                    //hien thi len giao dien
                    ListViewItem lv = new ListViewItem(MaHoaDon);
                    lv.SubItems.Add(MaKhachHang);
                    lv.SubItems.Add(DateTime.Parse(reader["NgayLap"].ToString()).ToString("dd-MM-yyyy"));
                    lv.SubItems.Add(TongTien.ToString());
                    lvDoanhThu.Items.Add(lv);
                }
                //đóng
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Lỗi không thể tìm kiếm", FrmThongBao.enmType.Error);
            }
        }
        //tìm kiếm
        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            bool Kh = false;
            string Khh = @"k";
            foreach (var item in Khh)
            {
                if (tbTimKiem.Text.Contains(item))
                {
                    Kh = true;
                    break;
                }
            }
            if (Kh)
            {
                selectMKH();
            }
            else if (tbTimKiem.Text.Length == 0)
            {
                loadDT();
            }
            else
            {
                selectMHD();
            }
        }
        //mở frm chi tiết hóa đơn
        private Form activeForm = null;
        public void OpenFrm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // xem chi tiết hóa đơn
        private void lvDoanhThu_DoubleClick(object sender, EventArgs e)
        {
            string MaKH = lvDoanhThu.SelectedItems[0].SubItems[1].Text;
            string NgayL = lvDoanhThu.SelectedItems[0].SubItems[2].Text;
            string TongT = lvDoanhThu.SelectedItems[0].SubItems[3].Text;
            if (lvDoanhThu.SelectedItems.Count == 1)
            {
                string select_MaHoaDon = lvDoanhThu.SelectedItems[0].Text;

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from ChiTietHoaDon where MaHoaDon ='" + select_MaHoaDon + "'", sqlCon);

                SqlDataReader reader = cmd.ExecuteReader();
                string MaHD = "";
                while (reader.Read())
                {
                    MaHD = reader.GetString(0);
                }
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();                
                OpenFrm(new ChiTietDoanhThu(MaHD: MaHD, NgayL: NgayL, MaKH: MaKH, TongT: TongT));
            }
        }
        //xuất file excel
        private void btnXuat_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "Mã hóa đơn";
                    ws.Cells[1, 2] = "Mã khách hàng";
                    ws.Cells[1, 3] = "Ngày lập hóa đơn";
                    ws.Cells[1, 4] = "Tổng tiền";
                    int i = 2;
                    foreach (ListViewItem item in lvDoanhThu.Items)
                    {
                        ws.Cells[i, 1] = item.SubItems[0].Text;
                        ws.Cells[i, 2] = item.SubItems[1].Text;
                        ws.Cells[i, 3] = item.SubItems[2].Text;
                        ws.Cells[i, 4] = item.SubItems[3].Text;
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    this.Alert("Xuất file báo cáo excel thành công.", FrmThongBao.enmType.Success);

                }
            }
        }
    }
}
