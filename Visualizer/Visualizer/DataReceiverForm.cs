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
        private Visualizer visualizer;
        private readonly SortingForm mainForm;
        private readonly int sortId;
        private const int BubbleSortId = 1;

        public DataReceiverForm(SortingForm form, int sortId)
        {
            this.mainForm = form;
            this.sortId = sortId;
            
            InitializeComponent();
        }

        private void IdentifyVisualizer(int [] array)
        {
            switch (sortId)
            {
                case GeneralSettings.BubbleSortId:
                {
                    visualizer = new BubbleSortVisualizer(mainForm, array);
                    break;
                }
                case GeneralSettings.SelectionSortId:
                {
                    visualizer = new SelectionSortVisualizer(mainForm, array);
                    break;
                }
            }    
        }

        private void SelectDefaultData(object sender, EventArgs e)
        {
            choice = true;
        }

        private void SelectEnteredDataButton(object sender, EventArgs e)
        {
            choice = false;
        }

        private void TryToRunVisualizer(object sender, EventArgs e)
        {
            try
            {
                if (choice)
                    this.RunVisualizer(new int[] { 0, -9, 7, 1, 5 });
                else
                {
                    if (IsValidInputData(inputField.Text))
                        this.RunVisualizer(ReadData());
                    else
                        this.ProcessError();
                    
                }
            }
            catch (Exception ex)
            {
                this.ProcessError();
            }
        }
        
        private bool IsValidInputData(string inputData)
        {
            if (inputData.Any(i => Char.IsWhiteSpace(i) || Char.IsNumber(i) || i == '-'))
            {
                var array = ReadData();

                if (array.Length > DataReceiverFormSettings.SizeLimitArray)
                    return false;

                return !array.Any(i => Math.Abs(i) > DataReceiverFormSettings.LimitArrayElementValue);
            }
            

            return false;
        }

        private int [] ReadData()
        {
            
            var inputData = this.inputField.Text;
            inputData = Regex.Replace(inputData, @"\s+", ",");

            var array = inputData.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            return array;
        }

        private void RunVisualizer(int[] array)
        {
            this.Visible = false;

            this.IdentifyVisualizer(array);
            visualizer.Show();
        }

        private void ProcessError()
        {
            this.inputField.Text = "";
            MessageBox.Show(DataReceiverFormSettings.ErrorMessage);
        }
    }
}
