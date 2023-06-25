using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLStoreSach.FrmProgram
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ChuyenPnl(btnTrangChu);
        }
        private void ChuyenPnl(Control c)
        {
            SidePanel.Height = c.Height;
            SidePanel.Top = c.Top;
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

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ChuyenPnl(btnTrangChu);
            OpenFrm(new FrmHome());
        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            ChuyenPnl(btnQuanLySach);
            OpenFrm(new FrmSach());
        }

        private void btnBanSach_Click(object sender, EventArgs e)
        {
            ChuyenPnl(btnBanSach);
            OpenFrm(new FrmBanSach());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ChuyenPnl(btnKhachHang);
            OpenFrm(new KhachHang());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ChuyenPnl(btnLogout);
            new FrmLogin().Show();
            this.Hide();
        }

        private void btnQLKho_Click(object sender, EventArgs e)
        {
            ChuyenPnl(btnQLKho);
            OpenFrm(new FrmQLKho());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChuyenPnl(btnTrangChu);
            OpenFrm(new FrmHome());
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            ChuyenPnl(bunifuButton3);
            OpenFrm(new FrmDoanhThu());
        }
    }
}
