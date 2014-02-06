using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Visualizer
{
    public partial class DataReceiverForm : Form
    {
        private bool choice = true;
        private readonly SortingForm parentWindow;
        private readonly int sortId;
        private int[] inputArray;

        public DataReceiverForm(SortingForm parentWindow, int sortId)
        {
            this.parentWindow = parentWindow;
            this.sortId = sortId;
            
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
            if (VisualizerCanBeRun())
            {

                HideMainWindow();

                var visualizer = GetVisualizer(this.inputArray);
                visualizer.Show();
            }
            else
                ProcessErrorReadingData();
        }

        private void HideMainWindow()
        {
            this.Visible = false;
        }

        private Visualizer GetVisualizer(int[] array)
        {
            switch (sortId)
            {
                case GeneralSettings.BubbleSortId:
                {
                       return new BubbleSortVisualizer(parentWindow, array);
                }
                case GeneralSettings.SelectionSortId:
                {
                      return new SelectionSortVisualizer(parentWindow, array);
                }
                default:
                {
                    return new Visualizer();
                }
            }
        }

        private void ProcessErrorReadingData()
        {
            this.inputField.Text = "";

            MessageBox.Show(DataReceiverFormSettings.ErrorMessage);
        }

        private void CloseDataReceiverForm(object sender, EventArgs e)
        {
            ShowParentWindow();
        }

        private void ShowParentWindow()
        {
            parentWindow.Visible = true;
        }
    }
}
