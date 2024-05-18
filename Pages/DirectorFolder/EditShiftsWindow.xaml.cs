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
    /// Логика взаимодействия для EditShiftsWindow.xaml
    /// </summary>
    public partial class EditShiftsWindow : Window
    {
        private Shifts shifts;
        public EditShiftsWindow(Shifts existingShifts)
        {
            InitializeComponent();

            DBEntities.NullContext();
            shifts = DBEntities.GetContext().Shifts
                .FirstOrDefault(u => u.IdShifts == existingShifts.IdShifts);
            DataContext = shifts;
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
                shifts = DBEntities.GetContext().Shifts
                  .FirstOrDefault(u => u.IdShifts == shifts.IdShifts);
                shifts.ShiftsName = StaffCb.Text;
                shifts.StartTimeShifts = StartDt.Text;
                shifts.EndTimeShifts = EndDt.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                if (VariableClass.listShift != null) VariableClass.listShift.UpdateList();
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
