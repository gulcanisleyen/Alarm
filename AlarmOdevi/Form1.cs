using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmOdevi
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer muzikplayer = new System.Media.SoundPlayer(@"C:\Users\Acer\alarm.wav");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
            this.Visible = false;
            //this.WindowState = FormWindowState.Minimized;
      
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            muzikplayer.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToLongTimeString();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToShortTimeString();
            if (time == maskedTextBox1.Text)
            {
                muzikplayer.Play();
                richTextBox1.BackColor = Color.Red;
                this.Visible = true;
                timer2.Stop();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
