using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace WPFUIKitProfessional.Pages.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для listStaffPage.xaml
    /// </summary>
    public partial class listStaffPage : Page
    {
        public listStaffPage()
        {
            InitializeComponent();
            VariableClass.listStaff = this;
            UpdateList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        public void UpdateList()
        {
            ListStaffLb.ItemsSource = DBEntities.GetContext()
                 .Staff.Where(u => u.FIOStaff.
                  StartsWith(SearchTb.Text))
                 .ToList().OrderBy(u => u.FIOStaff.ToString());
        }
        private void EditTE_Click(object sender, RoutedEventArgs e)
        {
            new EditStaffWindow(ListStaffLb.SelectedItem as Staff).ShowDialog();
        }


        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddStaffWindow().Show();
        }
    }
}
