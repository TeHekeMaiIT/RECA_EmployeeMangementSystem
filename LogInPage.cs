using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMangementForm
{
    public partial class LogInPage : Form
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            MainFrame main = new MainFrame();
            this.Hide();
            main.ShowDialog();
        }

        private void LogIn_pnl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
