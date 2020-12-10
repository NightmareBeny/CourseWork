using System;
using Stretching;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Wire : Form
    {
        public Wire()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(255, 140, 0);
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
        private void Wire_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void Wire_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            try
            {
                double d = Convert.ToDouble(textBox1.Text);
                double l = Convert.ToDouble(textBox2.Text);
                double m = Convert.ToDouble(textBox3.Text);
                //диаметр проволоки < 0
                if (d < 0)
                    MessageBox.Show("Диаметр проволоки не может быть отрицательной величиной\nВведите число >=0");
                //Расстояние между зажимами < 0
                else if (l < 0)
                    MessageBox.Show("Расстояние между зажимами не может быть отрицательной величиной\nВведите число >=0");
                //Масса груза < 0
                else if (m < 0)
                    MessageBox.Show("Масса груза не может быть отрицательной величиной\nВведите число >=0");
                else if (d == 0)
                {
                    MessageBox.Show("У вас нет проволоки\nВведите число >0");
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = false;
                }
                else if (l == 0)
                    MessageBox.Show("Расстояние между зажимами не должно равняться 0\nВведите число >0");
                else if (m == 0)
                {
                    MessageBox.Show("Ничего не растягивает проволоку");
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label7.Text = "0 см";
                }
                else
                {
                    StretchingClass stretch = new StretchingClass(d, l, m);
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    label6.Visible = true;
                    label7.Visible = true;
                    label7.Text = stretch.Stretch().ToString() + " (см)";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите данные во все поля\nВвод букв, спец.символом и знаков действий запрещён");
            }
        }
    }
}
