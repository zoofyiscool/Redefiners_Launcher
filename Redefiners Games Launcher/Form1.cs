using System;
using System.Windows.Forms;

namespace Redefiners_Games_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Hide();
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            panel3.Width += 3;
            if (panel3.Width == 63)
            {
                label1.Text = "you are dumb a*s?";
                label2.Show();
            }
            if (panel3.Width == 69)
            {
                label1.Text = "The width of loading bar is 69 now?";
                label2.Show();
            }
            if (panel3.Width >= panel1.Width)
            {
                LoadingTimer.Stop();
                this.Hide();
                Register0Form register = new Register0Form();
                register.Show();
            }
        }
    }
}
