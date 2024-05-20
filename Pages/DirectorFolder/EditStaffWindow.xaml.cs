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
using Microsoft.Win32;
using WPFUIKitProfessional.ClassFolder;
using WPFUIKitProfessional.DataFolder;

namespace WPFUIKitProfessional.Pages.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        private Staff staff;
        public EditStaffWindow(Staff existingStaff)
        {
            InitializeComponent();
            DBEntities.NullContext();
            staff = DBEntities.GetContext().Staff
                .FirstOrDefault(u => u.IdStaff == existingStaff.IdStaff);
            DataContext = staff;
            if (staff != null) selectedFileName = "фото есть";

            PositionCb.ItemsSource = DBEntities.GetContext()
                  .Position.ToList();
            DepartmentCb.ItemsSource = DBEntities.GetContext()
                   .Departments.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
                staff = DBEntities.GetContext().Staff
                   .FirstOrDefault(u => u.IdStaff == staff.IdStaff);
                staff.FIOStaff = StaffTb.Text;
                staff.PhoneNumber = PhoneTb.Text;
                staff.IdPosition = Int32.Parse(
                    PositionCb.SelectedValue.ToString());
                staff.IdDepartment = Int32.Parse(
                    DepartmentCb.SelectedValue.ToString());
                if (selectedFileName != "фото есть")
                    staff.PhotoStaff = ImageClass.ConvertImageToByteArray(selectedFileName);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
            if (VariableClass.listStaff != null) VariableClass.listStaff.UpdateList();
            Close();
        }

        private void DowloadBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
        string selectedFileName = "";
        private void AddPhoto()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    staff.PhotoStaff = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImageClass.ConvertByteArrayToImage(staff.PhotoStaff);
                }
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
