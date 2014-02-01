using System;
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
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }
      
        private void BubbleSortRun(object sender, EventArgs e)
        {
            this.Visible = false;
           
            var bubbleSortForm = new BubbleSortForm(this);
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
