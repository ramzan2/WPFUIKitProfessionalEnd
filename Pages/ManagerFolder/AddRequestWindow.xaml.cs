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
    /// Логика взаимодействия для AddRequestWindow.xaml
    /// </summary>
    public partial class AddRequestWindow : Window
    {
        LeaveRequests leaveRequests = new LeaveRequests();
        public AddRequestWindow()
        {
            InitializeComponent();
            StaffCb.ItemsSource = DBEntities.GetContext()
                .Staff.ToList();
            StatusCb.ItemsSource = DBEntities.GetContext()
                   .StatusRequests.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().LeaveRequests.Add(new LeaveRequests()
            {
                IdStaff = Convert.ToInt32(StatusCb.SelectedValue),
                StartDate = Convert.ToDateTime(StartDt.SelectedDate),
                EndDate = Convert.ToDateTime(EndDt.SelectedDate),
                IdStatusRequests = Int32.Parse(StatusCb.SelectedValue.ToString())
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Запрос отправлен");
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
