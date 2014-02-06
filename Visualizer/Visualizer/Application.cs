﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Visualizer
{
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }
      
        private void BubbleSortRun(object sender, EventArgs e)
        {
            HideMainWindow();
            
            var bubbleSortForm = new SortingForm(this, new BubbleSortFormSettings());
            bubbleSortForm.Show();
        }

        private void SelectionSortRun(object sender, EventArgs e)
        {
            HideMainWindow();

            var selectionSortForm = new SortingForm(this, new SelectionSortFormSettings());

            selectionSortForm.Show();
        }

        private void HideMainWindow()
        {
            this.Visible = false; 
        }

        private void ShowAboutProgram(object sender, EventArgs e)
        {
            MessageBox.Show(String.Join("\n", File.ReadAllLines(GeneralSettings.AboutProgramFile)));
        }

        private void ShowHelp(object sender, EventArgs e)
        {
            MessageBox.Show(String.Join("\n", File.ReadAllLines(GeneralSettings.HelpFile)));
        }

        
    }
}
