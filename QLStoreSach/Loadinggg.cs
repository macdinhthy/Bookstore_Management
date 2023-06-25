using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QLStoreSach
{
    public partial class Loadinggg : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
    (
    int nLeftRect,
    int nTopRect,
    int RightRect,
    int nBottomRect,
    int nWidthEllipse,
    int nHeightEllipse
    );
        public Loadinggg()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            prograssbar1.Value = 0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            prograssbar1.Value += 2;
            prograssbar1.Text = prograssbar1.Value.ToString() + "%";

            if (prograssbar1.Value == 100)
            {
                Timer.Enabled = false;
                FrmProgram.MainForm t = new FrmProgram.MainForm();
                t.Show();
                this.Hide();
            }
        }
    }
}