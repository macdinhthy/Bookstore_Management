using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace QLStoreSach
{
    public partial class Password : Form
    {
        public Password()
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
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        //cập nhật password
        private void ChangePassword()
        {
            if (txtPassword1.Text.Length == 0)
            {
                this.Alert("Bạn chưa nhập mật khẩu mới.", FrmThongBao.enmType.Error);
            }
            else if(txtPassword1.Text != txtPassword2.Text)
            {
                this.Alert("Mật khẩu xác nhận không đúng.", FrmThongBao.enmType.Error);
            }
            else
            {
                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Update TaiKhoan set Password=@Password where Email=@Email", sqlCon);
                    //thuc thi
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword1.Text);
                    cmd.ExecuteNonQuery();
                    panelCheck.Hide();
                    this.Alert("Sửa thành công.", FrmThongBao.enmType.Success);
                    if (sqlCon.State == ConnectionState.Open)
                        sqlCon.Close();
                }
                catch
                {
                    this.Alert("Không thể sửa.", FrmThongBao.enmType.Error);
                }
            }
            
        }
        #region e meo
        Random rd = new Random();
        public int code;
        private void mail()
        {

            code = rd.Next(123123, 999999);
            const string p = "thyyy137ZZ#";


            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress("thydz137@gmail.com");

            message.To.Add(new MailAddress(txtEmail.Text));
            message.Subject = "Thay đổi mật khẩu";
            message.Body = "Mã code để thay đổi mật khẩu: " + code + "\nThank you! <3";

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("thydz137@gmail.com", p);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
            this.Alert("Đã giử 1 mã code vào " + txtEmail.Text, FrmThongBao.enmType.Success);
            panelCheck.Show();

        }
        #endregion

        //btn update
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string email = txtEmail.Text;
                SqlCommand cmd = new SqlCommand("Select * from TaiKhoan where Email = '" + email + "'", sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    mail();
                }
                else if (txtEmail.Text.Length == 0)
                {
                    this.Alert("Bạn chưa nhập Email", FrmThongBao.enmType.Error);
                }
                else
                {
                    this.Alert("Email không đúng..! Mời nhập lại.", FrmThongBao.enmType.Error);
                }
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            catch
            {
                this.Alert("Lỗi", FrmThongBao.enmType.Error);
            }
        }

        #region Show pass
        private void ptbShow_Click(object sender, EventArgs e)
        {
            if (txtPassword1.PasswordChar == '●')
            {
                ptbHide.BringToFront();
                txtPassword1.PasswordChar = '\0';
                txtPassword2.PasswordChar = '\0';
            }
        }
        
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (txtPassword1.PasswordChar == '\0')
            {
                ptbShow.BringToFront();
                txtPassword1.PasswordChar = '●';
                txtPassword2.PasswordChar = '●';
            }
        }
        #endregion

        private void Password_Load(object sender, EventArgs e)
        {
            panelCheck.Hide();
            panelUpdate.Hide();
        }

        //btn update mật khẩu
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
        // btn check code
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtSendCode.Text.Length == 0)
            {

            }
            else if (code.ToString() == txtSendCode.Text)
            {
                panelUpdate.Show();
            }
            else
            {
                this.Alert("Code không đúng..! Mời nhập lại.", FrmThongBao.enmType.Error);
            }
        }

        // send again
        private void label7_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length != 0)
            {
                mail();
            }
        }

        private void txtSendCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    
}
