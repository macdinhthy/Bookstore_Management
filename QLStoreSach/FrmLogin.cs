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

namespace QLStoreSach
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
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

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //btn đăng nhập
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string tk = txtUserName.Text;
                string mk = txtpassword.Text;
                SqlCommand cmd = new SqlCommand("Select * from TaiKhoan where Username = '" + tk + "' and Password = '" + mk + "'", sqlCon);
                //thuc thi
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    new Loadinggg().Show();
                    this.Alert("Đăng nhập thành công", FrmThongBao.enmType.Success);
                    txtpassword.Clear();
                    txtUserName.Clear();
                    txtpassword.Focus();
                    this.Hide();
                }
                else if (txtUserName.Text == "" && txtpassword.Text == "")
                {
                    this.Alert("Mời bạn nhập tài khoản!", FrmThongBao.enmType.Warning);
                }
                else
                {
                    txtpassword.Clear();
                    this.Alert("Tài khoản không đúng! Vui lòng thử lại.", FrmThongBao.enmType.Error);
                    txtpassword.Focus();
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

        private void label2_Click(object sender, EventArgs e)
        {
            new Password().Show();
            this.Hide();
        }

        //hide và show passwword
        private void ptbHide_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '\0')
            {
                ptbShow.BringToFront();
                txtpassword.PasswordChar = '●';
            }
        }

        private void ptbShow_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '●')
            {
                ptbHide.BringToFront();
                txtpassword.PasswordChar = '\0';
            }
        }
    }
}
