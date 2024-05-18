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
using WPFUIKitProfessional.Pages.ManagerFolder;

namespace WPFUIKitProfessional.Pages.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для ListRequestPage.xaml
    /// </summary>
    public partial class ListRequestPage : Page
    {
        public ListRequestPage()
        {
            LeaveRequests leaveRequests = new LeaveRequests();
            InitializeComponent();
            VariableClass.listRequest = this;
            UpdateList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
        
        public void UpdateList()
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
                 .LeaveRequests.Where(u => u.Staff.FIOStaff.ToString()
                 .StartsWith(SearchTb.Text))
                 .ToList().OrderBy(u => u.Staff.FIOStaff.ToString());
        }
        private void EditTE_Click(object sender, RoutedEventArgs e)
        {
            new EditRequestWindow(membersDataGrid.SelectedItem as LeaveRequests).Show();
        }

        private void membersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new EditRequestWindow(membersDataGrid.SelectedItem as LeaveRequests).Show();
        }
    }
}
