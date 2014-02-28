using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var b = new TextBox();
            
        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ToolsSpellingHints_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi");
            string spelling = string.Empty;
            SpellingError error = TxtData.GetSpellingError(TxtData.CaretIndex);
            if (error != null)
            {
                foreach (var s in error.Suggestions)
                {
                    spelling += string.Format("{0}\n", s);
                }
                MessageBox.Show("ff {0}", spelling);
                lblbSpellingHints.Content = spelling;
                expanderSpelling.IsExpanded = true;
            }
        }

        private void MouseEnterExitArea(object sender, MouseEventArgs e)
        {
            StatBarTextBlock.Text = "Exit The Application";
        }

        private void MouseLeaveArea(object sender, MouseEventArgs e)
        {
            StatBarTextBlock.Text = "Ready";
        }

        private void MouseEnterToolsHintsArea(object sender, MouseEventArgs e)
        {
            StatBarTextBlock.Text = "Show Spellings Suggestions";
        }
    }
}
