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
    public partial class ChiTietKH : Form
    {
        public ChiTietKH()
        {
            InitializeComponent();
        }
        static string strCon = @"Data Source=XUANHUONG;Initial Catalog=QLStoreSach;Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(strCon);

        public void Alert(string msg, FrmThongBao.enmType type)
        {
            FrmThongBao frm = new FrmThongBao();
            frm.showAlert(msg, type);
        }

        public ChiTietKH(string MaKH, string TenKH, string Diachi, string Email, string SDT)
        {
            InitializeComponent();
            string _maKH = MaKH;
            string _tenKH = TenKH;
            string _diaChi = Diachi;
            string _email = Email;
            string _sdt = SDT;

            txtMaKH.Text = _maKH;
            txtDiachi.Text = _tenKH;
            txtTenKH.Text = _diaChi;
            txtSDT.Text = _email;
            txtEmail.Text = _sdt;

        }
        public void hide()
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();

        }

        public void KhoaTB()
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtDiachi.Enabled = false;

        }

        private void ChiTietKH_Load(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length == 0)
            {
                hide();
            }
            else
            {
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
            }
            lbtb();
            KhoaTB();
        }

        private void lbtb()
        {
            label11.Text = txtMaKH.Text;
            label12.Text = txtDiachi.Text;
            label13.Text = txtTenKH.Text;
            label14.Text = txtEmail.Text;
            label15.Text = txtSDT.Text;
        }

        public void ThemKh()
        {
            if (txtMaKH.Text.Length == 0)
            {
                this.Alert("Không được để trống mã khách hàng.", FrmThongBao.enmType.Error);
            }
            else if (txtMaKH.Text.Length > 0)
            {
                bool thy = false;
                string thykh = txtMaKH.Text;
                bool kitu1 = false;
                string kit = @"@";
                bool kitu2 = false;
                string kit2 = @".";
                foreach (var item in kit)
                {
                    if (txtEmail.Text.Contains(item))
                    {
                        kitu1 = true;
                        break;
                    }
                }
                foreach (var item in kit2)
                {
                    if (txtEmail.Text.Contains(item))
                    {
                        kitu2 = true;
                        break;
                    }
                }
                if (thykh[0] == 'K' && thykh[1] == 'H')
                {
                    thy = true;
                }
                if (!thy)
                {
                    this.Alert("Mã khách hàng phải bắt đầu từ KH.", FrmThongBao.enmType.Error);
                }
                else if (txtMaKH.Text.Length == 2)
                {
                    this.Alert("Mã khách hàng phải bắt đầu từ KH +...", FrmThongBao.enmType.Error);
                }
                else if (txtMaKH.Text.Length != 5)
                {
                    this.Alert("Mã khách hàng phải có 3 số.", FrmThongBao.enmType.Error);
                }
                else if (txtDiachi.Text.Length == 0)
                {
                    this.Alert("Tên khách hàng không được để trống.", FrmThongBao.enmType.Warning);
                }
                else if (txtEmail.Text.Length == 0)
                {
                    this.Alert("Chưa nhập Email khách hàng.", FrmThongBao.enmType.Error);
                }
                else if (txtEmail.Text.Length > 0)
                {
                    if (!kitu1)
                    {
                        this.Alert("Định dạng Email không đúng.", FrmThongBao.enmType.Error);
                    }
                    else if(kitu2)
                    {
                        if (txtSDT.Text.Length == 0)
                        {
                            this.Alert("Chưa nhập số điện thoại.", FrmThongBao.enmType.Warning);
                        }
                        else if (txtSDT.Text.Length > 10 || txtSDT.Text.Length < 10)
                        {
                            this.Alert("Số điện thoại phải tối thiểu và tối đa 10 số.", FrmThongBao.enmType.Error);
                        }
                        else if (txtSDT.Text.Length == 10)
                        {
                            bool kitu = false;
                            string sozero = txtSDT.Text;
                            if (sozero[0] == '0')
                            {
                                kitu = true;
                            }
                            if (!kitu)
                            {
                                this.Alert("Số điện thoạt phải bắt đầu từ số 0", FrmThongBao.enmType.Error);
                            }
                            else
                            {
                                try
                                {
                                    if (sqlCon.State == ConnectionState.Closed)
                                        sqlCon.Open();
                                    SqlCommand cmd = new SqlCommand("Insert into KhachHang values(@MaKhachHang, @HoTen, @DiaChi, @DienThoai, @Email)", sqlCon);
                                    //thuc thi
                                    cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKH.Text);
                                    cmd.Parameters.AddWithValue("@HoTen", txtDiachi.Text);
                                    cmd.Parameters.AddWithValue("@DiaChi", txtTenKH.Text);
                                    cmd.Parameters.AddWithValue("@DienThoai", txtSDT.Text);
                                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                                    cmd.ExecuteNonQuery();
                                    this.Alert("Thêm thành công", FrmThongBao.enmType.Success);
                                    KhoaTB();
                                    if (sqlCon.State == ConnectionState.Open)
                                        sqlCon.Close();
                                }
                                catch (Exception)
                                {
                                    this.Alert("Mã khách hàng đã tồn tại.", FrmThongBao.enmType.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        this.Alert("Định dạng Email không đúng.", FrmThongBao.enmType.Error);
                    }
                }
            }
        }

        public void suaKH()
        {
            if (txtDiachi.Text.Length == 0)
            {
                this.Alert("Tên khách hàng không được để trống.", FrmThongBao.enmType.Error);
            }
            else if (txtSDT.Text.Length > 10 || txtSDT.Text.Length < 10)
            {
                this.Alert("Số điện thoại phải tối thiểu và tối đa 10 số.", FrmThongBao.enmType.Error);
            }
            else if (txtSDT.Text.Length == 10)
            {
                bool kitu = false;
                string sozero = txtSDT.Text;
                if (sozero[0] == '0')
                {
                    kitu = true;
                }
                if (!kitu)
                {
                    this.Alert("Số điện thoạt phải bắt đầu từ số 0.", FrmThongBao.enmType.Error);
                }
                else
                {
                    try
                    {
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        SqlCommand cmd = new SqlCommand("Update KhachHang set HoTen=@HoTen, DiaChi=@DiaChi, DienThoai=@DienThoai, Email=@Email where MaKhachHang=@MaKhachHang", sqlCon);
                        //thuc thi
                        cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKH.Text);
                        cmd.Parameters.AddWithValue("@HoTen", txtDiachi.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtTenKH.Text);
                        cmd.Parameters.AddWithValue("@DienThoai", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.ExecuteNonQuery();
                        this.Alert("Sửa thành công.", FrmThongBao.enmType.Success);
                        KhoaTB();
                        if (sqlCon.State == ConnectionState.Open)
                            sqlCon.Close();
                    }
                    catch
                    {
                        this.Alert("Không có gì để sửa.", FrmThongBao.enmType.Error);
                    }
                }
            }
        }

        public event EventHandler ButtonClicked;

        public void NotifyButtonClicked(EventArgs e)
        {
            if (ButtonClicked != null)
                ButtonClicked(this, e);
        }
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            NotifyButtonClicked(e);
            this.Close();
        }

        private void btnKhachHang_Click_1(object sender, EventArgs e)
        {
            txtMaKH.Text = "KH";
            txtTenKH.Clear();
            txtDiachi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtDiachi.Enabled = true;
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            if(txtMaKH.Text.Length == 0)
            {
                this.Alert("Không thể thực hiện chức năng sửa.", FrmThongBao.enmType.Warning);
            }
            else
            {
                txtMaKH.Enabled = false;
                txtTenKH.Enabled = true;
                txtSDT.Enabled = true;
                txtEmail.Enabled = true;
                txtDiachi.Enabled = true;
            }
            
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Enabled != true)
            {
                this.Alert("Mời bạn chọn chức năng.", FrmThongBao.enmType.Warning);
            }
            else if (txtMaKH.Enabled != true)
            {
                suaKH();
            }

            else
            {
                ThemKh();
            }
        }

        private void txtSDT_TextChanged_1(object sender, EventArgs e)
        {
            label15.Text = txtSDT.Text;
            if (txtSDT.Text.Length == 0)
            {
                label5.Hide();
            }
            else
            {
                label5.Show();
            }
        }

        private void txtDiachi_TextChanged_1(object sender, EventArgs e)
        {
            label12.Text = txtDiachi.Text;
            if (txtDiachi.Text.Length == 0)
            {
                label2.Hide();
            }
            else
            {
                label2.Show();
            }
        }

        private void txtTenKH_TextChanged_1(object sender, EventArgs e)
        {
            label13.Text = txtTenKH.Text;
            if (txtTenKH.Text.Length == 0)
            {
                label3.Hide();
            }
            else
            {
                label3.Show();
            }
        }

        private void txtEmail_TextChanged_1(object sender, EventArgs e)
        {
            label14.Text = txtEmail.Text;
            if (txtEmail.Text.Length == 0)
            {
                label4.Hide();
            }
            else
            {
                label4.Show();
            }
        }

        private void txtMaKH_TextChanged_1(object sender, EventArgs e)
        {
            label11.Text = txtMaKH.Text;
            if (txtMaKH.Text.Length == 0)
            {
                label1.Hide();
            }
            else
            {
                label1.Show();
            }
        }

        private void txtMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chỉ nhập số trong testbox
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chỉ nhập số trong testbox
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
