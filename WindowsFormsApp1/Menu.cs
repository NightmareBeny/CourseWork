using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();//подключаем WindowsMediaPlayer для проигрывания фоновой музыки
        public Menu()
        {
            InitializeComponent();
            WMP.URL = @"Music\music.mp3";//музыка должна находится там же, где и само приложение
            WMP.settings.volume = 25;//громкость
            WMP.controls.play();//начинаем играть
            label1.BackColor = Color.FromArgb(211, 104, 29);
            label2.BackColor = Color.FromArgb(211, 104, 29);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WMP.settings.volume = 0;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WMP.settings.volume = 25;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(119, 17, 17);
            button1.ForeColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        Point point;
        private void Мenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void Мenu_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            WMP.controls.stop();
            if (pictureBox2.Visible == true)
                WMP.settings.volume = 0;
            else WMP.settings.volume = 25;
            WMP.controls.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //false - открыта, true - не открыта
            bool check = true;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Stone")
                { check = false; break; }
            }
            if (check)
            {
                Stone form = new Stone();
                form.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //false - открыта, true - не открыта
            bool check = true;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Block")
                { check = false; break; }
            }
            if (check)
            {
                Block form = new Block();
                form.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //false - открыта, true - не открыта
            bool check = true;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Wire")
                { check = false; break; }
            }
            if (check)
            {
                Wire form = new Wire();
                form.Show();
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(119, 17, 17);
            button2.ForeColor = Color.White;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(119, 17, 17);
            button3.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            button1.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
            button2.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
            button3.ForeColor = Color.Black;
        }
    }
}
