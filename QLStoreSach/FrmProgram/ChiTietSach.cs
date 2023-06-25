using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLStoreSach.FrmProgram
{
    public partial class ChiTietSach : Form
    {
        public ChiTietSach()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public ChiTietSach(string TenSach, string TacGia, string TheLoai, string NXB, string NhanXet1, string NhanXet2, string NhanXet3, string NhanXet4, string GiaBan, string NamXuatBan, string MoTa, string UrlImageSau, string UrlImage = "")
        {
            InitializeComponent();
            string _tenSach = TenSach;
            string _tacGia = TacGia;
            string _theLoai = TheLoai;
            string _nXB = NXB;
            string _giaBan = GiaBan;
            string _namXuatBan = NamXuatBan;
            string _moTa = MoTa;
            string _urlImage = UrlImage;
            string _UrlImageSau = UrlImageSau;
            string _NhanXet1 = NhanXet1;
            string _NhanXet2 = NhanXet2;
            string _NhanXet3 = NhanXet3;
            string _NhanXet4 = NhanXet4;

            lbTenSach.Text = _tenSach;
            lbTacGia.Text = _tacGia;
            lbTheLoai.Text = _theLoai;
            lbNamXB.Text = _namXuatBan;
            lbNXB.Text = _nXB;
            lbGiaBan.Text = _giaBan;
            lbMoTa.Text = _moTa;
            lbnx1.Text = _NhanXet1;
            lbnx2.Text = _NhanXet2;
            lbnx3.Text = _NhanXet3;
            lbnx4.Text = _NhanXet4;

            lbnx1.Hide();
            lbnx2.Hide();
            lbnx3.Hide();
            lbnx4.Hide();

            // show image
            var request = WebRequest.Create(_urlImage);
            var re1 = WebRequest.Create(_UrlImageSau);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pbAnh.Image = Bitmap.FromStream(stream);
                pbAnh.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            using (var rp = re1.GetResponse())
            using (var stream = rp.GetResponseStream())
            {
                pbAnh2.Image = Bitmap.FromStream(stream);
                pbAnh2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pbAnh.Hide();
            pbAnh2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pbAnh2.Hide();
            pbAnh.Show();
        }

        private void pbAnh_Click(object sender, EventArgs e)
        {
            pbAnh2.BringToFront();
        }

        private void pbAnh2_Click(object sender, EventArgs e)
        {
            pbAnh.BringToFront();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            bunifuRating1.Value = 5;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            bunifuRating1.Value = 4;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            bunifuRating1.Value = 3;
        }


        private void bunifuRating1_onValueChanged(object sender, EventArgs e)
        {
            if (bunifuRating1.Value == 5)
            {
                lbDanhGia.ForeColor = System.Drawing.Color.Green;
                lbDanhGia.Text = "Tuyệt vời";
            }
            if (bunifuRating1.Value == 4)
            {
                lbDanhGia.ForeColor = System.Drawing.Color.YellowGreen;
                lbDanhGia.Text = "Tốt";
            }
            if (bunifuRating1.Value == 3)
            {
                lbDanhGia.ForeColor = System.Drawing.Color.FromArgb(0, 77, 153);
                lbDanhGia.Text = "Tạm được";
            }
            if (bunifuRating1.Value == 2)
            {
                lbDanhGia.ForeColor = System.Drawing.ColorTranslator.FromHtml("#22FF99");
                lbDanhGia.Text = "Tệ";
            }
            if (bunifuRating1.Value == 1)
            {
                lbDanhGia.ForeColor = System.Drawing.Color.Red;
                lbDanhGia.Text = "Rất tệ";
            }
            if (bunifuRating1.Value == 0)
            {
                lbDanhGia.Text = "";
            }
        }

        private void ChiTietSach_Load(object sender, EventArgs e)
        {
            if (bunifuRating1.Value == 0)
            {
                lbDanhGia.Text = "";
            }
        }

        #region Xem nhận xét
        int kt = 0;
        private void btnNhanXet_Click(object sender, EventArgs e)
        {
            kt += 1;
            if (kt % 4 == 0)
            {
                lbnx4.Show();
                lbnx1.Hide();
                lbnx2.Hide();
                lbnx3.Hide();
            }  
            else if (kt % 4 == 1)
            {
                lbnx1.Show();
                lbnx2.Hide();
                lbnx3.Hide();
                lbnx4.Hide();
            }
            else if(kt % 4 == 2)
            {
                lbnx2.Show();
                lbnx1.Hide();
                lbnx4.Hide();
                lbnx3.Hide();
            }
            else if(kt % 4 == 3)
            {
                lbnx3.Show();
                lbnx1.Hide();
                lbnx2.Hide();
                lbnx4.Hide();
            }
        }
        #endregion
    }
}
