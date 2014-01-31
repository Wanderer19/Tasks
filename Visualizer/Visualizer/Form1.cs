using System;
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
    public partial class Form1 : Form
    {
        private BubbleSortForm bubbleSortForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void mainText_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
        private void BubbleSortRun(object sender, EventArgs e)
        {
            bubbleSortForm = new BubbleSortForm();
            bubbleSortForm.Show();
        }

          private void ShowAboutProgram(object sender, EventArgs e)
        {
            MessageBox.Show("Привет");
        }

        private void ShowHelp(object sender, EventArgs e)
        {
            MessageBox.Show("Пока");
        }
    }
}
