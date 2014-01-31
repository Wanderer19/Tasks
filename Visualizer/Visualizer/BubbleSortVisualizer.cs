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
    public partial class BubbleSortVisualizer : Visualizer
    {
        public BubbleSortVisualizer()
        {
            InitializeComponent();
        }

        private void ShowHelpMessage(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText("help.txt"));
        }

        private void help_Click(object sender, EventArgs e)
        {

        }

        private void BubbleSortVisualizer_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonChangeData_Click(object sender, EventArgs e)
        {
            var array = Array.Select(i => i.ToString()).ToArray();
            var str = String.Join(",", array);
            MessageBox.Show(str);
        }
    }
}
