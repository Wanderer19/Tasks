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

namespace HelloWorld
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

        private void HelloButton_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tb = new TextBlock();//создали новый элемент
            tb.Text = "Hello World!";
             //задаем положение элемента в окне
            Thickness mrgn = new Thickness(0, 0, 0, 0);
            tb.Margin = mrgn;
            //добавляем элемент на сетку
            MasterGrid.Children.Add(tb);
            MessageBox.Show("Hi!");

           
                    
        }
    }
}
