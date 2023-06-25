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
    public partial class FrmQLKho : Form
    {
        public FrmQLKho()
        {
            InitializeComponent();
        }

        #region kết nối sql và show ra giao diện

        static string strCon = @"Data Source=XUANHUONG;Initial Catalog=QLStoreSach;Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(strCon);

        public void Alert(string msg, FrmThongBao.enmType type)
        {
            FrmThongBao frm = new FrmThongBao();
            frm.showAlert(msg, type);
        }
        private Form activeForm = null;

        private void listviewLoad()
        {
            lvDS.Items.Clear();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Kho", sqlCon);
                //thuc thi
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaSach = reader.GetString(0);
                    string NhaCC = reader.GetString(1);
                    int GiaGoc = reader.GetInt32(2);
                    int Soluong = reader.GetInt32(3);

                    //hien thi len giao dien
                    ListViewItem lvi = new ListViewItem(MaSach);
                    lvi.SubItems.Add(NhaCC);
                    lvi.SubItems.Add(GiaGoc.ToString());
                    lvi.SubItems.Add(Soluong.ToString());
                    lvi.SubItems.Add(DateTime.Parse(reader["NgayNhapKho"].ToString()).ToString("dd-MM-yyyy"));
                    lvDS.Items.Add(lvi);
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
                this.Alert("Lỗi", FrmThongBao.enmType.Error);
            }
        }

        #endregion

        private void FrmQLKho_Load_1(object sender, EventArgs e)
        {
            listviewLoad();
        }

        #region Nhập thêm sách vào kho
        private void btnNhap_Click(object sender, EventArgs e)
        {
            FrmAddSach ct = new FrmAddSach();
            if (activeForm != null)
                activeForm.Close();
            activeForm = ct;
            ct.TopLevel = false;
            ct.FormBorderStyle = FormBorderStyle.None;
            ct.Dock = DockStyle.Fill;
            panel2.Controls.Add(ct);
            panel2.Tag = ct;
            ct.BringToFront();
            ct.ButtonClicked += new EventHandler(ob_ButtonClicked);
            ct.Show();
        }
        #endregion

        #region Xóa sách
        private void btnSua_Click(object sender, EventArgs e)
        {

            if (lvDS.SelectedItems.Count == 0)
            {
                this.Alert("Chưa chọn sách.", FrmThongBao.enmType.Error);
            }
            else
            {
                xoaKho();
                xoaSach();
                this.Alert("Xóa thành công.", FrmThongBao.enmType.Success);
            }
        }
        string MAS;
        private void xoaSach()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Delete from Sach where MaSach='" + MAS + "'", sqlCon);
                cmd.ExecuteNonQuery();
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
                listviewLoad();
            }
            catch
            {
                this.Alert("Không được xóa.", FrmThongBao.enmType.Error);
            }

        }
        private void xoaKho()
        {

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Delete from Kho where MaSach='" + MAS + "'", sqlCon);
                cmd.ExecuteNonQuery();
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
                listviewLoad();
            }
            catch
            {
                this.Alert("Không được xóa.", FrmThongBao.enmType.Error);
            }
        }
        #endregion

        #region xuất file excel

        private void btnXuat_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "Mã sách";
                    ws.Cells[1, 2] = "Nhà cung cấp";
                    ws.Cells[1, 3] = "Giá gốc";
                    ws.Cells[1, 4] = "Số lượng";
                    ws.Cells[1, 5] = "Ngày nhập kho";
                    int i = 2;
                    foreach (ListViewItem item in lvDS.Items)
                    {
                        ws.Cells[i, 1] = item.SubItems[0].Text;
                        ws.Cells[i, 2] = item.SubItems[1].Text;
                        ws.Cells[i, 3] = item.SubItems[2].Text;
                        ws.Cells[i, 4] = item.SubItems[3].Text;
                        ws.Cells[i, 5] = item.SubItems[4].Text;
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    this.Alert("Xuất file báo cáo excel thành công.", FrmThongBao.enmType.Success);

                }
            }
        }

        #endregion

        private void lvDS_Click(object sender, EventArgs e)
        {
            MAS = lvDS.SelectedItems[0].SubItems[0].Text;
        }
        #region Double click vào 1 dòng để sửa
        private void lvDS_DoubleClick(object sender, EventArgs e)
        {
            if (lvDS.SelectedItems.Count == 1)
            {
                string select_MaSach = lvDS.SelectedItems[0].Text;
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("select s.MaSach, s.TenSach, s.TacGia, s.TheLoai, s.NamXB, s.NXB, s.GiaBan, s.MoTa , k.GiaGoc, k.NgayNhapKho, k.NhaCungCap, k.Soluong " +
                                                "from Sach s inner join Kho k " +
                                                "on s.MaSach = k.MaSach " +
                                                "where k.MaSach = '" + select_MaSach + "'", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                string MaSach = "";
                string TenSach = "";
                string TacGia = "";
                string TheLoai = "";
                string NamXuatBan = "";
                string NXB = "";
                string GiaBan = "";
                string MoTa = "";
                string GiaGoc = "";
                string NgayNhapKho = "";
                string NhaCC = "";
                string Soluong = "";
                while (reader.Read())
                {
                    MaSach = reader.GetString(0);
                    TenSach = reader.GetString(1);
                    TacGia = reader.GetString(2);
                    TheLoai = reader.GetString(3);
                    NamXuatBan = reader.GetInt32(4).ToString();
                    NXB = reader.GetString(5);
                    GiaBan = reader.GetInt32(6).ToString();
                    MoTa = reader.GetString(7);
                    GiaGoc = reader.GetInt32(8).ToString();
                    NgayNhapKho = reader.GetDateTime(9).ToString();
                    NhaCC = reader.GetString(10);
                    Soluong = reader.GetInt32(11).ToString();
                }
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
                FrmAddSach ct = new FrmAddSach(MaSach: MaSach, TenSach: TenSach, TacGia: TacGia, TheLoai: TheLoai, NamXuatBan: NamXuatBan, NXB: NXB, GiaBan: GiaBan, MoTa: MoTa, GiaGoc: GiaGoc, NgayNhapKho: NgayNhapKho, NhaCC: NhaCC, Soluong: Soluong);
                if (activeForm != null)
                    activeForm.Close();
                activeForm = ct;
                ct.TopLevel = false;
                ct.FormBorderStyle = FormBorderStyle.None;
                ct.Dock = DockStyle.Fill;
                panel2.Controls.Add(ct);
                panel2.Tag = ct;
                ct.BringToFront();
                ct.ButtonClicked += new EventHandler(ob_ButtonClicked);
                ct.Show();
            }
        }
        #endregion

        void ob_ButtonClicked(object sender, EventArgs e)
        {
            listviewLoad();
        }

        private void tangdan()
        {
            try
            {
                //mở
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Kho ORDER BY Soluong ASC", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaSach = reader.GetString(0);
                    string NhaCC = reader.GetString(1);
                    int GiaGoc = reader.GetInt32(2);
                    int Soluong = reader.GetInt32(3);

                    //hien thi len giao dien                    
                    ListViewItem lvi = new ListViewItem(MaSach);
                    lvi.SubItems.Add(NhaCC);
                    lvi.SubItems.Add(GiaGoc.ToString());
                    lvi.SubItems.Add(Soluong.ToString());
                    lvi.SubItems.Add(DateTime.Parse(reader["NgayNhapKho"].ToString()).ToString("dd-MM-yyyy"));
                    lvDS.Items.Add(lvi);
                }
                //đóng
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Lỗi", FrmThongBao.enmType.Error);
            }
        }
        private void giamdan()
        {
            try
            {
                //mở
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Kho ORDER BY Soluong DESC", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaSach = reader.GetString(0);
                    string NhaCC = reader.GetString(1);
                    int GiaGoc = reader.GetInt32(2);
                    int Soluong = reader.GetInt32(3);

                    //hien thi len giao dien                    
                    ListViewItem lvi = new ListViewItem(MaSach);
                    lvi.SubItems.Add(NhaCC);
                    lvi.SubItems.Add(GiaGoc.ToString());
                    lvi.SubItems.Add(Soluong.ToString());
                    lvi.SubItems.Add(DateTime.Parse(reader["NgayNhapKho"].ToString()).ToString("dd-MM-yyyy"));
                    lvDS.Items.Add(lvi);
                }
                //đóng
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Lỗi", FrmThongBao.enmType.Error);
            }
        }


        private void bunifuCheckBox1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuCheckBox2.Checked == true)
            {
                bunifuCheckBox2.Checked = false;
            }

            lvDS.Items.Clear();
            tangdan();
        }

        private void bunifuCheckBox2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuCheckBox1.Checked == true)
            {
                bunifuCheckBox1.Checked = false;
            }

            lvDS.Items.Clear();
            giamdan();
        }
    }
}