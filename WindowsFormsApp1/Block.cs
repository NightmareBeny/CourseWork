using System;
using System.Drawing;
using System.Windows.Forms;
using Tension;

namespace WindowsFormsApp1
{
    public partial class Block : Form
    {
        public Block()
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
        private void Block_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void Block_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            try
            {
                double mass = Convert.ToDouble(textBox1.Text);
                double force = Convert.ToDouble(textBox2.Text);
                //Масса груза < 0
                if (mass < 0)
                    MessageBox.Show("Масса груза не может быть отрицательной величиной\nВведите число >=0");
                //Сила < 0
                else if (force < 0)
                    MessageBox.Show("Сила не может быть отрицательной величиной\nВведите число >=0");
                //Масса блока < 0
                else if (Convert.ToDouble(textBox3.Text) < 0)
                    MessageBox.Show("Масса блока не может быть отрицательной величиной\nВведите число >=0");
                else if (mass == 0)
                {
                    MessageBox.Show("Вы ничего не поднимаете, поэтому сила натяжения тросса и ускорение равны 0\n");
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = false;
                    label6.Visible = true;
                    label7.Visible = true;
                    label7.Text = "0(Н)\n0(м/с^2)";
                }
                else if (force == 0)
                {
                    MessageBox.Show("Вы не тянете груз, поэтому сила натяжения тросса и ускорение равны 0\n");
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label7.Text = "0(Н)\n0(м/с^2)";
                }
                else
                {
                    TensionClass tension = new TensionClass(force, mass);
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    label6.Visible = true;
                    label7.Visible = true;
                    label7.Text = tension.T().ToString() + $" (Н)\n{tension.Acceleration} (м/с^2)\nМасса блока\nне имеет значения";
                }
            } 
            catch (Exception)
            {
                MessageBox.Show("Введите данные во все поля\nВвод букв, спец.символом и знаков действий запрещён");
            }            
        }
    }
}
