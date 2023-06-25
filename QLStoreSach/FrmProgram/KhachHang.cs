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

namespace QLStoreSach.FrmProgram
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        #region kết nối sql và show ra giao diện

        static string strCon = @"Data Source=XUANHUONG;Initial Catalog=QLStoreSach;Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(strCon);

        private void listviewLoad()
        {
            lvDanhSach.Items.Clear();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from KhachHang", sqlCon);
                //thuc thi
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaKhachHang = reader.GetString(0);
                    string HoTen = reader.GetString(1);
                    string DiaChi = reader.GetString(2);
                    string DienThoai = reader.GetString(3);
                    string Email = reader.GetString(4);

                    //hien thi len giao dien
                    ListViewItem lv = new ListViewItem(MaKhachHang);
                    lv.SubItems.Add(HoTen);
                    lv.SubItems.Add(DiaChi);
                    lv.SubItems.Add(DienThoai);
                    lv.SubItems.Add(Email);
                    lvDanhSach.Items.Add(lv);
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
        public void Alert(string msg, FrmThongBao.enmType type)
        {
            FrmThongBao frm = new FrmThongBao();
            frm.showAlert(msg, type);
        }
        #endregion

        #region Click

        private void KhachHang_Load(object sender, EventArgs e)
        {
            listviewLoad();
        }

        private Form activeForm = null;
        #endregion

        #region Thêm KH
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ChiTietKH ct = new ChiTietKH();
            if (activeForm != null)
                activeForm.Close();
            activeForm = ct;
            ct.TopLevel = false;
            ct.FormBorderStyle = FormBorderStyle.None;
            ct.Dock = DockStyle.Fill;
            panel1.Controls.Add(ct);
            panel1.Tag = ct;
            ct.BringToFront();
            ct.ButtonClicked += new EventHandler(ob_ButtonClicked);
            ct.Show();
        }
        #endregion

        #region Xóa KH
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (lvDanhSach.SelectedItems.Count == 0)
            {
                this.Alert("Chưa chọn khách hàng.", FrmThongBao.enmType.Error);
            }
            else
            {
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Delete from KhachHang where MaKhachHang='"+ lvDanhSach.SelectedItems[0].SubItems[0].Text + "'", sqlCon);
                    cmd.ExecuteNonQuery();
                    this.Alert("Xóa thành công.", FrmThongBao.enmType.Success);
                    if (sqlCon.State == ConnectionState.Open)
                        sqlCon.Close();
                    //xóa xong load lại trang
                    listviewLoad();
                }
               catch
                {
                    this.Alert("Không được xóa.", FrmThongBao.enmType.Error);
                }
            }
        }
        #endregion

        #region Tìm kiếm KH
        private void timKiemKH()
        {
            if (bunifuTextBox2.Text.Length == 0)
            {
                listviewLoad();
            }
            else
            {
                lvDanhSach.Items.Clear();
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Select * from KhachHang where HoTen like N'%" + bunifuTextBox2.Text + "%' order by MaKhachHang", sqlCon);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            ListViewItem item = new ListViewItem(row[0].ToString());
                            Console.Write(row);
                            row.ItemArray.GetValue(0);
                            string MaKhachHang = row.ItemArray.GetValue(0).ToString();
                            string HoTen = row.ItemArray.GetValue(1).ToString();
                            string DiaChi = row.ItemArray.GetValue(2).ToString();
                            string DienThoai = row.ItemArray.GetValue(3).ToString();
                            string Email = row.ItemArray.GetValue(4).ToString();
                            //hien thi len giao dien
                            ListViewItem lv = new ListViewItem(MaKhachHang);
                            lv.SubItems.Add(HoTen);
                            lv.SubItems.Add(DiaChi);
                            lv.SubItems.Add(DienThoai);
                            lv.SubItems.Add(Email);
                            lvDanhSach.Items.Add(lv);
                        }
                    }
                    if (sqlCon.State == ConnectionState.Open)
                        sqlCon.Close();
                }
                catch
                {
                    this.Alert("Lỗi không thể tìm kiếm", FrmThongBao.enmType.Error);
                }
            }
        }
        private void bunifuTextBox2_TextChange(object sender, EventArgs e)
        {
            timKiemKH();
        }

        #endregion

        #region Sửa KH
        private void lvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (lvDanhSach.SelectedItems.Count == 1)
            {
                //display the text of selected item
                string select_MaKH = lvDanhSach.SelectedItems[0].Text;

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from KhachHang where MaKhachHang ='" + select_MaKH + "'", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                string MaKH = "";
                string TenKH = "";
                string Diachi = "";
                string Email = "";
                string SDT = "";                
                while (reader.Read())
                {
                    MaKH = reader.GetString(0);
                    TenKH= reader.GetString(1);
                    Diachi = reader.GetString(2);
                    Email = reader.GetString(3);
                    SDT = reader.GetString(4);                    
                }
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
                ChiTietKH ct = new ChiTietKH(TenKH: TenKH, MaKH: MaKH, Diachi: Diachi, Email: Email, SDT: SDT);
                if (activeForm != null)
                    activeForm.Close();
                activeForm = ct;
                ct.TopLevel = false;
                ct.FormBorderStyle = FormBorderStyle.None;
                ct.Dock = DockStyle.Fill;
                panel1.Controls.Add(ct);
                panel1.Tag = ct;
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


    }
}