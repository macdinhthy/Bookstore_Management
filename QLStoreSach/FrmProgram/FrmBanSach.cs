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
    public partial class FrmBanSach : Form
    {
        public FrmBanSach()
        {
            InitializeComponent();
        }

        static string strCon = @"Data Source=XUANHUONG;Initial Catalog=QLStoreSach;Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(strCon);

        #region frm load
        public void Alert(string msg, FrmThongBao.enmType type)
        {
            FrmThongBao frm = new FrmThongBao();
            frm.showAlert(msg, type);
        }
        private Form activeForm = null;
        public void OpenFrm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void listviewLoad()
        {
            lvSach.Items.Clear();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Sach ORDER BY TenSach ASC", sqlCon);
                //thuc thi
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MaSach = reader.GetString(0);
                    string MaKhachHang = reader.GetString(1);
                    int GiaBan = reader.GetInt32(8);

                    //hien thi len giao dien
                    ListViewItem lv = new ListViewItem(MaKhachHang);
                    lv.SubItems.Add(GiaBan.ToString());
                    lv.SubItems.Add(MaSach);
                    lvSach.Items.Add(lv);
                }
                //đóng
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Error", FrmThongBao.enmType.Error);
            }
        }
        private void FrmDoanhThu_Load(object sender, EventArgs e)
        {
            resetmahd();
            label6.Hide();
            label3.Hide();
            label5.Hide();
            label7.Hide();
            label8.Hide();
            listviewLoad();
            txtTenKH.Text = "KH";
            int[] b = new int[10];
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                b[i] = rd.Next(123123, 999999);
                lbMaHoaDon.Text = string.Format("{0}", Convert.ToString(b[i]));
            }
        }
        #endregion

        #region chỉ được nhập số
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        #endregion

        #region tìm kiếm, tính tổng, thêm lv

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }
        public void TimKiem()
        {
            if (tbTimKiem.Text.Length == 0)
            {
                listviewLoad();
            }
            else
            {
                lvSach.Items.Clear();
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Sach where TenSach like N'%" + tbTimKiem.Text + "%' ORDER BY TenSach ASC", sqlCon);
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
                            string Gia = row.ItemArray.GetValue(8).ToString();
                            //hien thi len giao dien
                            ListViewItem lv = new ListViewItem(TenSach);
                            lv.SubItems.Add(Gia);
                            lv.SubItems.Add(MaSach);
                            lvSach.Items.Add(lv);
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

        private void tongtien()
        {
            int total = 0;
            foreach (ListViewItem item in lvXemTruoc.Items)
            {
                total += Convert.ToInt32(item.SubItems[4].Text);
            }
            lbTongTien.Text = total.ToString();
        }
        List<ListViewItem> sp = new List<ListViewItem>();

        private void ThemLv()
        {
            string[] row = { (lvXemTruoc.Items.Count + 1).ToString(), txtTenSach.Text, txtSoLuong.Text, txtGiaBan.Text, txtTongTien.Text, IDSach };
            var listViewItem = new ListViewItem(row);
            lvXemTruoc.Items.Add(listViewItem);
            tongtien();
            sp.Add(listViewItem);
        }

        #endregion

        #region thêm sách
        private void btnThemDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                bool f = false;
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string tenkh = txtTenKH.Text;
                SqlCommand cmd = new SqlCommand("Select * from KhachHang where MaKhachHang= '" + tenkh + "'", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    f = true;
                }
                else
                {
                    OpenFrm(new ChiTietKH());
                    this.Alert("Chưa có thông tin khách hàng.", FrmThongBao.enmType.Info);
                }
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

                if (f == true)
                {
                    if(txtTenSach.Text.Length == 0)
                    {
                        this.Alert("Chưa nhập tên sách.", FrmThongBao.enmType.Warning);
                    }
                    else if (txtSoLuong.Text.Length == 0)
                    {
                        this.Alert("Chưa điền số lượng sách.", FrmThongBao.enmType.Warning);
                    }
                    else if( txtSoLuong.Text == "0")
                    {
                        this.Alert("Số lượng sách phải khác 0.", FrmThongBao.enmType.Warning);
                    }
                    else
                    {
                        if (lvXemTruoc.Items.Count <= 0)
                        {
                            ThemLv();
                            this.Alert("Thêm thành công.", FrmThongBao.enmType.Success);
                        }
                        else
                        {
                            bool t = false;
                            foreach (ListViewItem kts in lvXemTruoc.Items)
                            {
                                if (txtTenSach.Text == kts.SubItems[1].Text)
                                {
                                    t = true;
                                    // cộng số lượng
                                    int sl = Convert.ToInt32(kts.SubItems[2].Text);
                                    int sl2 = Convert.ToInt32(txtSoLuong.Text);
                                    int tong = (sl + sl2);
                                    kts.SubItems[2].Text = tong.ToString();
                                    //cộng thành tiền
                                    int tt = Convert.ToInt32(kts.SubItems[4].Text);
                                    int tt2 = Convert.ToInt32(txtTongTien.Text);
                                    int tong2 = (tt + tt2);
                                    kts.SubItems[4].Text = tong2.ToString();
                                    tongtien();
                                    break;
                                }
                            }
                            foreach (ListViewItem sp1 in sp)
                            {
                                if (txtTenSach.Text == sp1.SubItems[1].Text)
                                {
                                    // cộng số lượng
                                    int sl = Convert.ToInt32(sp1.SubItems[2].Text);
                                    int sl2 = Convert.ToInt32(txtSoLuong.Text);
                                    sl -= sl2;
                                    int tong = (sl + sl2 );
                                    sp1.SubItems[2].Text = tong.ToString();
                                    //cộng thành tiền
                                    int tt = Convert.ToInt32(sp1.SubItems[4].Text);
                                    int tt2 = Convert.ToInt32(txtTongTien.Text);
                                    tt -= tt2;
                                    int tong2 = (tt + tt2);
                                    sp1.SubItems[4].Text = tong2.ToString();                                    
                                    break;
                                }
                            }
                            if (!t)
                            {
                                ThemLv();
                                this.Alert("Thêm thành công.", FrmThongBao.enmType.Success);
                            }
                        }
                    }
                }
            }
            catch
            {
                this.Alert("Lỗi", FrmThongBao.enmType.Error);
            }
        }

        #endregion

        #region Show hide
        private void txtTenSach_TextChange(object sender, EventArgs e)
        {
            if (txtTenSach.Text.Length == 0)
            {
                label7.Hide();
            }
            else
            {
                label7.Show();
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaBan.Text.Length == 0)
            {
                label3.Hide();
            }
            else
            {
                label3.Show();
            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Length == 0)
            {
                label6.Hide();
            }
            else
            {
                label6.Show();
            }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            if (txtTongTien.Text.Length == 0)
            {
                label8.Hide();
            }
            else
            {
                label8.Show();
            }
        }
        #endregion

        #region click & textChanged
        string IDSach;

        public EventHandler ButtonClicked1 { get; internal set; }

        private void lvSach_Click(object sender, EventArgs e)
        {
            txtTenSach.Text = lvSach.SelectedItems[0].SubItems[0].Text;
            txtGiaBan.Text = lvSach.SelectedItems[0].SubItems[1].Text;
            IDSach = lvSach.SelectedItems[0].SubItems[2].Text;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length == 0)
            {
                label5.Hide();
            }
            else
            {
                label5.Show();
            }
            if (txtGiaBan.Text.Length == 0)
            {

            }
            else
            {
                if (txtSoLuong.Text.Length != 0)
                {
                    int sl = Convert.ToInt32(txtSoLuong.Text);
                    int gia = Convert.ToInt32(txtGiaBan.Text);
                    int tong = (sl * gia);
                    txtTongTien.Text = tong.ToString();
                }
                else
                {
                    txtTongTien.Clear();
                }
            }

        }

        //sl * giá
        private void txtGiaBan_TextChange(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length > 0)
            {
                double sl = Convert.ToDouble(txtSoLuong.Text);
                int gia = Convert.ToInt32(txtGiaBan.Text);
                double tong = (sl * gia);
                txtTongTien.Text = tong.ToString();
            }
            else
            {
                txtTongTien.Clear();
            }
        }
        #endregion

        #region xóa
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvXemTruoc.Items.Count; i++)
            {
                if (lvXemTruoc.Items[i].Selected)
                {
                    ListViewItem tpm = new ListViewItem(); 
                    foreach (ListViewItem li in sp )
                    {
                        if(li.SubItems[1].Text == lvXemTruoc.Items[i].SubItems[1].Text)
                        {
                            tpm = li;
                        }
                    }
                    sp.Remove(tpm);
                    lvXemTruoc.Items.RemoveAt(i);
                    this.Alert("Đã xóa.", FrmThongBao.enmType.Success);
                }
                if (lvXemTruoc.Items.Count != i)
                {
                    lvXemTruoc.Items[i].Text = (i + 1).ToString();
                }
            }
            tongtien();
        }

        private void resetmahd()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            string mahd = lbMaHoaDon.Text;
            SqlCommand cmd = new SqlCommand("Select * from HoaDon where MaHoaDon = '" + mahd + "'", sqlCon);
            //thuc thi
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read() == true)
            {
                int[] b = new int[10];
                Random rd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    b[i] = rd.Next(123123, 999999);
                    lbMaHoaDon.Text = string.Format("{0}", Convert.ToString(b[i]));
                }
            }
            //đóng
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }
        #endregion

        #region lưu sách vào hóa đơn
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (lvXemTruoc.Items.Count <= 0)
            {
                this.Alert("Chưa có sách nào để lưu", FrmThongBao.enmType.Warning);                
            }
            else
            {
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    string mahd = lbMaHoaDon.Text;
                    SqlCommand cmd = new SqlCommand("Select * from HoaDon where MaHoaDon = '" + mahd + "'", sqlCon);
                    //thuc thi
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() != true)
                    {
                        FrmThanhToan hd = new FrmThanhToan(txtTenKH.Text, sp, lbMaHoaDon.Text, lbTongTien.Text);
                        if (activeForm != null)
                            activeForm.Close();
                        activeForm = hd;
                        hd.TopLevel = false;
                        hd.FormBorderStyle = FormBorderStyle.None;
                        hd.Dock = DockStyle.Fill;
                        panelMain.Controls.Add(hd);
                        panelMain.Tag = hd;
                        hd.BringToFront();
                        hd.ButtonClicked += new EventHandler(ob_ButtonClicked);
                        hd.Show();
                    }
                    else
                    {
                        int[] b = new int[10];
                        Random rd = new Random();
                        for (int i = 0; i < 10; i++)
                        {
                            b[i] = rd.Next(123123, 999999);
                            lbMaHoaDon.Text = string.Format("{0}", Convert.ToString(b[i]));
                        }
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
        }
        #endregion

        //random mã hóa đơn
        void ob_ButtonClicked(object sender, EventArgs e)
        {
            int[] b = new int[10];
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                b[i] = rd.Next(123123, 999999);
                lbMaHoaDon.Text = string.Format("{0}", Convert.ToString(b[i]));
            }
        }
    }
}