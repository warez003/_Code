using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            this.Text = "Табулирование функций";
            label1.Text = "X0";
            label1.Font = new Font("Times new roman", 14, FontStyle.Regular);
            label2.Text = "XM";
            label2.Font = new Font("Times new roman", 14, FontStyle.Regular);
            label3.Text = "XD";
            label3.Font = new Font("Times new roman", 14, FontStyle.Regular);
            groupBox1.Text = "Действие";
            groupBox1.Font = new Font("Times new roman", 14, FontStyle.Regular);
            radioButton1.Text = "MIN";
            radioButton1.Font = new Font("Times new roman", 14, FontStyle.Regular);
            radioButton2.Text = "MAX";
            radioButton2.Font = new Font("Times new roman", 14, FontStyle.Regular);
            radioButton3.Text = "Средн. арифм.";
            radioButton3.Font = new Font("Times new roman", 14, FontStyle.Regular);
            button1.Text = "Вычислить";
            button1.Font = new Font("Times new roman", 14, FontStyle.Regular);
            label4.Text = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            double x0 = Convert.ToDouble(textBox1.Text); double y = Math.Log(3 * x0) * Math.Cos(3 * x0);
            double xd = Convert.ToDouble(textBox3.Text); 
            double xm = Convert.ToDouble(textBox2.Text);
            double min = double.MaxValue; double max = double.MinValue; double sum = 0; double n = 0;

            this.chart1.Series[0].Points.Clear();

            while(x0 < xm)
            {
                n++;
                y = Math.Log(3 * x0) * Math.Cos(3 * x0);
                x0 += xd;
                sum += y;

                if(y < min)
                {
                    min = y;
                }
                if(y > max)
                {
                    max = y;
                }
                this.chart1.Series[0].Points.AddXY(x0,y);

            }

            sum = sum / n;

            if(radioButton1.Checked)
            {
                label4.Text = "Min = " + Convert.ToString(min);
                label4.Font = new Font("Times new roman", 14, FontStyle.Regular);
            }
            else if(radioButton2.Checked)
            {
                label4.Text = "Max = " + Convert.ToString(max);
                label4.Font = new Font("Times new roman", 14, FontStyle.Regular);
            }
            else if (radioButton3.Checked)
            {
                label4.Text = "Ср. ариф. = " + Convert.ToString(sum);
                label4.Font = new Font("Times new roman", 14, FontStyle.Regular);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }
    }
}
