using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLStoreSach.FrmProgram
{
    public partial class FrmSach : Form
    {
        public FrmSach()
        {
            InitializeComponent();
        }
        static string strCon = @"Data Source=XUANHUONG;Initial Catalog=QLStoreSach;Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(strCon);

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
        public void Alert(string msg, FrmThongBao.enmType type)
        {
            FrmThongBao frm = new FrmThongBao();
            frm.showAlert(msg, type);
        }

        #region Load dữ liệu
        private void listVLoad()
        {
            lvDanhSach.Items.Clear();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Sach", sqlCon);
                //thuc thi
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaSach = reader.GetString(0);
                    string TenSach = reader.GetString(1);
                    string TacGia = reader.GetString(4);
                    string TheLoai = reader.GetString(5);
                    int NamXB = reader.GetInt32(6);
                    string NXB = reader.GetString(7);
                    int GiaBan = reader.GetInt32(8);

                    //hien thi len giao dien
                    ListViewItem lvi = new ListViewItem(MaSach);
                    lvi.SubItems.Add(TenSach);
                    lvi.SubItems.Add(TacGia);
                    lvi.SubItems.Add(TheLoai);
                    lvi.SubItems.Add(NXB);                    
                    lvi.SubItems.Add(NamXB.ToString());
                    lvi.SubItems.Add(GiaBan.ToString());
                    lvDanhSach.Items.Add(lvi);
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

        private void FrmSach_Load(object sender, EventArgs e)
        {
            listVLoad();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            listVLoad();
        }

        #region Xem ttin chi tiết
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (lvDanhSach.SelectedItems.Count == 1)
            {
                string select_MaSach = lvDanhSach.SelectedItems[0].Text;
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Sach where MaSach ='" + select_MaSach + "'", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                string TenSach = "";
                string TacGia = "";
                string TheLoai = "";
                string NXB = "";
                string GiaBan = "";
                string NamXuatBan = "";
                string MoTa = "";
                string UrlImage = "";
                string UrlImageSau = "";
                string NhanXet1 = "";
                string NhanXet2 = "";
                string NhanXet3 = "";
                string NhanXet4 = "";
                while (reader.Read())
                {
                    TenSach = reader.GetString(1);
                    TacGia = reader.GetString(4);
                    TheLoai = reader.GetString(5);
                    NamXuatBan = reader.GetInt32(6).ToString();
                    NXB = reader.GetString(7);
                    GiaBan = reader.GetInt32(8).ToString();
                    UrlImage = reader.GetString(2);
                    UrlImageSau = reader.GetString(3);
                    MoTa = reader.GetString(9);
                    NhanXet1 = reader.GetString(10);
                    NhanXet2 = reader.GetString(11);
                    NhanXet3 = reader.GetString(12);
                    NhanXet4 = reader.GetString(13);
                }
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
                OpenFrm(new ChiTietSach(TenSach: TenSach, TacGia: TacGia, TheLoai: TheLoai, NXB: NXB, GiaBan: GiaBan, NamXuatBan: NamXuatBan, MoTa: MoTa, UrlImage: UrlImage, UrlImageSau: UrlImageSau, NhanXet1: NhanXet1, NhanXet2: NhanXet2, NhanXet3: NhanXet3, NhanXet4: NhanXet4));
            }
        }
        #endregion

        #region Tìm kiếm sách
        public void TimKiem()
        {
            if (tbTimKiem.Text.Length == 0)
            {
                listVLoad();
            }
            else
            {
                lvDanhSach.Items.Clear();
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Sach where TenSach like N'%" + tbTimKiem.Text + "%' ", sqlCon);
                    //thuc thi
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
                            string MaSach = row.ItemArray.GetValue(0).ToString();
                            string TenSach = row.ItemArray.GetValue(1).ToString();
                            string TacGia = row.ItemArray.GetValue(4).ToString();
                            string TheLoai = row.ItemArray.GetValue(5).ToString();
                            string NamXB = row.ItemArray.GetValue(6).ToString();
                            string NXB = row.ItemArray.GetValue(7).ToString();
                            string GiaBan = row.ItemArray.GetValue(8).ToString();
                            //hien thi len giao dien
                            ListViewItem lv = new ListViewItem(MaSach);
                            lv.SubItems.Add(TenSach);
                            lv.SubItems.Add(TacGia);
                            lv.SubItems.Add(TheLoai);
                            lv.SubItems.Add(NamXB.ToString());
                            lv.SubItems.Add(NXB);
                            lv.SubItems.Add(GiaBan.ToString());
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
        #endregion

        private void tbTimKiem_TextChange(object sender, EventArgs e)
        {
            TimKiem();
        }
    }
}
