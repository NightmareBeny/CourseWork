using System;
using System.Drawing;
using StoneThrow;
using System.Windows.Forms;

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
        private void Stone_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void Stone_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label7.Text = "Расстояние между телами равно";
            var stoneTohorizont = new StoneToHorizont();
            var stone = new StoneThrow.Stone();
            try
            {
                double angle = Convert.ToDouble(textBox1.Text);
                double speed = Convert.ToDouble(textBox2.Text);
                double time = Convert.ToDouble(textBox3.Text);

                #region Обработка ввода данных об угле броска
                if (angle < 0)
                {
                    MessageBox.Show("Угол не может быть отрицательным\nВведите число >=0");
                    return;
                }
                else while (angle > 360)
                        angle -= 360;
                if (angle == 90)
                {
                    MessageBox.Show("Вы бросили оба камня вверх");
                    stoneTohorizont.Angle = angle;
                }
                if (angle == 0 || angle >= 180)
                {
                    MessageBox.Show("Вы оставили 2-ой камень на земле");
                    stoneTohorizont.Angle = 0;
                }
                else stoneTohorizont.Angle = angle;
                #endregion

                #region Обработка ввода данных о скорости
                if (speed < 0)
                {
                    MessageBox.Show("Скорость не может быть отрицательна\nВведите число >=0");
                    return;
                }
                else if (speed == 0)
                {
                    MessageBox.Show("Вы оставили камни у себя в руках,\nчтобы кинуть их, введите число >0");
                    label5.Visible = true;
                    label6.Visible = true;
                    label6.Text += "\n0 м";
                    return;
                }
                else stone.Speed = stoneTohorizont.Speed = speed;
                #endregion

                #region Обработка ввода данных о времени полёта
                if (time < 0)
                {
                    MessageBox.Show("Время не может быть отрицательным\nВведите число >=0");
                    return;
                }
                else if (time == 0)
                {
                    MessageBox.Show("Вы оставили камни у себя в руках,\nчтобы кинуть их, введите число >0");
                    label5.Visible = true;
                    label6.Visible = true;
                    label6.Text += "\n0 м";
                    return;
                }
                else stone.Time = stoneTohorizont.Time = time;
                #endregion

                if (stoneTohorizont.IsFall())
                {
                    if (angle == 90)
                    {
                        label8.Text = "Камни упали";
                        label8.Visible = true;
                        label7.Visible = true;
                        label7.Text += "\n0 м";
                    }
                    else if(angle==0 || angle>=180)
                    {
                        if (stone.IsFall())
                        {
                            label8.Text = "Объект №1 упал";
                            label8.Visible = true;
                            label7.Visible = true;
                            label7.Text += "\n0 м";
                        }
                        else
                        {
                            label7.Visible = true;
                            label7.Text+= "\n" + stone.Distance()+ " м";
                        }
                    }
                    //при броске объекта №2 под углом к горизонту
                    else if (stone.IsFall())
                    {
                        label8.Text = "Камни упали";
                        label8.Visible = true;
                        label7.Visible = true;
                        label7.Text += "\n" + stoneTohorizont.Distance(true) + " м";
                    }
                    else
                    {
                        label8.Text = "Объект 2-ой упал";
                        label8.Visible = true;
                        label7.Visible = true;
                        label7.Text += "\n"+stoneTohorizont.Distance(false) + " м";
                    }
                }
                else if(angle==90)
                {
                    label7.Visible = true;
                    label7.Text += "\n0 м";
                }
                else
                {
                    label7.Visible = true;
                    label7.Text+= "\n" + stoneTohorizont.Distance(false)+ " м";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите данные во все поля\nВвод букв, спец.символом и знаков действий запрещён");
            }
        }
    }
}
