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
        private readonly Application parentWindow;
      
        private readonly SortingFormSettings interfaceSettings;

        public SortingForm(Application parentWindow, SortingFormSettings interfaceSettings)
        {
            this.interfaceSettings = interfaceSettings;
            this.parentWindow = parentWindow;

            InitializeComponent();
            this.aboutSorting.Items.AddRange(File.ReadAllLines(interfaceSettings.AboutSortingFile));
        }

        private void ShowSourceCodeCSharp(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(interfaceSettings.SourceCodeCSharp);
            sourceCode.Show();
        }

        private void ShowSourceCodeJava(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(interfaceSettings.SourceCodeJava);
            sourceCode.Show();
        }

        private void ShowSourceCodeCPlusPlus(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(interfaceSettings.SourceCodeCPlusPlus);
            sourceCode.Show();
        }

        private void ShowSourceCodePython(object sender, EventArgs e)
        {
            var sourceCode = new Sourcecode(interfaceSettings.SourceCodePython);
            sourceCode.Show();
        }

        private void ShowHelp(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText(SortingFormSettings.HelpFile));
        }

        private void RunVisualizer(object sender, EventArgs e)
        {
            HideMainWindow();

            var dataReceiverForm = new DataReceiverForm(this, interfaceSettings.SortID);
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
