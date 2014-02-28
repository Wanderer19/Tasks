using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
                this.Visible = false;
                visualizer.Array = array;
                visualizer.Show();

            }
            else
            {
                try
                {
                    var str = this.inputField.Text;
                    var isValid = true;

                    if (str.Any(i => !Char.IsWhiteSpace(i) && !Char.IsNumber(i) && i != '-'))
                    {
                        this.inputField.Text = "";
                        isValid = false;
                    }

                    if (isValid)
                    {
                        str = Regex.Replace(str, @"\s+", ",");

                        var array =
                            str.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
                        this.Visible = false;
                        visualizer.Array = array;
                        visualizer.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка! Неправильный формат строки.");
                    }
                }
                catch (Exception ex)
                {
                    this.inputField.Text = "";
                    MessageBox.Show("Ошибка! Неправильный формат строки.");
                }
            }
        }
    }
}
