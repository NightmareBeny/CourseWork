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
            
                label6.Visible = true;
                TensionClass tension = new TensionClass();
            try
            {
                tension.Mass = Convert.ToDouble(textBox1.Text);
                tension.Force = Convert.ToDouble(textBox2.Text);
                if (tension.Mass == 0)
                {
                    MessageBox.Show("Вы ничего не поднимаете, поэтому сила натяжения тросса равна 0");
                    label7.Text = "0";
                    return;
                }
                if (tension.Force==0)
                {
                    MessageBox.Show("Вы не тянете груз, поэтому сила натяжения тросса равна 0");
                    label7.Text = "0";
                    return;
                }                
                label7.Text = tension.T().ToString() + " (Н)\nМасса блока \nне имеет значения";
            } 
            catch (Exception)
            {
                MessageBox.Show("Введите данные во все поля");
            }            
        }
    }
}
