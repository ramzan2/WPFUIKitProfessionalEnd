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
using System.Windows.Shapes;
using WPFUIKitProfessional.ClassFolder;

namespace WPFUIKitProfessional.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuDirectorWindow.xaml
    /// </summary>
    public partial class MenuDirectorWindow : Window
    {
        public MenuDirectorWindow()
        {
            InitializeComponent();
            frameContent.Navigate(new Pages.DirectorFolder.listStaffPage());
        }

        private void ListSattf_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Pages.DirectorFolder.listStaffPage());
            
        }

        private void ListShifts_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Pages.DirectorFolder.ListShiftsPage());
        }

        private void ListRequest_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Pages.DirectorFolder.ListRequestPage());
        }

        private void Attendance_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Pages.DirectorFolder.ListAttendancePage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }
    }
}
