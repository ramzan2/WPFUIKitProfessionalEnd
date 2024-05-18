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

namespace WPFUIKitProfessional.Pages.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            User user = new User();
            InitializeComponent();
            VariableClass.listUser = this;
            UpdateList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        public void UpdateList()
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
                  .User.Where(u => u.LoginUser
                .StartsWith(SearchTb.Text))
            .ToList().OrderBy(u => u.LoginUser);
        }

        private void DeletUser_Click(object sender, RoutedEventArgs e)
        {
            User user = membersDataGrid.SelectedItem as User;
            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"пользователя " +
                    $"{user.LoginUser}?"))
                {
                    DBEntities.GetContext().User
                        .Remove(membersDataGrid.SelectedItem as User);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Пользователь удалена");
                    membersDataGrid.ItemsSource = DBEntities.GetContext()
                        .User.ToList().OrderBy(u => u.LoginUser);
                }

            }
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            new EditUserWindow(membersDataGrid.SelectedItem as User).ShowDialog();
        }
    }
}
