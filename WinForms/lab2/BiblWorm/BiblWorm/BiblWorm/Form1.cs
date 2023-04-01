﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblWorm
{
    public partial class Form1 : Form
    {
        public string Author // автор
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string Title // Название
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string PublishHouse // Издательство
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public int Page // Количество страниц
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }
        public int Year // Год издания
        {
            get { return (int)numericUpDown2.Value; }
            set { numericUpDown2.Value = value; }
        }
        public int InvNumber // Инвентарный номер
        {
            get { return (int)numericUpDown3.Value; }
            set { numericUpDown3.Value = value; }
        }
        public bool Existence // Наличие
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public bool SortInvNumber // Сортировка по инвентарному номеру
        {
            get { return checkBox2.Checked; }
            set { checkBox2.Checked = value; }
        }
        public bool ReturnTime // Возвращение в срок
        {
            get { return checkBox3.Checked; }
            set { checkBox3.Checked = value; }
        }
        public int PeriodUse // Инвентарный номер
        {
            get { return (int)numericUpDown4.Value; }


        set { numericUpDown4.Value = value; }
        }

        List<Item> its = new List<Item>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SortInvNumber)
                its.Sort();
            StringBuilder sb = new StringBuilder();
            foreach (Item item in its)
            {
                sb.Append("\n" + item.ToString());
            }
            richTextBox1.Text = sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book b = new Book(Author, Title, PublishHouse, Page, Year, InvNumber, Existence);
            if (ReturnTime)
                b.ReturnSrok();
            b.PriceBook(PeriodUse);
            its.Add(b);
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (SortInvNumber)
                its.Sort();
            StringBuilder sb = new StringBuilder();
            foreach (Item item in its)
            {
                sb.Append("\n" + item.ToString());
            }
            richTextBox1.Text = sb.ToString();
        }

        public string Volume // том
        {
            get { return textBox1.Text; }
            set { textBox4.Text = value; }
        }
        public string titleMag // Название
        {
            get { return textBox2.Text; }
            set { textBox5.Text = value; }
        }
        
        public int Number // номер
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown6.Value = value; }
        }

        public int YearMag // дата
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown5.Value = value; }
        }

        public bool Subscribtion  // Подписка
        {
            get { return checkBox3.Checked; }
            set { checkBox4.Checked = value; }
        }

        public int InvNumberMag // Инвентарный номер
        {
            get { return (int)numericUpDown3.Value; }
            set { numericUpDown7.Value = value; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Magazine m = new Magazine(Volume, Number, titleMag, YearMag, InvNumberMag, Subscribtion);
            
            
            its.Add(m);
            
            

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Item item in its)
            {
                sb.Append("\n" + item.ToString());
            }
            richTextBox2.Text = sb.ToString();
        }
    }
}
