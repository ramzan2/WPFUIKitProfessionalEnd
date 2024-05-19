using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using WPFUIKitProfessional.ClassFolder;
using WPFUIKitProfessional.DataFolder;
using WPFUIKitProfessional.Pages;
using WPFUIKitProfessional.Pages.ManagerFolder;
using WPFUIKitProfessional.WindowFolder;

namespace WPFUIKitProfessional
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frameContent.Navigate(new ListAttendancePage());
        }

 

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdAnalytics_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new ListShiftsPage());
        }

        private void rdMessages_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Pages.ManagerFolder.ListRequestPage());
        }

        private void rdUsers_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new ListAttendancePage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddRequestWindow().Show();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }
    }
}
