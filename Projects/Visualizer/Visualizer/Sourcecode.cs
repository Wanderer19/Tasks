using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualizer
{
    public partial class Sourcecode : Form
    {
        private readonly string sourceCode;
        private readonly System.Resources.ResourceManager settings;

        public Sourcecode(string sourceCode)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            settings = new ResourceManager("Visualizer.SourceCodeSettings", assembly);
            this.sourceCode = sourceCode;
            InitializeComponent();
        }
    }
}
