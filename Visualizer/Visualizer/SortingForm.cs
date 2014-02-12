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
    public partial class SortingForm : Form
    {
        private readonly Application parentWindow;

        private System.Resources.ResourceManager sortingFormSettings;
       
        public SortingForm(Application parentWindow, string fileSettings)
        {
            this.parentWindow = parentWindow;
            
            this.DownloadConfigurationFile(fileSettings);
            InitializeComponent();
        }

        public void DownloadConfigurationFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            sortingFormSettings = new ResourceManager(fileName, assembly);
        }

        private void ShowSourceCodeCSharp(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(sortingFormSettings.GetString("SourceCodeCSharp"));
            sourceCode.Show();
        }

        private void ShowSourceCodeJava(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(sortingFormSettings.GetString("SourceCodeJava"));
            sourceCode.Show();
        }

        private void ShowSourceCodeCPlusPlus(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(sortingFormSettings.GetString("SourceCodeCPlusPlus"));
            sourceCode.Show();
        }

        private void ShowSourceCodePython(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(sortingFormSettings.GetString("SourceCodePython"));
            sourceCode.Show();
        }

        private void ShowHelp(object sender, EventArgs e)
        {
            MessageBox.Show(sortingFormSettings.GetString("HelpFile"));
        }

        private void RunVisualizer(object sender, EventArgs e)
        {
            HideMainWindow();

            var dataReceiverForm = new DataReceiverForm(this, (int) sortingFormSettings.GetObject("SortID"));
            dataReceiverForm.Show();
        }

        private void HideMainWindow()
        {
            this.Visible = false;
        }

        private void CloseBubbleSortForm(object sender, EventArgs e)
        {
            ShowParentWindow();
        }

        private void ShowParentWindow()
        {
            parentWindow.Visible = true;
        }
    }
}
