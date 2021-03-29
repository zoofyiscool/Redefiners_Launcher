using System;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Redefiners_Games_Launcher
{
    public partial class Register0Form : Form
    {
        public Register0Form()
        {
            InitializeComponent();
            per.Stop();
        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        private void exit_Click(object sender, EventArgs e)
        {
            Control.ExitApplication();
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Control.DoMaximize(this, btn);
        }

        private void mizimize_Click(object sender, EventArgs e)
        {
            Control.DoMinzimize(this);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please type your username (doesn't matter real or fake)!");
                Console.Beep();
            }

            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please type your password!");
                Console.Beep();
            }

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (!File.Exists("hashpassword.txt"))
                {
                    File.Create("hashpassword.txt");
                    File.WriteAllText("hashpassword.txt", "Username:" + textBox1.Text + " " + "Password:" + textBox2.Text);
                    Thread.Sleep(300);
                    per.Start();
                }
                if (File.Exists("hashpassword.txt"))
                {
                    File.WriteAllText("hashpassword.txt", "Username:" + textBox1.Text + " " + "Password:" + textBox2.Text);
                    per.Stop(); //To stop writing the file
                }
                //test number 1003403079
            }

        }

        private void per_Tick(object sender, EventArgs e)
        {
            if (File.Exists("hashpassword.txt"))
            {
                File.WriteAllText("hashpassword.txt", "Username:" + textBox1.Text + " " + "Password:" + textBox2.Text);
                Thread.Sleep(400);
                per.Stop();
            }
        }
    }
}
