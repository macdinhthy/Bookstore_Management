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
    public partial class FrmAddSach : Form
    {
        public FrmAddSach()
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

        public FrmAddSach(string MaSach, string TenSach, string NhaCC, string Soluong, string NgayNhapKho, string TacGia, string TheLoai, string NXB, string GiaBan,string GiaGoc, string NamXuatBan, string MoTa)
        {
            InitializeComponent();
            string _tenSach = TenSach;
            string _tacGia = TacGia;
            string _theLoai = TheLoai;
            string _nXB = NXB;
            //string _giaBan = GiaBan;
            string _namXuatBan = NamXuatBan;
            string _moTa = MoTa;
            string _maS = MaSach;
            string _NCC = NhaCC;
            string _NgayNK = NgayNhapKho;
            string _giaG = GiaGoc;
            string _Sol = Soluong;

            txtMaSach.Text = _maS;
            txtTenSach.Text = _tenSach;
            txtTacGia.Text = _tacGia;
            txtTheLoai.Text = _theLoai;
            txtNamXB.Text = _namXuatBan;
            txtNXB.Text = _nXB;
            //txtGiaBan.Text = _giaBan;
            txtMoTa.Text = _moTa;
            txtNCC.Text = _NCC;
            txtNgayNhap.Text = _NgayNK;
            txtSL.Text = _Sol;
            txtGiaGoc.Text = _giaG;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            NotifyButtonClicked(e);
            this.Close();
        }

        public event EventHandler ButtonClicked;

        public void NotifyButtonClicked(EventArgs e)
        {
            if (ButtonClicked != null)
                ButtonClicked(this, e);
        }

        #region HideShowlb
        private void txtNCC_TextChanged(object sender, EventArgs e)
        { 
            if(txtNCC.Text.Length != 0)
            {
                lbNhaCC.Show();
            }
            else
            {
                lbNhaCC.Hide();
            }
        }

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
            if (txtTenSach.Text.Length != 0)
            {
                lbTenS.Show();
            }
            else
            {
                lbTenS.Hide();
            }
        }

        private void txtTacGia_TextChanged(object sender, EventArgs e)
        {
            if (txtTacGia.Text.Length != 0)
            {
                lbTacG.Show();
            }
            else
            {
                lbTacG.Hide();
            }
        }

        private void txtTheLoai_TextChanged(object sender, EventArgs e)
        {
            if (txtTheLoai.Text.Length != 0)
            {
                lbTheL.Show();
            }
            else
            {
                lbTheL.Hide();
            }
        }

        private void txtNXB_TextChanged(object sender, EventArgs e)
        {
            if (txtNXB.Text.Length != 0)
            {
                lbNhaXB.Show();
            }
            else
            {
                lbNhaXB.Hide();
            }
        }

        private void txtNamXB_TextChanged(object sender, EventArgs e)
        {
            if (txtNamXB.Text.Length != 0)
            {
                lbNamSB.Show();
            }
            else
            {
                lbNamSB.Hide();
            }
        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {
            if (txtMoTa.Text.Length != 0)
            {
                lbMoT.Show();
            }
            else
            {
                lbMoT.Hide();
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaBan.Text.Length != 0)
            {
                lbGiaB.Show();
            }
            else
            {
                lbGiaB.Hide();
            }
        }

        private void txtNgayNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtNgayNhap.Text.Length != 0)
            {
                lbNgayN.Show();
            }
            else
            {
                lbNgayN.Hide();
            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            if (txtSL.Text.Length != 0)
            {
                lbSoL.Show();
            }
            else
            {
                lbSoL.Hide();
            }
        }

        private void txtGiaGoc_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaGoc.Text.Length != 0)
            {
                lbGiaG.Show();
            }
            else
            {
                lbGiaG.Hide();
            }
            GiaBan();
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            if (txtMaSach.Text.Length != 0)
            {
                lbMaS.Show();
            }
            else
            {
                lbMaS.Hide();
            }
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if(txtTenSach.Text.Length== 0)
            {
                lbGiaB.Hide();
                lbGiaG.Hide();
                lbMaS.Hide();
                lbMoT.Hide();
                lbNamSB.Hide();
                lbNamSB.Hide();
                lbNhaCC.Hide();
                lbNhaXB.Hide();
                lbSoL.Hide();
                lbTacG.Hide();
                lbTenS.Hide();
                lbTheL.Hide();
                txtMaSach.Text = "MS";
                
            }
            GiaBan();
            DateTime d1 = DateTime.Now;
            txtNgayNhap.Text = d1.ToString("yyyy-MM-dd");
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtTheLoai.Enabled = false;
            txtTacGia.Enabled = false;
            txtNXB.Enabled = false;
            txtNCC.Enabled = false;
            txtSL.Enabled = false;
            txtNamXB.Enabled = false;
            txtGiaGoc.Enabled = false;
            txtMoTa.Enabled = false;
        }

        private void GiaBan()
        {
            if (txtGiaGoc.Text.Length > 0)
            {
                double Giagoc = Convert.ToDouble(txtGiaGoc.Text);
                double Giab = (Giagoc + (Giagoc*10/100));
                txtGiaBan.Text = Giab.ToString();
            }
            else
            {
                txtGiaBan.Clear();
            }
        }

        private void btnLuuSach_Click(object sender, EventArgs e)
        {
            if(txtTenSach.Enabled != true)
            {
                this.Alert("Chưa chọn chức năng.", FrmThongBao.enmType.Success);
            }
            else if(txtMaSach.Enabled != true)
            {
                suaKho();                
            }
            else
            {
                Sach();                 
            }

        }

        private void Kho()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Kho VALUES(@MaSach, @NhaCungCap, @GiaGoc, @Soluong, @NgayNhapKho)", sqlCon);
                //thuc thi
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@NhaCungCap", txtNCC.Text);
                cmd.Parameters.AddWithValue("@GiaGoc", txtGiaGoc.Text);
                cmd.Parameters.AddWithValue("@Soluong", txtSL.Text);
                cmd.Parameters.AddWithValue("@NgayNhapKho", txtNgayNhap.Text);
                cmd.ExecuteNonQuery();
                this.Alert("Thêm thành công.", FrmThongBao.enmType.Success);
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Mã sách đã tồn tại.", FrmThongBao.enmType.Error);
            }
                
            
        }

        private void Sach()
        {
            if (txtMaSach.Text.Length == 0)
            {
                this.Alert("Không được để trống mã sách.", FrmThongBao.enmType.Error);
            }
            else if (txtMaSach.Text.Length > 0)
            {
                bool m = false;
                string mkho = txtMaSach.Text;
                if (mkho[0] == 'M' && mkho[1] == 'S')
                {
                    m = true;
                }
                if (!m)
                {
                    this.Alert("Mã sách phải bắt đầu từ MS.", FrmThongBao.enmType.Warning);
                }
                else if (txtTenSach.Text.Length == 0)
                {
                    this.Alert("Chưa nhập tên sách.", FrmThongBao.enmType.Error);
                }
                else if (txtTacGia.Text.Length == 0)
                {
                    this.Alert("Chưa nhập tác giả.", FrmThongBao.enmType.Error);
                }
                else if (txtNamXB.Text.Length == 0)
                {
                    this.Alert("Chưa nhập năm xuất bản.", FrmThongBao.enmType.Error);
                }
                else if (txtNXB.Text.Length == 0)
                {
                    this.Alert("Chưa nhập nhà xuất bản.", FrmThongBao.enmType.Error);
                }
                else if (txtMaSach.Text.Length <= 2)
                {
                    this.Alert("Mã sách phải bắt đầu từ MS + ...", FrmThongBao.enmType.Warning);
                }
                else if (txtMaSach.Text.Length != 5)
                {
                    this.Alert("Mã sách phải có 5 kí tự.", FrmThongBao.enmType.Warning);
                }
                else if (txtSL.Text.Length == 0)
                {
                    this.Alert("Chưa nhập số lượng.", FrmThongBao.enmType.Error);
                }
                else if (txtSL.Text.Length > 0)
                {
                    int Sl;
                    Sl = Convert.ToInt32(txtSL.Text);
                    if (Sl < 100)
                    {
                        this.Alert("Số lượng phải lớn hơn 100", FrmThongBao.enmType.Error);
                    }
                    else if (txtSL.Text.Length == 0)
                    {
                        this.Alert("Chưa nhập số lượng", FrmThongBao.enmType.Error);
                    }
                    else if (txtNCC.Text.Length == 0)
                    {
                        this.Alert("Chưa nhập nhà cung cấp.", FrmThongBao.enmType.Error);
                    }
                    else if (txtGiaGoc.Text.Length == 0)
                    {
                        this.Alert("Chưa nhập giá gốc.", FrmThongBao.enmType.Error);
                    }
                    else if (txtGiaGoc.Text == "0")
                    {
                        this.Alert("Giá của sách phải khác 0.", FrmThongBao.enmType.Warning);
                    }
                    else
                    {
                        try
                        {
                            if (sqlCon.State == ConnectionState.Closed)
                                sqlCon.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO Sach(MaSach, TenSach, TacGia, TheLoai, NamXB, NXB, GiaBan, MoTa) VALUES(@MaSach, @TenSach, @TacGia, @TheLoai, @NamXB, @NXB, @GiaBan, @MoTa)", sqlCon);
                            //thuc thi
                            cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                            cmd.Parameters.AddWithValue("@TenSach", txtNCC.Text);
                            cmd.Parameters.AddWithValue("@TacGia", txtTacGia.Text);
                            cmd.Parameters.AddWithValue("@TheLoai", txtTheLoai.Text);
                            cmd.Parameters.AddWithValue("@NamXB", txtNamXB.Text);
                            cmd.Parameters.AddWithValue("@NXB", txtNXB.Text);
                            cmd.Parameters.AddWithValue("@GiaBan", txtGiaBan.Text);
                            cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                            cmd.ExecuteNonQuery();
                            if (sqlCon.State == ConnectionState.Open)
                                sqlCon.Close();
                        }
                        catch
                        {
                            //this.Alert("Mã sách đã tồn tại.", FrmThongBao.enmType.Error);
                        }
                        Kho();
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = true;
            txtTheLoai.Enabled = true;
            txtTacGia.Enabled = true;
            txtNXB.Enabled = true;
            txtNCC.Enabled = true;
            txtSL.Enabled = true;
            txtNamXB.Enabled = true;
            txtGiaGoc.Enabled = true;
            txtMoTa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "MS";
            txtTenSach.Clear();
            txtTheLoai.Clear();
            txtTacGia.Clear();
            txtNamXB.Clear();
            txtNXB.Clear();
            txtNCC.Clear();
            txtSL.Clear();
            txtGiaBan.Clear();
            txtGiaGoc.Clear();
            txtMoTa.Clear();
            txtMaSach.Enabled = true;
            txtTenSach.Enabled = true;
            txtTheLoai.Enabled = true;
            txtTacGia.Enabled = true;
            txtNXB.Enabled = true;
            txtNCC.Enabled = true;
            txtSL.Enabled = true;
            txtNamXB.Enabled = true;
            txtGiaGoc.Enabled = true;
            txtMoTa.Enabled = true;
        }

        private void suaSach()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Sach SET TenSach=@TenSach, TacGia=@TacGia, TheLoai=@TheLoai, NamXB=@NamXB, NXB=@NXB, GiaBan=@GiaBan, Mota=@MoTa WHERE MaSach=@MaSach", sqlCon);
                //thuc thi
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                cmd.Parameters.AddWithValue("@TacGia", txtTacGia.Text);
                cmd.Parameters.AddWithValue("@TheLoai", txtTheLoai.Text);
                cmd.Parameters.AddWithValue("@NamXB", txtNamXB.Text);
                cmd.Parameters.AddWithValue("@NXB", txtNXB.Text);
                cmd.Parameters.AddWithValue("@GiaBan", txtGiaBan.Text);
                cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                cmd.ExecuteNonQuery();
                this.Alert("Sửa thành công.", FrmThongBao.enmType.Success);
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Không thể sửa .", FrmThongBao.enmType.Error);
            }
        }

        private void suaKho()
        {
            if (txtTenSach.Text.Length == 0)
            {
                this.Alert("Chưa nhập tên sách.", FrmThongBao.enmType.Error);
            }
            else if (txtTacGia.Text.Length == 0)
            {
                this.Alert("Chưa nhập tác giả.", FrmThongBao.enmType.Error);
            }
            else if (txtTheLoai.Text.Length == 0)
            {
                this.Alert("Chưa nhập thể loại.", FrmThongBao.enmType.Error);
            }
            else if (txtNamXB.Text.Length == 0)
            {
                this.Alert("Chưa nhập năm xuất bản.", FrmThongBao.enmType.Error);
            }
            else if (txtNXB.Text.Length == 0)
            {
                this.Alert("Chưa nhập nhà xuất bản.", FrmThongBao.enmType.Error);
            }
            else if (txtSL.Text.Length == 0)
            {
                this.Alert("Chưa nhập số lượng.", FrmThongBao.enmType.Error);
            }
            else if (txtSL.Text == "0")
            {
                this.Alert("Số lượng sách phải khác 0.", FrmThongBao.enmType.Warning);
            }
            else if (txtSL.Text.Length > 0)
            {
                int Sl;
                Sl = Convert.ToInt32(txtSL.Text);
                if (Sl < 100)
                {
                    this.Alert("Số lượng phải lớn hơn 100", FrmThongBao.enmType.Warning);
                }
                else if (txtNCC.Text.Length == 0)
                {
                    this.Alert("Chưa nhập nhà cung cấp.", FrmThongBao.enmType.Error);
                }
                else if (txtGiaGoc.Text.Length == 0)
                {
                    this.Alert("Chưa nhập giá gốc.", FrmThongBao.enmType.Error);
                }
                else if (txtGiaGoc.Text == "0")
                {
                    this.Alert("Giá của sách phải khác 0.", FrmThongBao.enmType.Warning);
                }
                else if (txtGiaGoc.Text.Length < 4)
                {
                    this.Alert("Định dạng giá như trên tờ tiền.", FrmThongBao.enmType.Warning);
                }
                else
                {
                    try
                    {
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Kho SET  NhaCungCap=@NhaCungCap, GiaGoc=@GiaGoc, Soluong=@Soluong, NgayNhapKho=@NgayNhapKho WHERE MaSach=@MaSach", sqlCon);
                        //thuc thi
                        cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                        cmd.Parameters.AddWithValue("@NhaCungCap", txtNCC.Text);
                        cmd.Parameters.AddWithValue("@GiaGoc", txtGiaGoc.Text);
                        cmd.Parameters.AddWithValue("@Soluong", txtSL.Text);
                        cmd.Parameters.AddWithValue("@NgayNhapKho", txtNgayNhap.Text);
                        cmd.ExecuteNonQuery();
                        if (sqlCon.State == ConnectionState.Open)
                            sqlCon.Close();
                    }
                    catch
                    {
                        this.Alert("không thể sửa kho.", FrmThongBao.enmType.Error);
                    }
                    suaSach();
                }
            }
        }
    }
}
