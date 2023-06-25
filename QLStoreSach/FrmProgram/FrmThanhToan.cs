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
    public partial class FrmThanhToan : Form
    {
        public FrmThanhToan()
        {
            InitializeComponent();
        }
        static string strCon = @"Data Source=XUANHUONG;Initial Catalog=QLStoreSach;Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(strCon);


        //load ra thông tin khách hàng từ MaKH
        string idKh;
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
                    if (reader.GetString(0) == idKh)
                    {
                        string Makh = reader.GetString(0);
                        string Tenkh = reader.GetString(1);
                        string Diachi = reader.GetString(2);
                        string Sdt = reader.GetString(3);
                        string Email = reader.GetString(4);

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
        //gọi ra frm thông báo
        public void Alert(string msg, FrmThongBao.enmType type)
        {
            FrmThongBao frm = new FrmThongBao();
            frm.showAlert(msg, type);
        }

        //back
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            lvXemTruoc.Items.Clear();
            this.Close();
            NotifyButtonClicked(e);

        }

        //truyền load lại mã hóa đơn vào nút back
        public event EventHandler ButtonClicked;
        public void NotifyButtonClicked(EventArgs e)
        {
            if (ButtonClicked != null)
                ButtonClicked(this, e);
        }

        //truyền từ frm bán sách qua
        string mah;
        public FrmThanhToan(string MaKH, List<ListViewItem> t, string mahd, string tongtien) : this()
        {
            mah = "HD" + mahd;
            lbTongTien.Text = tongtien;
            lbMaHoaDon.Text = mahd;
            lbMaKH.Text = MaKH;
            idKh = MaKH;
            foreach( ListViewItem t1 in t)
            {
                ListViewItem li = new ListViewItem(t1.Text);
                li.SubItems.Add(t1.SubItems[1].Text);
                li.SubItems.Add(t1.SubItems[2].Text);
                li.SubItems.Add(t1.SubItems[3].Text);
                li.SubItems.Add(t1.SubItems[4].Text);
                li.SubItems.Add(t1.SubItems[5].Text);
                lvXemTruoc.Items.Add(li);
            }
        }

        //form load
        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            loadKH();
            lbNgayLap.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        //btn thanh toán
        private void bunifuButton4_Click(object sender, EventArgs e)
        {            
            ktSlKho();
            Sluong();
        }

        //thêm vào chi tiết hóa đơn
        private void themcthd()
        {
            try
            {
                foreach (ListViewItem li in lvXemTruoc.Items)
                {
                    string Mahoadon = "HD" + lbMaHoaDon.Text;
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Insert into ChiTietHoaDon values(@MaHoaDon, @MaSach, @SoLuong, @DonGia)", sqlCon);
                    //thuc thi
                    cmd.Parameters.AddWithValue("@MaHoaDon", Mahoadon);
                    cmd.Parameters.AddWithValue("@MaSach", li.SubItems[5].Text);
                    cmd.Parameters.AddWithValue("@SoLuong", li.SubItems[2].Text);
                    cmd.Parameters.AddWithValue("@DonGia", li.SubItems[3].Text);
                    cmd.ExecuteNonQuery();
                    if (sqlCon.State == ConnectionState.Open)
                        sqlCon.Close();
                }
            }
            catch { }
        }

        //thêm vào hóa đơn
        private void themHD()
        {
            try
            {
                string Mahoadon = "HD"+lbMaHoaDon.Text;
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Insert into HoaDon values(@MaHoaDon, @MaKhachHang, @NgayLap, @TongTien)", sqlCon);
                cmd.Parameters.AddWithValue("@MaHoaDon", Mahoadon);
                cmd.Parameters.AddWithValue("@MaKhachHang", idKh);
                cmd.Parameters.AddWithValue("@NgayLap", lbNgayLap.Text);
                cmd.Parameters.AddWithValue("@TongTien", lbTongTien.Text);
                cmd.ExecuteNonQuery();
                this.Alert("Đã thanh toán.", FrmThongBao.enmType.Success);
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Hóa đơn này đã thanh toán.", FrmThongBao.enmType.Success);
            }
        }


        // kiểm tra số lượng còn trong kho
        private void ktSlKho()
        {
            foreach (ListViewItem lvi in lvXemTruoc.Items)
            {
                string Sol = lvi.SubItems[5].Text;
                int so = Convert.ToInt32(lvi.SubItems[2].Text);
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("select Soluong = (Soluong - '" + so + "') FROM Kho where MaSach ='"+ Sol +"'", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    int SLSachKho = reader.GetInt32(0);
                    slKho = SLSachKho;
                }
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }
        int slKho;
        //cập nhật số lượng bên kho
        private void Sluong()
        {
            if(slKho >= 0)
            {
                themHD();
                themcthd();
                try
                {
                    foreach (ListViewItem lvi in lvXemTruoc.Items)
                    {
                        string Sol = lvi.SubItems[5].Text;
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        SqlCommand cmd = new SqlCommand("select ChiTietHoaDon.MaHoaDon " +
                                                        "from ChiTietHoaDon " +
                                                        "UPDATE Kho SET Soluong = (k.Soluong - '" + lvi.SubItems[2].Text + "') " +
                                                        "FROM Kho k INNER JOIN ChiTietHoaDon h " +
                                                        "ON k.MaSach = '" + Sol + "' " +
                                                        "where MaHoaDon = '" + mah + "'", sqlCon);
                        cmd.ExecuteNonQuery();
                        if (sqlCon.State == ConnectionState.Open)
                            sqlCon.Close();                        
                    }
                }
                catch
                {
                    this.Alert("Lỗi cập nhật số lượng rồi hic.", FrmThongBao.enmType.Success);
                }
            }
            else
            {
                this.Alert("Sách trog kho không đủ để bán.", FrmThongBao.enmType.Warning);
            }
        }
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(label4.Text.Trim(), new Font("Bauhaus", 20, FontStyle.Bold), Brushes.Black, new Point(340, 20));
            e.Graphics.DrawString("Số: " + lbMaHoaDon.Text.Trim(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(350, 55));
            e.Graphics.DrawString("Ngày: " + DateTime.Now, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, 70));
            e.Graphics.DrawString("Khách hàng: " + lbTenKH.Text.Trim(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, 100));
            e.Graphics.DrawString("Địa chỉ KH: " + lbDiaChi.Text.Trim(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, 130));
            e.Graphics.DrawString("SĐT: " + lbSdt.Text.Trim(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, 160));
            e.Graphics.DrawString("Email KH: " + lbEmail.Text.Trim(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, 160));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------",
                                    new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, 180));
            e.Graphics.DrawString("Tên sách", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(30, 200));
            e.Graphics.DrawString("Số lượng", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(370, 200));
            e.Graphics.DrawString("Đơn giá", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(550, 200));
            e.Graphics.DrawString("Thành tiền", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(670, 200));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------",
                                    new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, 220));
            int yPos = 240;

            foreach (ListViewItem i in lvXemTruoc.Items)
            {
                e.Graphics.DrawString(i.SubItems[2].Text.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(390, yPos));
                e.Graphics.DrawString(i.SubItems[3].Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(560, yPos));
                e.Graphics.DrawString(i.SubItems[4].Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(690, yPos));

                string tmp = i.SubItems[1].Text;

                while (tmp.Length > 34)
                {
                    e.Graphics.DrawString(tmp.Substring(0, 34), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                    tmp = tmp.Remove(0, 34);
                    yPos += 30;
                }
                if (tmp.Length > 0)
                {
                    e.Graphics.DrawString(tmp.Substring(0, tmp.Length), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                    yPos += 30;
                }
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------",
                                    new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
            yPos += 30;
            e.Graphics.DrawString("Tổng tiền", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(670, yPos));
            yPos += 30;
            e.Graphics.DrawString(lbTongTien.Text.Trim() + " Đ", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(670, yPos)); 
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }

        private void bunifuBtnPrinPreview_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

    }
}
