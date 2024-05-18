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
using WPFUIKitProfessional.ClassFolder;
using WPFUIKitProfessional.DataFolder;

namespace WPFUIKitProfessional.Pages.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для ListAttendancePage.xaml
    /// </summary>
    public partial class ListAttendancePage : Page
    {
        public ListAttendancePage()
        {
            InitializeComponent();
            VariableClass.listAttendancePage = this;
            UpdateList();
        }

        private void membersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new EditAttendanceWindow(membersDataGrid.SelectedItem as Attendance).Show();
        }

        public void UpdateList()
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
                     .Attendance.Where(u => u.Staff.FIOStaff.ToString()
                     .StartsWith(SearchTb.Text))
                     .ToList().OrderBy(u => u.Staff.FIOStaff.ToString());
        }
        private void LoginTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

    }
}
