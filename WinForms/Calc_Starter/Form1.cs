using Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class edit : Form
    {
        public edit()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcUI calc = this.Owner as CalcUI;
            try
            {
                double a, b, c;
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                c = Convert.ToDouble(textBox3.Text);

                double numericAnswer1, numericAnswer2;
                if (b * b - 4 * a * c >= 0)
                {
                    numericAnswer1 = (-1 * b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                    numericAnswer2 = (-1 * b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                    calc.DataAnswer(numericAnswer1.ToString() + " " + numericAnswer2.ToString());

                }
                else
                {
                    calc.DataAnswer("невозможно решить уравнение");
                }

                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("При выполнении ввода исходных данных возникла ошибка: \n" + er.Message,
                "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
        }
    }
}
