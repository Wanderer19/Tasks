﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualizer
{
    public partial class Sourcecode : Form
    {
        private string file;
        public Sourcecode(string file)
        {
            this.file = file;
            InitializeComponent();
        }

        private void bubbleSortCode_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}