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

namespace WPFUIKitProfessional.Pages.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для ListAttendancePage.xaml
    /// </summary>
    public partial class ListAttendancePage : Page
    {
        public ListAttendancePage()
        {
            InitializeComponent();
            VariableClass.listAttendance = this;
            UpdateList();
        }

        private void membersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new EditAttendanceWindow(membersDataGrid.SelectedItem as Attendance).Show();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        public void UpdateList()
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
          .Attendance.Where(u => u.Staff.FIOStaff.ToString()
          .StartsWith(SearchTb.Text))
          .ToList().OrderBy(u => u.Staff.FIOStaff.ToString());
        }
        private void EditTE_Click(object sender, RoutedEventArgs e)
        {
            new EditAttendanceWindow(membersDataGrid.SelectedItem as Attendance).Show();
        }

        private void DeletTE_Click(object sender, RoutedEventArgs e)
        {
            Attendance attendance = membersDataGrid.SelectedItem as Attendance;

            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите технику" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"технику " +
                    $"{attendance.IdStaff}?"))
                {
                    DBEntities.GetContext().Attendance
                        .Remove(membersDataGrid.SelectedItem as Attendance);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Техника удалена");
                    membersDataGrid.ItemsSource = DBEntities.GetContext()
                        .Attendance.ToList().OrderBy(u => u.IdStaff);
                }

            }
        }

        private void NewAttendenczBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddAttendanceWindow().Show();
        }
    }
}
