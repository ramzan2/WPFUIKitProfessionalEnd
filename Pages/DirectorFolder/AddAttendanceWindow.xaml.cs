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

namespace WPFUIKitProfessional.Pages.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для AddAttendanceWindow.xaml
    /// </summary>
    public partial class AddAttendanceWindow : Window
    {
        Attendance attendance = new Attendance();
        public AddAttendanceWindow()
        {
            InitializeComponent();
            StaffCb.ItemsSource = DBEntities.GetContext()
              .Staff.ToList();
            StartDt.ItemsSource = DBEntities.GetContext()
                   .Shifts.ToList();
            EndDt.ItemsSource = DBEntities.GetContext()
                   .StatusAttendance.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().Attendance.Add(new Attendance()
            {
                IdStaff = Int32.Parse(StaffCb.SelectedValue.ToString()),
                IdShifts = Int32.Parse(StartDt.SelectedValue.ToString()),
                IdStatusAttendance = Int32.Parse(EndDt.SelectedValue.ToString())
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Посещаемость добавленна");
            if (VariableClass.listAttendance != null) VariableClass.listAttendance.UpdateList();
            Close();
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
