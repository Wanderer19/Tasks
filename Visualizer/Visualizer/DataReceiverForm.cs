using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
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
        private System.Resources.ResourceManager settings;
        private bool choice = true;
        private readonly SortingForm parentWindow;
        private readonly int sortId;
        private int[] inputArray;
        
        private const int BubbleSortId = 1;
        private const int SelectionSortId = 2;
        private const int HeapSortId = 3;

        public DataReceiverForm(SortingForm parentWindow, int sortId)
        {
            this.parentWindow = parentWindow;
            this.sortId = sortId;
            
            DownloadConfigurationFile("Visualizer.DataReceiverFormSettings");
            InitializeComponent();
        }

        public void DownloadConfigurationFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            settings = new ResourceManager(fileName, assembly);
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

        private bool VisualizerCanBeRun()
        {
            var isValidData = true;
            var array = new int[] { 16, 11, 9, 10, 5, 6, 8, 1, 2, 4, 2, 1, 2, 3, 4 };

            if (!choice)
            {
                if (ArrayReader.IsValidInputString(inputField.Text))
                {
                    array = ArrayReader.ReadData(inputField.Text);
                    isValidData = true;
                }
                else
                    isValidData = false;
            }

            inputArray = array;

            return isValidData && ArrayReader.IsValidValuesElementsInArray(array, (int)settings.GetObject("SizeLimitArray"), (int)settings.GetObject("LimitArrayElementValue"));
        }

        private void HideMainWindow()
        {
            this.Visible = false;
        }

        private Visualizer GetVisualizer(int[] array)
        {
            switch (sortId)
            {
                case BubbleSortId:
                {
                       return new BubbleSortVisualizer(parentWindow, array, BubbleSortId);
                }
                case SelectionSortId:
                {
                      return new SelectionSortVisualizer(parentWindow, array, SelectionSortId);
                }
                case HeapSortId:
                {
                    return new HeapSortVisualizer(parentWindow, array, HeapSortId);
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

            MessageBox.Show(settings.GetString("ErrorMessage"));
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
