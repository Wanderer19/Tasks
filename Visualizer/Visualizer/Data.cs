using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualizer
{
    public partial class Data : Form
    {
        private bool choice;
        private Visualizer visualizer;

        public Data(Visualizer visualizer)
        {
            this.visualizer = visualizer;
            InitializeComponent();
        }

        private void SelectDefaultData(object sender, EventArgs e)
        {
            choice = true;
        }

        private void SelectEnteredDataButton(object sender, EventArgs e)
        {
            choice = false;
        }

        private void RunVisualizer(object sender, EventArgs e)
        {
            if (choice)
            {
                var array = new int[] {0, -9, 7, 1, 5};
                visualizer.Array = array;
                visualizer.Show();

            }
            else
            {
                var arrayStrings = this.inputField.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                var array = arrayStrings.Select(int.Parse).ToArray();

                visualizer.Array = array;
                visualizer.Show();
            }
        }
    }
}
