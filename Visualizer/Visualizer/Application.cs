using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Visualizer
{
    public partial class Application : Form
    {
        private static Assembly assembly = Assembly.GetExecutingAssembly();
        private System.Resources.ResourceManager generalSettings = new ResourceManager("Visualizer.GeneralSettings", assembly);

        public Application()
        {
          

            InitializeComponent();
        }

        private void BubbleSortRun(object sender, EventArgs e)
        {
            HideMainWindow();
            
            var bubbleSortForm = new SortingForm(this, "Visualizer.BubbleSortFormSettings");
            bubbleSortForm.Show();
        }

        private void SelectionSortRun(object sender, EventArgs e)
        {
            HideMainWindow();

            var selectionSortForm = new SortingForm(this, "Visualizer.SelectionSortFormSettings");

            selectionSortForm.Show();
        }

        private void HeapSortRun(object sender, EventArgs e)
        {
            HideMainWindow();

            var selectionSortForm = new SortingForm(this, "Visualizer.HeapSortFormSettings");

            selectionSortForm.Show();
        }

        private void HideMainWindow()
        {
            this.Visible = false; 
        }

        private void ShowAboutProgram(object sender, EventArgs e)
        {
            MessageBox.Show(generalSettings.GetString("AboutProgram"));
        }
    }
}
