﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Visualizer
{
    public partial class BubbleSortForm : Form
    {
        private Application mainApplication;
        private XDocument settings;

        public BubbleSortForm(Application mainApplication)
        {
            settings = XDocument.Load("BubbleSortFormSettings.xml");
            this.mainApplication = mainApplication;
            InitializeComponent();
        }
      
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ShowSourceCodeCSharp(object sender, EventArgs e)
        {
            var code = new Sourcecode("c#.txt");
            code.Show();
        }

        private void ShowSourceCodeJava(object sender, EventArgs e)
        {
            var code = new Sourcecode("javaCode.txt");
            code.Show();
        }

        private void ShowSourceCodeCPlusPlus(object sender, EventArgs e)
        {
            var code = new Sourcecode("c++.txt");
            code.Show();
        }

        private void ShowSourceCodePython(object sender, EventArgs e)
        {
            var code = new Sourcecode("python.txt");
            code.Show();
        }

        private void ShowHelp(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText("help.txt"));
        }

        private void RunVisualizer(object sender, EventArgs e)
        {
            var visualizer = new BubbleSortVisualizer(this);
            this.Visible = false;

            var data = new Data(visualizer);
            data.Show();
        }

        private void CloseBubbleSortForm(object sender, EventArgs e)
        {
            mainApplication.Visible = true;
        }
    }
}
