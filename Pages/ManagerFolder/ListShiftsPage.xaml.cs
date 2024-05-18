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
using WPFUIKitProfessional.DataFolder;

namespace WPFUIKitProfessional.Pages.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для ListShiftsPage.xaml
    /// </summary>
    public partial class ListShiftsPage : Page
    {
        public ListShiftsPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .Shifts.ToList().OrderBy(u => u.IdShifts);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
                        .Shifts.Where(u => u.StartTimeShifts
                        .StartsWith(SearchTb.Text))
                        .ToList().OrderBy(u => u.StartTimeShifts);
        }
    }
}
