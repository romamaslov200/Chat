using ChatClient.Core;
using ChatClient.Viwes.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private JsonController jsonController = new JsonController();
        private Json ObjectJson;

        public MainWindow()
        {
            InitializeComponent();



            ObjectJson = jsonController.JsonStart();

            NavArcCore.MainWindow = this;
            NavArcCore.MainFrame = MainFrame;
            //NavArcCore.MainFrame.NavigationService.Navigate(new Home_Page());
            NavArcCore.ChageFrame(new Home_Page());


            //Максимальное разрешение экрана
            NavArcCore.MainWindow.MaxHeight = SystemParameters.PrimaryScreenHeight / 1.5;
            NavArcCore.MainWindow.MaxWidth = SystemParameters.PrimaryScreenWidth / 1.5;

            //пораметры
            NavArcCore.MainWindow.Height = ObjectJson.Height;
            NavArcCore.MainWindow.Width = ObjectJson.Width;

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_Cloase_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Folding_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void GitHub_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/romamaslov200",
                UseShellExecute = true
            });
        }


        private void left_arrow_Button_Click(object sender, RoutedEventArgs e)
        {
            NavArcCore.GoBack();
        }

        private void right_arrow_Button_Click(object sender, RoutedEventArgs e)
        {
            NavArcCore.GoNext();
        }


        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (MainFrame.Content is Page page)
            {
                NavTitle.Content = page.Title;
                this.Title = page.Title;
            }
        }
    }
}
