using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                checkedListBox1.Items.Add(textBox1.Text);
            }
            else MessageBox.Show("Выберите элемент из списка или введите новый");
        }

     
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Поле Name не может содержать цифры");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}