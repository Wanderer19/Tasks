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
    public partial class DataReceiverForm : Form
    {
        private bool choice = true;
        private Visualizer visualizer;
        private SortingForm mainForm;
        private int sortId;
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

        private void HandleReceiverData(object sender, EventArgs e)
        {
            try
            {
                if (choice)
                    this.RunVisualizer(new int[] { 0, -9, 7, 1, 5 });
                else
                {
                
                    var intputData = this.inputField.Text;

                    if (IsValidData(intputData))
                        this.RunVisualizer(ReadData(intputData));
                    else
                        this.ProcessError();
                    
                }
                
            }
            catch (Exception ex)
            {
                     this.ProcessError();
            }
        }
        
        private static bool IsValidData(string inputData)
        {
            return inputData.Any(i => Char.IsWhiteSpace(i) || Char.IsNumber(i) || i == '-');
        }

        private static int [] ReadData(string inputData)
        {
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
            //visualizer.ArrayOld = array;//TO-DO сделать setArray , проверка на размер и тд
            visualizer.Show();
        }

        private void ProcessError()
        {
            this.inputField.Text = "";
            MessageBox.Show("Ошибка! Неправильный формат строки.");
        }
    }
}
