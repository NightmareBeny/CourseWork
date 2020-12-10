using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;
using StoneThrow;

namespace WindowsFormsApp1
{
    public partial class Stone : Form
    {
        public Stone()
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
        private void График_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void График_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stoneTohorizont = new StoneToHorizont();
            var stone = new StoneThrow.Stone();
            try
            {
                stoneTohorizont.Angle = Convert.ToDouble(textBox1.Text);
                stone.Speed = stoneTohorizont.Speed = Convert.ToDouble(textBox2.Text);
                if(textBox2.Text=="0")
                {
                    label7.Visible = true;
                    label7.Text = "Вы не бросили камни,\n т.е. расстояние между\n ними равно 0";
                    return;
                }
                stone.Time = stoneTohorizont.Time = Convert.ToDouble(textBox3.Text);
                if (textBox3.Text == "0")
                {
                    label7.Visible = true;
                    label7.Text = "Вы не бросили камни,\n т.е. расстояние между\n ними равно 0";
                    return;
                }
                label6.Visible = true;
                label7.Visible = true;
                //label7.Text = stoneTohorizont.Distance().ToString() + " (м)";
            }
            catch (Exception)
            {
                MessageBox.Show("Введите данные во все поля");
            }
        }
    }
}
