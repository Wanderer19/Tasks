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

        public enum IdentifiersSorts
        {
<<<<<<< HEAD
          

=======
            DefaultSorting = 0,
            BubbleSort = 1,
            SelectionSort = 2,
            HeapSort = 3
        }

        public Application()
        {
            this.DownloadConfigurationFile("Visualizer.GeneralSettings");
>>>>>>> 2bb74d776b6c761e0cc701d47ffed726513cad2c
            InitializeComponent();
        }

        public void DownloadConfigurationFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            generalSettings = new ResourceManager(fileName, assembly);
        }

        private void BubbleSortRun(object sender, EventArgs e)
        {
            HideMainWindow();
            
            var bubbleSortForm = new SortingForm(this, "Visualizer.BubbleSortFormSettings", IdentifiersSorts.BubbleSort);
            bubbleSortForm.Show();
        }

        private void SelectionSortRun(object sender, EventArgs e)
        {
            HideMainWindow();

            var selectionSortForm = new SortingForm(this, "Visualizer.SelectionSortFormSettings", IdentifiersSorts.SelectionSort);

            selectionSortForm.Show();
        }

        private void HeapSortRun(object sender, EventArgs e)
        {
            HideMainWindow();

            var selectionSortForm = new SortingForm(this, "Visualizer.HeapSortFormSettings", IdentifiersSorts.HeapSort);

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
