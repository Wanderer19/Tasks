using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace ConsoleApplication10
{
    class MainWindow :Window
    {
        private Button buttonExitApp = new Button();
        public MainWindow(string windowTitle, int height, int width)
        {
            buttonExitApp.Click += ButtonExitApp_Clicked;
            buttonExitApp.Content = "Exit Application";
            buttonExitApp.Height = 25;
            buttonExitApp.Width = 100;
            var ell = new Ellipse();
            ell.Width = 100;
            ell.Height = 100;
            ell.Fill = Brushes.CornflowerBlue;
       
            //this.AddChild(buttonExitApp);
            this.AddChild(ell);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = windowTitle;
            this.Height = height;
            this.Width = width;

            this.Closed += MainWindow_Closed;
            this.Closing += MainWindow_Closing;
            this.MouseMove += MainWindow_MouseMove;
            this.KeyDown += MainWindow_KeyDown;
        }

        protected void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            buttonExitApp.Content = e.Key.ToString();
        }

        protected void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Title = e.GetPosition(this).ToString();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string message = "Do you want to close without saving?";
            MessageBoxResult result = MessageBox.Show(message, "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("See ya!");
        }

        private void ButtonExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            if ((bool)Application.Current.Properties["Good Mode"])
                MessageBox.Show("Cheater!");
            this.Close();
        }
    }

    class Program : Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            Program ap = new Program();
            ap.Startup += AppStartup;
            ap.Exit += AppExit;
            ap.Run();
        }

        static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("App has exited!");
        }

        static void AppStartup(object sender, StartupEventArgs e)
        {
            Application.Current.Properties["Good Mode"] = false;

            if (e.Args.Any(str => str.ToLower() == "/goodmode"))
            {
                Application.Current.Properties["Good Mode"] = true;
            }

            var mainWindow = new MainWindow("My First WPF Application!", 200, 300);
            mainWindow.Show();
        }
    }
}
