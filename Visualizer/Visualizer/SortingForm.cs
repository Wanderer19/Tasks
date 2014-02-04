using System;
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
    public partial class SortingForm : Form
    {
        private Application mainApplication;
      
        private SortingFormSettings currentSettings;

        public SortingForm(Application mainApplication, SortingFormSettings currentSettings)
        {
            this.currentSettings = currentSettings;
            this.mainApplication = mainApplication;

            InitializeComponent();
            this.aboutSorting.Items.AddRange(File.ReadAllLines(currentSettings.AboutSortingFile));
         
        }

        private void ShowSourceCode( string file)
        {
            var sourceCode = new Sourcecode(file);
            sourceCode.Show();
        }

        private void ShowSourceCodeCSharp(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(currentSettings.SourceCodeCSharp);
            sourceCode.Show();
        }

        private void ShowSourceCodeJava(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(currentSettings.SourceCodeJava);
            sourceCode.Show();
        }

        private void ShowSourceCodeCPlusPlus(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(currentSettings.SourceCodeCPlusPlus);
            sourceCode.Show();
        }

        private void ShowSourceCodePython(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(currentSettings.SourceCodePython);
            sourceCode.Show();
        }

        private void ShowHelp(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText(SortingFormSettings.HelpFile));
        }

        private void RunVisualizer(object sender, EventArgs e)
        {
            //var visualizer = new BubbleSortVisualizer(this);
            this.Visible = false;

            var data = new DataReceiverForm(this, currentSettings.SortID);
            data.Show();
        }

        private void CloseBubbleSortForm(object sender, EventArgs e)
        {
            mainApplication.Visible = true;
        }
    }
}
