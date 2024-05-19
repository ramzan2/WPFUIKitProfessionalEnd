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
using WPFUIKitProfessional.DataFolder;

namespace WPFUIKitProfessional.Pages.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для EditAttendanceWindow.xaml
    /// </summary>
    public partial class EditAttendanceWindow : Window
    {
        private Attendance attendance;
        public EditAttendanceWindow(Attendance existingAttendance)
        {
            InitializeComponent();

            DBEntities.NullContext();
            attendance = DBEntities.GetContext().Attendance
                .FirstOrDefault(u => u.IdAttendance == existingAttendance.IdAttendance);
            DataContext = attendance;
            this.attendance.IdAttendance = attendance.IdAttendance;

            ComboCb.ItemsSource = DBEntities.GetContext()
                  .StatusAttendance.ToList();

            StaffCb.ItemsSource = DBEntities.GetContext()
                   .Staff.ToList();

            ShiftsCb.ItemsSource = DBEntities.GetContext()
                 .Shifts.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                attendance = DBEntities.GetContext().Attendance
                  .FirstOrDefault(u => u.IdAttendance == attendance.IdAttendance);
                attendance.IdStaff = Convert.ToInt32(StaffCb.SelectedValue);
                attendance.IdShifts = Convert.ToInt32(ShiftsCb.SelectedValue);
                attendance.IdStatusAttendance = Convert.ToInt32(ComboCb.SelectedValue);

                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");

                if (VariableClass.listAttendancePage != null) VariableClass.listAttendancePage.UpdateList();
                Close();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
