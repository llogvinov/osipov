﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBindingSimple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productsTableAdapter1.Fill(northwindqDataSet1.Products);
            productsBindingSource = new BindingSource(northwindqDataSet1,"Products");
            ProductIDTextBox.DataBindings.Add("Text",productsBindingSource, "ProductID");
            ProductNameTextBox.DataBindings.Add("Text",productsBindingSource, "ProductName");
        }
        private BindingSource productsBindingSource;

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            productsBindingSource.MovePrevious();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            productsBindingSource.MoveNext();
        }
    }
}
