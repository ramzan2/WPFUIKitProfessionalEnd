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
    /// Логика взаимодействия для EditRequestWindow.xaml
    /// </summary>
    public partial class EditRequestWindow : Window
    {
        private LeaveRequests leaveRequests;
        public EditRequestWindow(LeaveRequests existingleaveRequests)
        {
            InitializeComponent();
            DBEntities.NullContext();
            leaveRequests = DBEntities.GetContext().LeaveRequests
                .FirstOrDefault(u => u.IdLeaveRequests == existingleaveRequests.IdLeaveRequests);
            DataContext = leaveRequests;
            this.leaveRequests.IdLeaveRequests = leaveRequests.IdLeaveRequests;

            StaffCb.ItemsSource = DBEntities.GetContext()
                  .Staff.ToList();
            StatusCb.ItemsSource = DBEntities.GetContext()
                .StatusRequests.ToList();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                leaveRequests = DBEntities.GetContext().LeaveRequests
                  .FirstOrDefault(u => u.IdLeaveRequests == leaveRequests.IdLeaveRequests);
                leaveRequests.IdStaff = Convert.ToInt32(StaffCb.SelectedValue);
                leaveRequests.StartDate = Convert.ToDateTime(StartDt.SelectedDate);
                leaveRequests.EndDate = Convert.ToDateTime(EndDt.SelectedDate);
                leaveRequests.IdStatusRequests = Convert.ToInt32(StatusCb.SelectedValue);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                if (VariableClass.listRequest != null) VariableClass.listRequest.UpdateList();
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
    }
}
