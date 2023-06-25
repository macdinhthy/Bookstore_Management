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
    public partial class ChiTietDoanhThu : Form
    {
        public ChiTietDoanhThu()
        {
            InitializeComponent();
        }
        static string strCon = @"Data Source=XUANHUONG;Initial Catalog=QLStoreSach;Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(strCon);

        //truyền dữ liệu từ danh thu qua
        public ChiTietDoanhThu(string MaHD, string NgayL, string MaKH, string TongT)
        {
            InitializeComponent();
            IDHD = MaHD;
            DateL = NgayL;
            IDKH = MaKH;
            TongTien = TongT;
            lbMaHD.Text = MaHD;

        }
        string TongTien;
        string IDKH;
        string IDHD;
        string DateL;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChiTietDoanhThu_Load(object sender, EventArgs e)
        {
            lbNgayLap.Text = DateL;
            lbTongTien.Text = TongTien;
            loadKH();
            loadlvi();

        }

        //load dữ liệu ra mà hình
        private void loadKH()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from KhachHang", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0) == IDKH)
                    {
                        string Makh = reader.GetString(0);
                        string Tenkh = reader.GetString(1);
                        string Diachi = reader.GetString(2);
                        string Sdt = reader.GetString(3);
                        string Email = reader.GetString(4);

                        lbMaKH.Text = Makh;
                        lbTenKH.Text = Tenkh;
                        lbDiaChi.Text = Diachi;
                        lbEmail.Text = Email;
                        lbSdt.Text = Sdt;
                    }
                }
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("lỗi rồi hic.", FrmThongBao.enmType.Error);
            }
        }
        public void Alert(string msg, FrmThongBao.enmType type)
        {
            FrmThongBao frm = new FrmThongBao();
            frm.showAlert(msg, type);
        }
        //  load sách đã bán
        private void loadlvi()
        {
            try
            {

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("select S.TenSach, Ct.SoLuong, Ct.DonGia, SoLuong*DonGia [ThanhTien] ,Ct.MaHoaDon, Ct.MaSach, S.MaSach " +
                                                "from ChiTietHoaDon Ct inner join Sach S " +
                                                "on Ct.MaSach = s.MaSach " +
                                                "where MaHoaDon='" + IDHD + "'", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tenS = reader.GetString(0);
                    int Soluong = reader.GetInt32(1);
                    int DonGia = reader.GetInt32(2);
                    int Ttin = reader.GetInt32(3);
                    // load lên listview
                    string[] row = { (lvXemTruoc.Items.Count + 1).ToString(), tenS, Soluong.ToString(), DonGia.ToString(), Ttin.ToString() };
                    var listViewItem = new ListViewItem(row);
                    lvXemTruoc.Items.Add(listViewItem);

                }
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("lỗi rồi hic.", FrmThongBao.enmType.Error);
            }
        }

        

        
    }
}
