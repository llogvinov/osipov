using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_control
{
    public partial class Form1 : Form
    {
        delegate void GoAlgh(string str);
        private GoAlgh PrintDlegateFunc;
        public Form1()
        {
            InitializeComponent();

            PrintDlegateFunc = new GoAlgh(PrintFunc);
        }

        void PrintFunc(string str)
        {
            ResultLabel.Text = str;
            ResultLabel.Invoke(PrintDlegateFunc, new object[] { str });
        }

        private async Task<string> GoButt (int mv)
        {
            return await Task.Run(() =>
            {
                System.Text.StringBuilder resultText = new
                System.Text.StringBuilder();
                for (int trial = 2; trial <= mv; trial++)
                {
                    bool isPrime = true;
                    for (int divisor = 2; divisor <= Math.Sqrt(trial); divisor++)
                    {
                        if (trial % divisor == 0)

                        {

                            isPrime = false;

                            break;

                        }
                    }
                    if (isPrime)
                    {
                        resultText.AppendFormat("{0} ", trial);
                    }
                }
                return resultText.ToString();
            }
);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            int mv = 0;
            try
            {
                mv = Int32.Parse(MaxValue.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("При выполнении преобразования типов возникла ошибка");
                return;
            }
            string res = await GoButt(mv);
            ResultLabel.Text = res;
        }
    }
}
