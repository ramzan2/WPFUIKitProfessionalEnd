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
    /// Логика взаимодействия для AddShiftsWindow.xaml
    /// </summary>
    public partial class AddShiftsWindow : Window
    {
        Shifts shifts = new Shifts();
        public AddShiftsWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().Shifts.Add(new Shifts()
            {
                ShiftsName = StaffCb.Text,
                StartTimeShifts = StartDt.Text,
                EndTimeShifts = EndDt.Text
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Смена создана");
            if (VariableClass.listShift != null) VariableClass.listShift.UpdateList();
            Close   ();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
