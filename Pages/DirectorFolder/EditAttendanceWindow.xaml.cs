using System;
using System.Collections;
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

namespace WPFUIKitProfessional.Pages.DirectorFolder
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

            StaffCb.ItemsSource = DBEntities.GetContext()
                 .Staff.ToList();
            StartDt.ItemsSource = DBEntities.GetContext()
                   .Shifts.ToList();
            EndDt.ItemsSource = DBEntities.GetContext()
                 .StatusAttendance.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                attendance = DBEntities.GetContext().Attendance
                   .FirstOrDefault(u => u.IdAttendance == attendance.IdAttendance);
                attendance.IdStaff = Int32.Parse(
                    StaffCb.SelectedValue.ToString());
                attendance.IdShifts = Int32.Parse(
                    StartDt.SelectedValue.ToString());
                attendance.IdStatusAttendance = Int32.Parse(
                  EndDt.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                if (VariableClass.listAttendance != null) VariableClass.listAttendance.UpdateList();
                Close();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
